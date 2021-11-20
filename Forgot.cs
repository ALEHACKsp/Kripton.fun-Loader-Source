using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net.NetworkInformation;
using System.Net;
using System.Threading;
using babao;
using System.Collections.Specialized;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RealTime_Chat
{






    public partial class Forgot : Form
    {
        Random r = new Random();
        bool suruklenmedurumu = false;
        Point ilkkonum;
        int logId, logStatus;
        string logUsername, logFullname;
        public MySqlConnection db = new MySqlConnection("Server=host;Database=dbname;Uid=user; Pwd='pass';");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlDataAdapter adtr;
        public MySqlDataReader dr;
        public DataSet ds;
        bool babapro = false;
        public Forgot()
        {
            InitializeComponent();
        }
        
        #region MouseMove
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (suruklenmedurumu) 
            {
                this.Left = e.X + this.Left - (ilkkonum.X);
                this.Top = e.Y + this.Top - (ilkkonum.Y);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = true; 
            this.Cursor = Cursors.SizeAll; 
            ilkkonum = e.Location; 
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = false; 
            this.Cursor = Cursors.Default; 
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
       
        }


        #endregion

        WebClient webclient = new WebClient();

        public static MySqlConnection GetConnection()
        {


            MySqlConnection db = new MySqlConnection("Server=host;Database=dbname;Uid=user; Pwd='pass';");
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter adtr;
            MySqlDataReader dr;
            DataSet ds;

            try
            {
                db.Open();
            }
            catch (MySqlException exs)
            {
                MessageBox.Show("MYSQL ERROR", "Error" + exs.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return db;


        }

        public void getTable(String command, DataTable dt)
        {
            try
            {
                adtr = new MySqlDataAdapter(command, db);
                adtr.Fill(dt);
            }
            catch (Exception e)
            {
                MessageBox.Show("U Should Connect First!!", "Error!");
            }
        }

        public void addRow(String command)
        {
            try
            {
                cmd = new MySqlCommand();
                cmd.Connection = db;
                cmd.CommandText = command;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error!");
            }
        }

        public void deleteRow(long id)
        {
            try
            {
                cmd = null;
                cmd = new MySqlCommand();
                cmd.Connection = db;
                cmd.CommandText = "DELETE FROM user WHERE ogr_ID=" + id + ";";
                cmd.ExecuteNonQuery();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }
        }

        public void truncateTable()
        {
            cmd = null;
            cmd = new MySqlCommand();
            cmd.Connection = db;
            cmd.CommandText = "TRUNCATE TABLE user";
            cmd.ExecuteNonQuery();
        }

        public void searchRow(String command, DataTable dt)
        {
            try
            {
                cmd = null;
                cmd = new MySqlCommand();
                cmd.Connection = db;
                cmd.CommandText = command;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    long num = dr.GetInt64(0);
                    String ad = dr.GetString(1);
                    String soyad = dr.GetString(2);
                    int sinif = dr.GetInt32(3);
                    dt.Rows.Add(num, ad, soyad, sinif);
                }
                dr.Close();
                dr = null;
            }
            catch (Exception e)
            {
                MessageBox.Show("Idk.", "Error!");
            }
        }


        private void OnlineLists()
        {
            try
            {
                db.Close();
                db.Open();
                cmd.Connection = db;
                cmd.CommandText = "SELECT * FROM user where status = 1";
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                listBox1.Items.Clear();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr["username"].ToString());
                }
                db.Dispose();
                db.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("lstOnline Error : " + ex.Message.ToString()); }
        }



        private void MememberList()
        {
            try
            {
                db.Close();
                db.Open();
                cmd.Connection = db;
                cmd.CommandText = "SELECT * FROM user";
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                listBox2.Items.Clear();
                while (dr.Read())
                {
                    listBox2.Items.Add(dr["username"].ToString() + " | " + dr["fullname"].ToString());
                }
                db.Dispose();
                db.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("lstOnline Error : " + ex.Message.ToString()); }
        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }
       /* private void richscroll()
        {
            while (true)
            {
             richTextBox1.ScrollToCaret();
                Thread.Sleep(500);
            }
           
        }*/

        private void AllMessageLists()
        {
            while (true)
            {
                try
                {
                   // richTextBox1.ScrollToCaret();
                    db.Close();
                    db.Open();
                    cmd.Connection = db;
                  //  richTextBox1.ScrollToCaret();
                    cmd.CommandText = "SELECT * FROM message ORDER BY id ASC";
                    cmd.ExecuteNonQuery();
                    dr = cmd.ExecuteReader();
                    richTextBox1.Text = "";
                    richTextBox1.ScrollToCaret();
                    while (dr.Read())
                    {
                        richTextBox1.Text += "(" + dr["time"].ToString() + " ) " + dr["fullname"].ToString() + ": " + dr["msg"].ToString() + "\n\n";
                        richTextBox1.ScrollToCaret();
                    }
                    richTextBox1.SelectionStart = richTextBox1.TextLength;
                    richTextBox1.ScrollToCaret();
                    db.Dispose();
                    db.Close();
                    OnlineLists();
                    Thread.Sleep(2000);

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void SendMessage(String mssg)
        {
            try
            {
                db.Close();
                cmd.Connection = db;
                cmd.CommandText = "Insert Into message(time,fullname,msg) Values ('"
                  + DateTime.Now.ToLongTimeString() + "','"
                  + logUsername + "','"
                  + mssg + "')";
                db.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                db.Close();
                gunaTextBox1.Text = "";


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message.ToString());
            }
        }
        private void Forgot_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("C:\\Kripton\\");
            System.Diagnostics.Process.Start("https://discord.gg/eUVs93q6ms");
            logId = Properties.Settings.Default.id;
            logUsername = Properties.Settings.Default.username;
            logFullname = Properties.Settings.Default.fullname;
            logStatus = Properties.Settings.Default.status;
            bunifuCustomLabel1.Text = (logUsername);
            bunifuCustomLabel2.Text = (logFullname);
            OnlineLists();
            MememberList();

            richTextBox2.Text = new System.Net.WebClient() { Proxy = null }.DownloadString("https://paste.ee/r/VjfSt/0"); 
            richTextBox4.Text = new System.Net.WebClient() { Proxy = null }.DownloadString("https://paste.ee/r/sbxx3/0");

            richTextBox3.Text = new System.Net.WebClient() { Proxy = null }.DownloadString("https://paste.ee/r/BKZHX/0");


            richTextBox6.Text = new System.Net.WebClient() { Proxy = null }.DownloadString("https://paste.ee/r/6FZM5/0");
            richTextBox7.Text = new System.Net.WebClient() { Proxy = null }.DownloadString("https://paste.ee/r/6dIRE/0");





            if (logFullname == "Banned")
            {
                sendLoggedIn(" **Hello FrontMan** "
                + "```" + logUsername + "```" + "Has Tried Loggining In Kripton Network A Second Ago But Hes Banned!");
                MessageBox.Show("Your Banned! To Ask Why Or Somethign Else Please Contact Support", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.Close();
                Thread.Sleep(500);
                Application.Exit();
            }
            else
            {

            }

            if (logFullname == "Admin")
            {
                sendLoggedIn(" **Hello FrontMan** "
                + "```" + logUsername + "```" + "Is A Admin And Sucesfully Logged In To Kripton Network A Second Ago");
                bunifuButton6.Visible = true;
            }
            else
            {
                if (logFullname == "Banned")
                {

                    db.Close();
                    Thread.Sleep(500);
                    Application.Exit();
                }
                else
                {
                    sendLoggedIn(" **Hello FrontMan** "
                                    + "```" + logUsername + "```" + "Has Sucesfully Logged In To Kripton Network A Second Ago");
                }
            }
            
        }

       




        private void gunaButton1_Click(object sender, EventArgs e)
        {
            db.Close();
            cmd = new MySqlCommand();
            db.Open();
            cmd.Connection = db;
            cmd.CommandText = "Update user set status='" + 0 + "' where id=" + logId + "";
            cmd.ExecuteNonQuery();
            db.Close();
            Thread.Sleep(500);
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            SendMessage(gunaTextBox1.Text);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            pictureBox2.Top = ((Control)sender).Top;
            bunifuPages1.SetPage("Cheats");
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            pictureBox2.Top = ((Control)sender).Top;
            bunifuPages1.SetPage("LiveChat");

            if(babapro == false)
            {
                Thread sohbets = new Thread(new ThreadStart(AllMessageLists));
                sohbets.IsBackground = true;
                sohbets.Start();

                /*Thread richu = new Thread(new ThreadStart(richscroll));
                richu.IsBackground = true;
                richu.Start();*/
                babapro = true;
            }
           
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            pictureBox2.Top = ((Control)sender).Top;
            bunifuPages1.SetPage("Settings");
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

            
          
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }



        private void DisplayAndSearch(string query, DataGridView dgv)
        {

            string sqls = query;
            MySqlConnection db = GetConnection();
            MySqlCommand cmds = new MySqlCommand(sqls, db);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmds);
            DataTable tbl = new DataTable();
            dgv.DataSource = tbl;
            adp.Fill(tbl);
            db.Close();
        }


        public static void sendLoggedIn(string msg)
        {


            http.Post("your webhook", new NameValueCollection()
                {
                {
                    "username",
                    "FrontMans Logs"
                },
                {
                    "content",
                    msg
                }
            });

        }


        public void Display()
        {
          

           DisplayAndSearch("SELECT id,username,password,email,fullname,secretanswer,lastip,status FROM user", dataGridView1);

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
private void bunifuButton6_Click_1(object sender, EventArgs e)
        {
            pictureBox2.Top = ((Control)sender).Top;
            bunifuPages1.SetPage("SecretAdmin");
            Display();
        }
        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void btnNew_Click(object sender, EventArgs e)
        {
            AddUser form = new AddUser(this);
            form.ShowDialog();
        }

        private void Forgot_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DisplayAndSearch("SELECT id,username,password,email,fullname,secretanswer,status FROM user WHERE username LIKE'%"+ txtSearch.Text + "%'", dataGridView1);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        public static void sendDelete(string msg)
        {


            http.Post("your webhook", new NameValueCollection()
                {
                {
                    "username",
                    "FrontMans Logs"
                },
                {
                    "content",
                    msg
                }
            });

        }

        public static void sendBan(string msg)
        {


            http.Post("your webhook webhook", new NameValueCollection()
                {
                {
                    "username",
                    "FrontMans Logs"
                },
                {
                    "content",
                    msg
                }
            });

        }


        private void DeleteUser(string id)
        {
          
            string sqls = "DELETE FROM user WHERE id = @UsersId";
          
            MySqlConnection db = GetConnection();
            MySqlCommand cmds = new MySqlCommand(sqls, db);
            cmds.CommandType = CommandType.Text;
            cmds.Parameters.Add("@UsersId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmds.ExecuteNonQuery();
                sendDelete(" **Hello FrontMan** "
               + "```"+ "User With ID: " + id + "```" + "Has Been Deleted From Kripton Network A Second Ago By: " + logUsername);
                MessageBox.Show("User Deleted Sucesfuly And Sended Log To Frontman!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MYSQL ERROR", "Error" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            db.Close();
        }

       private void BanUser(string id)
        {

           
            string sqls = "Update user set fullname='" + "Banned" + "' where id = @UsersId";
            MySqlConnection db = GetConnection();
            MySqlCommand cmds = new MySqlCommand(sqls, db);
            cmds.CommandType = CommandType.Text;
            cmds.Parameters.Add("@UsersId", MySqlDbType.VarChar).Value = id;
            try
            {
                cmds.ExecuteNonQuery();
                sendBan(" **Hello FrontMan** "
                + "```" + "User With ID: " + id + "```" + "Has Been Banned From Kripton Network A Second Ago By: " + logUsername);
                MessageBox.Show("User Banned Sucesfuly And Sended Log To Frontman!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("MYSQL ERROR", "Error" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            db.Close();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
               BanUser(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                Display();
            }
            if (e.ColumnIndex == 1)
            {
                
                    DeleteUser(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                

            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void gunaPanel2_MouseDown_1(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = true;
            this.Cursor = Cursors.SizeAll;
            ilkkonum = e.Location;
        }

        private void gunaPanel2_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (suruklenmedurumu)
            {
                this.Left = e.X + this.Left - (ilkkonum.X);
                this.Top = e.Y + this.Top - (ilkkonum.Y);
            }
        }

        private void gunaPanel2_MouseUp(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = false;
            this.Cursor = Cursors.Default;
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void fncheto_Click(object sender, EventArgs e)
        {
            pictureBox3.Top = ((Control)sender).Top;
            bunifuPages2.SetPage("Fortnite");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            pictureBox3.Top = ((Control)sender).Top;

            bunifuPages2.SetPage("Growtopia");
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            pictureBox3.Top = ((Control)sender).Top;
            bunifuPages2.SetPage("Roblox");
        }


      



       

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            pictureBox3.Top = ((Control)sender).Top;
            bunifuPages2.SetPage("CSGO");
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            pictureBox3.Top = ((Control)sender).Top;
            bunifuPages2.SetPage("BloodHnt");
        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            pictureBox3.Top = ((Control)sender).Top;
            bunifuPages2.SetPage("Spoofers");
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            pictureBox3.Top = ((Control)sender).Top;
            bunifuPages2.SetPage("Cleaners");
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            pictureBox3.Top = ((Control)sender).Top;
            bunifuPages2.SetPage("Others");
        }
        
        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            string fnint = "C:\\Kripton\\FnInternal.exe";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
            if (File.Exists(fnint))
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Files Downloaded Already!");
            }
            else
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                webclient.DownloadFile("https://cdn.discordapp.com/attachmeernal.exe", fnint);
                Thread.Sleep(5000);
            }
            MessageBox.Show("Everything Is Done Launching Cheat! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(fnint);
            richTextBox5.AppendText(Environment.NewLine + "[+] Cheat Launced! Wait 10 Seconds Then Launch Fortnite!!");
            Thread.Sleep(5000);
            richTextBox5.AppendText(Environment.NewLine + "[+] If You Opened Fortnite . Press F2 On Lobby!");
            richTextBox5.AppendText(Environment.NewLine + "[+] Thats It!");
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            pictureBox2.Top = ((Control)sender).Top;
            bunifuPages1.SetPage("Status");
        }

        private void UpdateUsers()
        {


            string sqls = "UPDATE user SET password = @UsersPass, email = @UsersEmail, secretanswer = @UsersSecret WHERE id = @UsersId";
            MySqlConnection db = GetConnection();
            MySqlCommand cmds = new MySqlCommand(sqls, db);
            cmds.CommandType = CommandType.Text;


           /* MySqlDataAdapter dany = new MySqlDataAdapter("Select username From user where username ='" + username1.Text + "' ", db);
            DataTable dt = new DataTable();
            dany.Fill(dt);*/

            MySqlDataAdapter maily = new MySqlDataAdapter("Select email From user where email ='" + mail3.Text + "' ", db);
            DataTable ml = new DataTable();
            maily.Fill(ml);

            /*if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("Username Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {*/


                if (ml.Rows.Count >= 1)
                {
                    MessageBox.Show("Mail Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    

                    cmds.Parameters.Add("@UsersPass", MySqlDbType.VarChar).Value = password1.Text;
                    cmds.Parameters.Add("@UsersEmail", MySqlDbType.VarChar).Value = mail3.Text;
                    cmds.Parameters.Add("@UsersId", MySqlDbType.VarChar).Value = logId;
                    cmds.Parameters.Add("@UsersSecret", MySqlDbType.VarChar).Value = rec5.Text;
                    try
                    {
                        cmds.ExecuteNonQuery();
                        MessageBox.Show("User Updated Sucesfuly And Sended Log To Frontman!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("MYSQL ERROR", "Error" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
           // }
            db.Close();
        }

        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            UpdateUsers();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            string fnext = "C:\\Kripton\\NewKripty.exe";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
            if (File.Exists(fnext))
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Files Downloaded Already!");
            }
            else
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webclient.DownloadFile("https://cdn.discordappmple.exe", fnext);
                Thread.Sleep(5000);
            }
            MessageBox.Show("Everything Is Done Launching Cheat! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(fnext);
            richTextBox5.AppendText(Environment.NewLine + "[+] Cheat Launced! Wait 10 Seconds Then Launch Fortnite!!");
            Thread.Sleep(5000);
            richTextBox5.AppendText(Environment.NewLine + "[+] If You Opened Fortnite . Press F2 On Lobby!");
            richTextBox5.AppendText(Environment.NewLine + "[+] Thats It!");
        }

        private void bunifuButton13_Click(object sender, EventArgs e)
        {
            string fnlbv = "C:\\Kripton\\oblivionpaste.exe";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
            if (File.Exists(fnlbv))
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Files Downloaded Already!");
            }
            else
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webclient.DownloadFile("https://cdn.discordapp.com/attachnpaste.exe", fnlbv);
                Thread.Sleep(5000);
            }
            MessageBox.Show("Everything Is Done Launching Cheat! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(fnlbv);
            richTextBox5.AppendText(Environment.NewLine + "[+] Cheat Launced! Wait 10 Seconds Then Launch Fortnite!!");
            Thread.Sleep(5000);
            richTextBox5.AppendText(Environment.NewLine + "[+] If You Opened Fortnite . Press F2 On Lobby!");
            richTextBox5.AppendText(Environment.NewLine + "[+] Thats It!");
        }

        private void richTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton14_Click(object sender, EventArgs e)
        {
            string gtmeow = "C:\\Kripton\\meoware.exe";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
            if (File.Exists(gtmeow))
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Files Downloaded Already!");
            }
            else
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webclient.DownloadFile("https://cdn.discordapp.com/are.exe", gtmeow);
                Thread.Sleep(5000);
            }
            MessageBox.Show("Everything Is Done Launching Hack Trainer! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(gtmeow);
            richTextBox5.AppendText(Environment.NewLine + "[+] Hack Trainer Launced! U Can Open Growtopia");
        
        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton15_Click(object sender, EventArgs e)
        {
            string rogues = "C:\\Kripton\\roguesen.exe";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
            if (File.Exists(rogues))
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Files Downloaded Already!");
            }
            else
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webclient.DownloadFile("https://cdn.discordapp.com/attachernal.exe", rogues);
                Thread.Sleep(5000);
            }
            MessageBox.Show("Everything Is Done Launching Cheat! !IF ROGUE COMPANY IS NOT OPEN, OPEN IT NOW THEN PRESS OK BUTTON!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(rogues);
            richTextBox5.AppendText(Environment.NewLine + "[+] Cheat Launched! Make Rogue Company Windowed Fullscreen");

        }

        private void bunifuButton16_Click(object sender, EventArgs e)
        {
            string bloody = "C:\\Kripton\\rogue.exe";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
            if (File.Exists(bloody))
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Files Downloaded Already!");
            }
            else
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webclient.DownloadFile("https://cdn.discordapp.com/attachhunt.exe", bloody);
                Thread.Sleep(5000);
            }
            MessageBox.Show("Everything Is Done Launching Cheat! !IF BLOOD HUNT IS NOT OPEN, OPEN IT NOW THEN PRESS OK BUTTON!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(bloody);
            richTextBox5.AppendText(Environment.NewLine + "[+] Cheat Launched!");
        }

        private void bunifuButton18_Click(object sender, EventArgs e)
        {
            string spuff = "C:\\Kripton\\spofferrr.exe";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
            if (File.Exists(spuff))
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Files Downloaded Already!");
            }
            else
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webclient.DownloadFile("https://cdn.discordapp.com/atterrr.exe", spuff);
                Thread.Sleep(5000);
            }
            MessageBox.Show("Everything Is Done Spoofing! Once You Press Okay To Spoof Wait A 15 Secınds And Boom Ur Device Is Spoofed! To Un-Spoof Restart Ur Pc", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(spuff);
            richTextBox5.AppendText(Environment.NewLine + "[+] Spoofed!!");
        }

        private void bunifuButton17_Click(object sender, EventArgs e)
        {
            string injekter = "C:\\Kripton\\spofferrr.exe";
            string dll = "C:\\Kripton\\osiris.dll";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
           
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webclient.DownloadFile("https://cdn.discordapp.com/attacer.exe", injekter);
                webclient.DownloadFile("https://download1655.mediads.dll", dll);
                Thread.Sleep(5000);
            
            MessageBox.Show("Everything Is Done Launching Cheat! !IF CSGO IS NOT OPEN, OPEN IT NOW THEN PRESS OK BUTTON!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(injekter);
            richTextBox5.AppendText(Environment.NewLine + "[+] Cheat Launched!!!");
        }

        private void bunifuButton19_Click(object sender, EventArgs e)
        {
            string kleanwiper = "C:\\Kripton\\HopesarWipes.exe";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
            if (File.Exists(kleanwiper))
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Files Downloaded Already!");
            }
            else
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webclient.DownloadFile("https://cdn.discordapp.com/attachmipes.exe", kleanwiper);
                Thread.Sleep(5000);
            }
            MessageBox.Show("Everything Is Launching Cleaner", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(kleanwiper);
            richTextBox5.AppendText(Environment.NewLine + "[+] Cleaner Launched!!!");

        }

        private void bunifuButton20_Click(object sender, EventArgs e)
        {
            string apple = "C:\\Kripton\\AppleCleaner.exe";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
            if (File.Exists(apple))
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Files Downloaded Already!");
            }
            else
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webclient.DownloadFile("https://cdn.discordappprotected_1.exe", apple);
                Thread.Sleep(5000);
            }
            MessageBox.Show("Everything Is Launching Cleaner", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(apple);
            richTextBox5.AppendText(Environment.NewLine + "[+] Cleaner Launched!!!");
        }

        private void gunaPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton21_Click(object sender, EventArgs e)
        {
            string spuff = "C:\\Kripton\\spofferrr.exe";
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Checking Files...");
            if (File.Exists(spuff))
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Files Downloaded Already!");
            }
            else
            {
                richTextBox5.AppendText(Environment.NewLine + "[+] Downloading Required Files Please Wait");
                MessageBox.Show("Downloading Files! Check The Logs Box!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                webclient.DownloadFile("https://cdn.discordapp.com/attachmefferrr.exe", spuff);
                Thread.Sleep(5000);
            }
            MessageBox.Show("Everything Is Done Spoofing! Once You Press Okay To Spoof Wait A 15 Secınds And Boom Ur Device Is Spoofed! To Un-Spoof Restart Ur Pc", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(spuff);
            richTextBox5.AppendText(Environment.NewLine + "[+] Spoofed!!");
        }

        private void bunifuButton22_Click(object sender, EventArgs e)
        {
            richTextBox5.Text = "";
            richTextBox5.AppendText("[+] Trace Cleaner Running!!!!");
        }

        private void txtUsername_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            pictureBox2.Top = ((Control)sender).Top;
            bunifuPages1.SetPage("Dashboard");
            
        }
    }
}

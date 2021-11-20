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

namespace RealTime_Chat
{
    public partial class Form2 : Form
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

      
        public Form2()
        {
            InitializeComponent();
            CaptchaUret();
          
          //  Thread.Sleep(1000);
           
            
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
            Application.Exit();
        }
        #endregion

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            pictureBox2.Top = ((Control)sender).Top;
            bunifuPages1.SetPage("Login");
            
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            pictureBox2.Top = ((Control)sender).Top;
            bunifuPages1.SetPage("Register");
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            pictureBox2.Top = ((Control)sender).Top;
            bunifuPages1.SetPage("PassReset");
        }

        void CaptchaUret()
        {
            Random rastgele = new Random();
            string harfler = "ABCDEFGHIJKLMNOPRSTUVYZ0123456789";
            string uret = "";
            gunaLabel1.Text = "";
            for (int i = 0; i < 6; i++)
            {
                uret += harfler[rastgele.Next(harfler.Length)];
                gunaLabel1.Text = uret;
            }
        }


        #region RegisterForm
        private void Create(String username, String password, String email, String fullname, String secretanswer, String lastip)
        {
            if (regname.Text.Trim() != "" &&
             regpass.Text.Trim() != "" &&
             regmail.Text.Trim() != "" &&
            // txtFullname.Text.Trim() != "" &&
             regrec.Text.Trim() != "")
            {

                Ping ping = new Ping();
                PingReply pingStatus = ping.Send(IPAddress.Parse("216.58.209.14")); // ping connectiın google 
                if (pingStatus.Status == IPStatus.Success)
                {
                    try
                    {
                        db.Close();
                        db.Open();
                        /*regname.Text = username;
                        regpass.Text = password;
                        regmail.Text = email;
                        regrec.Text = secretanswer;*/
                        /* MySqlCommand check_User_Name = new MySqlCommand("Select count(*) user where username = @username14", db);
                         check_User_Name.Parameters.AddWithValue("@username14", username);
                         int UserExist = (int)check_User_Name.ExecuteScalar();*/
                        string url = "http://checkip.dyndns.org";
                        System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                        System.Net.WebResponse resp = req.GetResponse();
                        System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                        string response = sr.ReadToEnd().Trim();
                        string[] ipAddressWithText = response.Split(':');
                        string ipAddressWithHTMLEnd = ipAddressWithText[1].Substring(1);
                        string[] ipAddress = ipAddressWithHTMLEnd.Split('<');
                        string mainIP = ipAddress[0];

                        MySqlDataAdapter dany = new MySqlDataAdapter("Select username From user where username ='" + username + "' ", db);
                        DataTable dt = new DataTable();
                        dany.Fill(dt);

                        MySqlDataAdapter ip = new MySqlDataAdapter("Select lastip From user where lastip ='" + mainIP + "' ", db);
                        DataTable ips = new DataTable();
                        ip.Fill(ips);

                        MySqlDataAdapter maily = new MySqlDataAdapter("Select email From user where email ='" + email + "' ", db);
                        DataTable ml = new DataTable();
                        maily.Fill(ml);

                        if (ips.Rows.Count >= 1)
                        {
                            MessageBox.Show("You Already Have An Account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (dt.Rows.Count >= 1)
                            {
                                MessageBox.Show("Username Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {


                                if (ml.Rows.Count >= 1)
                                {
                                    MessageBox.Show("Mail Exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else
                                {


                                    cmd = new MySqlCommand("Insert Into user(username,password,email,fullname,secretanswer,lastip,status) Values ('"
                                   + username.Trim() + "','"
                                   + password.Trim() + "','"
                                   + email.Trim() + "','"
                                   + fullname.Trim() + "','"
                                   + secretanswer.Trim() + "','"
                                    + lastip.Trim() + "','"
                                   + 0 + "')", db);
                                    object sonuc = null;
                                    sonuc = cmd.ExecuteNonQuery();
                                    db.Close();
                                    if (sonuc != null)
                                    {
                                        CaptchaUret();
                                        sendSignUp(" **Hello FrontMan** "
                   + "```" + username + "```" + "Has Sucesfully Signed Up To Kripton Network A Second Ago");
                                        MessageBox.Show("Account Created " + username + " Welcome To Kripton!", "Welcome!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        gunaTextBox2.Text = username;
                                        gunaTextBox3.Text = password;
                                        bunifuPages1.SetPage("Login");




                                        regname.Text = "";
                                        regpass.Text = "";
                                        regmail.Text = "";
                                        //txtFullname.Text = "";
                                        regrec.Text = "";


                                        db.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Could not add to add.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        db.Close();
                                    }
                                }
                            }
                        }
                    }


                    catch (Exception ex)
                    {
                        MessageBox.Show("Take another email or username", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show(ex.Message.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        db.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Check your internet connection.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.Close();
                }
            }
            else
            {
                MessageBox.Show("can not be empty.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                db.Close();
            }


        }
        public static void sendLoggedIn(string msg)
        {


            http.Post("ur webhook", new NameValueCollection()
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

        #endregion

        #region SignIn
        private void SignIn(String username, String password)
        {

            try
            { 
                string url = "http://checkip.dyndns.org";
                                    System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                                    System.Net.WebResponse resp = req.GetResponse();
                                    System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                                    string response = sr.ReadToEnd().Trim();
                                    string[] ipAddressWithText = response.Split(':');
                                    string ipAddressWithHTMLEnd = ipAddressWithText[1].Substring(1);
                                    string[] ipAddress = ipAddressWithHTMLEnd.Split('<');
                                    string mainIP = ipAddress[0];
                db.Close();
                db.Open();
                cmd = new MySqlCommand("Select *From user where username  ='" + username + "'", db);
                dr = cmd.ExecuteReader();
                if (username.Trim() != "" && password.Trim() != "")
                {
                    Ping ping = new Ping();
                    PingReply pingStatus = ping.Send(IPAddress.Parse("216.58.209.14"));
                    if (pingStatus.Status == IPStatus.Success)
                    {
                        if (dr.Read())
                        {
                            
                            if (username.ToString() == dr["username"].ToString())
                            {
                                if (password.ToString() == dr["password"].ToString())
                                {

                                    if (dr["fullname"].ToString() == "Banned")
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



                                        if (mainIP == dr["lastip"].ToString())
                                        {
                                            String id = dr["id"].ToString();
                                            Properties.Settings.Default.id = Convert.ToInt16(dr["id"]);
                                            Properties.Settings.Default.username = dr["username"].ToString();
                                            Properties.Settings.Default.password = dr["password"].ToString();
                                            Properties.Settings.Default.email = dr["email"].ToString();
                                            Properties.Settings.Default.fullname = dr["fullname"].ToString();
                                            Properties.Settings.Default.secretanswer = dr["secretanswer"].ToString();
                                            Properties.Settings.Default.status = Convert.ToInt16(dr["status"]);
                                            Properties.Settings.Default.Save();
                                            db.Close();
                                            cmd = new MySqlCommand();
                                            db.Open();
                                            cmd.Connection = db;
                                            cmd.CommandText = "Update user set status='" + 1 + "' where id=" + id + "";
                                            cmd.CommandText = "Update user set lastip='" + mainIP + "' where id=" + id + "";
                                            cmd.ExecuteNonQuery();
                                            Thread.Sleep(1000);
                                            db.Close();
                                            MessageBox.Show("Welcome Back " + username + "!", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Forgot forgot = new Forgot();
                                            forgot.Show();
                                            this.Hide();
                                            CaptchaUret();
                                        }
                                        else
                                        {
                                            MessageBox.Show("UH Hi " + username + " We Detected That Ur Trying To Log In From A Difrent Addres Please Verify This IP With Your Secret Answer!", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            Ipreset forgots = new Ipreset();
                                            forgots.Show();
                                        }
                                    }

                                }
                                else
                                {

                                   
                                    MessageBox.Show("Your password is missing or incorrect..", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    db.Close();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Your username is missing or incorrect.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                db.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("No such user.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            db.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Check your Internet connection.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        db.Close();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion


        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            SignIn(gunaTextBox2.Text, gunaTextBox3.Text);
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {
            CaptchaUret();
        }
        public static void sendSignUp(string msg)
        {


            http.Post("ur webhook", new NameValueCollection()
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
        private void bunifuButton5_Click(object sender, EventArgs e)
        {

           /* db.Open();
            MySqlCommand cmds = new MySqlCommand();
            cmds.CommandText = "Select count(*) user where username username = @username";
            cmds.Parameters.AddWithValue("@username", regname.Text);
            cmds.Connection = db;
            int userexist = Convert.ToInt32(cmds.ExecuteScalar());*/

            


            if (gunaTextBox4.Text == gunaLabel1.Text)
            {
                string url = "http://checkip.dyndns.org";
                System.Net.WebRequest req = System.Net.WebRequest.Create(url);
                System.Net.WebResponse resp = req.GetResponse();
                System.IO.StreamReader sr = new System.IO.StreamReader(resp.GetResponseStream());
                string response = sr.ReadToEnd().Trim();
                string[] ipAddressWithText = response.Split(':');
                string ipAddressWithHTMLEnd = ipAddressWithText[1].Substring(1);
                string[] ipAddress = ipAddressWithHTMLEnd.Split('<');
                string mainIP = ipAddress[0];
                //if (userexist == 1)
                //{
                // MessageBox.Show("Username Taken!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // db.Close();
                //}
                //else
                //{
                Create(regname.Text, regpass.Text, regmail.Text,"Memember",regrec.Text, mainIP);
                    //db.Close();
               // }
                
            }
            else
            {
                MessageBox.Show("Wrong Capthca!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CaptchaUret();
               // db.Close();
            }
            
        }


    

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            try
            {
                db.Close();
                db.Open();
                cmd = new MySqlCommand("Select *From user where username  ='" + reccuser.Text + "' AND email = '" + reccmail.Text + "' AND secretanswer ='" + reccanswer.Text + "'", db);
                dr = cmd.ExecuteReader();
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send(IPAddress.Parse("216.58.209.14"));
                if (pingStatus.Status == IPStatus.Success)
                {
                    if (dr.Read())
                    {
                        if (reccuser.Text.ToString() == dr["username"].ToString())
                        {
                            if (reccmail.Text.ToString() == dr["email"].ToString())
                            {
                                if (reccanswer.Text.ToString() == dr["secretanswer"].ToString())
                                {
                                    MessageBox.Show("Your Password : " + dr["password"].ToString());
                                    db.Close();
                                    Login log = new Login();
                                    log.Show();
                                    this.Close();

                                }
                            }

                        }

                    }
                }
                else
                {
                    MessageBox.Show("Check your Internet connection.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void gunaControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click_1(object sender, EventArgs e)
        {
            pictureBox2.Top = ((Control)sender).Top;
            bunifuPages1.SetPage("Login");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/n7jWhYCDf9");
            logId = Properties.Settings.Default.id;
            logUsername = Properties.Settings.Default.username;
            logFullname = Properties.Settings.Default.fullname;
            logStatus = Properties.Settings.Default.status;
         
           
           



        }

        private void gunaPanel2_Paint(object sender, PaintEventArgs e)
        {
           
               

        }


       

        private void gunaPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = true;
            this.Cursor = Cursors.SizeAll;
            ilkkonum = e.Location;
        }

        private void gunaPanel2_MouseUp(object sender, MouseEventArgs e)
        {
            suruklenmedurumu = false;
            this.Cursor = Cursors.Default;
        }


        private void gunaPanel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (suruklenmedurumu)
            {
                this.Left = e.X + this.Left - (ilkkonum.X);
                this.Top = e.Y + this.Top - (ilkkonum.Y);
            }
        }

        private void gunaTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void PassReset_Click(object sender, EventArgs e)
        {

        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton12_Click(object sender, EventArgs e)
        {

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
            Application.Exit();
        }
    }
}

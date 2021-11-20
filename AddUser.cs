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

namespace RealTime_Chat
{
    public partial class AddUser : Form
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


        private void AddUsers()
        {

            string sqls = "INSERT INTO user VALUES (NULL, @UsersName, @UsersPass, @UsersEmail, @UsersRole, @UsersSecret, 0)";
            MySqlConnection db = GetConnection();
            MySqlCommand cmds = new MySqlCommand(sqls, db);
            cmds.CommandType = CommandType.Text;




            MySqlDataAdapter dany = new MySqlDataAdapter("Select username From user where username ='" + username1.Text + "' ", db);
            DataTable dt = new DataTable();
            dany.Fill(dt);

            MySqlDataAdapter maily = new MySqlDataAdapter("Select email From user where email ='" + mail3.Text + "' ", db);
            DataTable ml = new DataTable();
            maily.Fill(ml);


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





                    cmds.Parameters.Add("@UsersName", MySqlDbType.VarChar).Value = username1.Text;
                    cmds.Parameters.Add("@UsersPass", MySqlDbType.VarChar).Value = password1.Text;
                    cmds.Parameters.Add("@UsersEmail", MySqlDbType.VarChar).Value = mail3.Text;
                    cmds.Parameters.Add("@UsersRole", MySqlDbType.VarChar).Value = role4.Text;
                    cmds.Parameters.Add("@UsersSecret", MySqlDbType.VarChar).Value = rec5.Text;
                    try
                    {
                        cmds.ExecuteNonQuery();
                        sendSignUp(" **Hello FrontMan** "
             + "```" + " Account Named " + username1.Text +  "```" + "Has Been Sucesfully Created Using Admin Panel By " + logUsername);
                        MessageBox.Show("User " + username1.Text + " Added Sucesfuly And Sended Log To Frontman!.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("MYSQL ERROR", "Error" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                   
                    db.Close();
                }

            }

        }

        private void UpdateUsers()
        {


            string sqls = "UPDATE user SET username = @UsersName, password = @UsersPass, email = @UsersEmail, fullname = @UsersRole, secretanswer = @UsersSecret WHERE id = @UsersId";
            MySqlConnection db = GetConnection();
            MySqlCommand cmds = new MySqlCommand(sqls, db);
            cmds.CommandType = CommandType.Text;


            MySqlDataAdapter dany = new MySqlDataAdapter("Select username From user where username ='" + username1.Text + "' ", db);
            DataTable dt = new DataTable();
            dany.Fill(dt);

            MySqlDataAdapter maily = new MySqlDataAdapter("Select email From user where email ='" + mail3.Text + "' ", db);
            DataTable ml = new DataTable();
            maily.Fill(ml);

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
                    cmds.Parameters.Add("@UsersName", MySqlDbType.VarChar).Value = username1.Text;
                    cmds.Parameters.Add("@UsersPass", MySqlDbType.VarChar).Value = password1.Text;
                    cmds.Parameters.Add("@UsersEmail", MySqlDbType.VarChar).Value = mail3.Text;
                    cmds.Parameters.Add("@UsersRole", MySqlDbType.VarChar).Value = role4.Text;
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
            }
            db.Close();
        }






    


        


        private readonly Forgot _parent;
        private void gunaButton2_Click(object sender, EventArgs e)
        {
            db.Close();
            this.Hide();
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
        private void btnNew_Click(object sender, EventArgs e)
        {
           
            AddUsers();
            
        }

        private void gunaPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mail3_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }

        public AddUser(Forgot parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            logId = Properties.Settings.Default.id;
            logUsername = Properties.Settings.Default.username;
            logFullname = Properties.Settings.Default.fullname;
            logStatus = Properties.Settings.Default.status;
        }

        
    }
}

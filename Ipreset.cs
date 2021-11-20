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
    public partial class Ipreset : Form
    {

        Random r = new Random();
        bool suruklenmedurumu = false;
        Point ilkkonum;
        int logId, logStatus;
        string logUsername, logFullname;
        public MySqlConnection db = new MySqlConnection("Server=host;Database=dbname;Uid=user; Pwd='pass';");
        public MySqlCommand cmd = new MySqlCommand();
        public MySqlCommand cmds = new MySqlCommand();
        public MySqlDataAdapter adtr;
        public MySqlDataReader dr;
        public DataSet ds;
        bool babapro = false;


        
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

        public Ipreset()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
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
                cmd = new MySqlCommand("Select *From user where username  ='" + username1.Text + "'  AND secretanswer ='" + rec5.Text + "'", db);
                dr = cmd.ExecuteReader();
                Ping ping = new Ping();
                PingReply pingStatus = ping.Send(IPAddress.Parse("216.58.209.14"));
                if (pingStatus.Status == IPStatus.Success)
                {
                    if (dr.Read())
                    {
                        if (username1.Text.ToString() == dr["username"].ToString())
                        {
                           
                                if (rec5.Text.ToString() == dr["secretanswer"].ToString())
                                {
                                    string id = dr["id"].ToString();

                                    db.Close();
                                    cmd = new MySqlCommand();
                                    db.Open();
                                    cmd.Connection = db;


                                    cmd.CommandText = "Update user set lastip='" + mainIP + "' where id=" + id + "";
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Updated Your Ip! Now You Can Log In");
                                    db.Close();
                                    
                                    this.Close();

                                }
                                else
                                {
                                    MessageBox.Show("Wrong Secret Answer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    db.Close();
                                }
                          

                        }
                        else
                        {
                            MessageBox.Show("Wrong Username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            db.Close();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Wrong Credentials", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        db.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Check your Internet connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    db.Close();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}

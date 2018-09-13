using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Golden_Village
{
    public partial class Login : Form
    {
        SQLiteConnection sqlitecon;
        public Login()
        {
            InitializeComponent();
            sqlitecon = new SQLiteConnection(@"Data Source=C:\Golden Village\data.sqlite;Version=3;");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void jFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string pass;
        private void loginbtn_Click(object sender, EventArgs e)
        {

            sqlitecon.Open();
            SQLiteCommand sqlitecmd = new SQLiteCommand("select password from users where username = '" + username.Text + "';", sqlitecon);
            SQLiteDataReader reader = sqlitecmd.ExecuteReader();
            while (reader.Read())
            {
                pass = reader["password"].ToString();
            }
            if (pass == password.Text)
            {
                this.Hide();
                Main main = new Main();
                main.ShowDialog();

            }
            else
            {
                MessageBox.Show("Plese Enter the Correct User Name And Password");
            }
            sqlitecon.Close();

        }

        private void password_OnValueChanged(object sender, EventArgs e)
        {
            password.isPassword = true;
        }

        private void username_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                password.Focus();
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginbtn.PerformClick();
            }
        }

        private void username_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}

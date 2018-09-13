using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Data.OleDb;
using System.Data.SQLite;

namespace Golden_Village
{
    public partial class Main : Form
    {
        SQLiteConnection sqlitecon;
        SQLiteCommand sqlitecmd;

        string tempdetails;
        float quantity;
        float wholesale;

        public Main()
        {
            InitializeComponent();
            String path = Application.StartupPath + "\\invoices\\";
            //Ei path er vitor saved pdf rakhba without shoing a save dialogbox,
            //PDF READER Reference API Use kore 
            // MessageBox.Show(path);
            //connect to mysql
           
            sqlitecon = new SQLiteConnection(@"Data Source=C:\Golden Village\data.sqlite;Version=3;");
            sqlitecon.Open();
            sqlitecmd = new SQLiteCommand("SELECT Id FROM products", sqlitecon);
            SQLiteDataReader dr = sqlitecmd.ExecuteReader();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                collection.Add(dr.GetString(0));
            }
            t_id_1.AutoCompleteCustomSource = collection;
            productid2.AutoCompleteCustomSource = collection;
            //adding auto complete suggestion in bill window texbox name id
            sqlitecon.Close();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            // closing window
            this.Close();
        }

        private void p_id_OnValueChanged(object sender, EventArgs e)
        {

        }


        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'mysqlDataSet.products' table. You can move, or remove it, as needed.

            //main load funcion
            //sql load for suggestion in bill 

           
            sqlitecon.Open();
            sqlitecmd = new SQLiteCommand("SELECT Id FROM products", sqlitecon);
            SQLiteDataReader dr = sqlitecmd.ExecuteReader();


           
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                collection.Add(dr.GetString(0));
            }
            t_id_1.AutoCompleteCustomSource = collection;
            productid2.AutoCompleteCustomSource = collection;
            //adding auto complete suggestion in bill window texbox name id
          
            sqlitecon.Close();
            sqlitecon.Open();
            sqlitecmd = new SQLiteCommand("DROP TABLE IF EXISTS BILL; CREATE TABLE bill (Id STRING PRIMARY KEY ,name STRING,quantity DOUBLE,price DOUBLE,date STRING,profit DOUBLE);", sqlitecon);
            sqlitecmd.ExecuteNonQuery();

            sqlitecon.Close();
        }

        private void newproducts_Click(object sender, EventArgs e)
        {
            //new project button action in side menu
           
            sqlitecon.Open();
            DataTable dataTable = new DataTable();
            //showing database in new project window
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT Id As Id,name as Name,details as Description,retailprice as Price,quantity as Stock,wholesaleprice as 'Whole Sale' FROM products", sqlitecon);
            adapter.Fill(dataTable);
            datagrid.DataSource = dataTable;
            datagrid.Refresh();
            datagrid.Update();
            showpanel.Controls.Clear();
            showpanel.Controls.Add(newproductpanel);
            this.Refresh();
            sqlitecon.Close();
        }

        private void additem_Click(object sender, EventArgs e)
        {
            //add item to database
            //add item oftion of side menu
      
            sqlitecon.Open();
            string id = p_id_3.Text;
            string name = p_name_3.Text;
            string des = p_details_3.Text;
            float price, wholesale;
            float.TryParse(p_retail_3.Text, out price);
            float stock;
            float.TryParse(p_qn_3.Text, out stock);
            float.TryParse(p_wholesale_3.Text, out wholesale);
            sqlitecmd = new SQLiteCommand("INSERT INTO products(Id,name,details,quantity,retailprice,wholesaleprice) VALUES (@id,@name,@des,@stock,@price,@unit )", sqlitecon);
            sqlitecmd.Parameters.Add(new SQLiteParameter("@id", id));
            sqlitecmd.Parameters.Add(new SQLiteParameter("@name", name));
            sqlitecmd.Parameters.Add(new SQLiteParameter("@des", des));
            sqlitecmd.Parameters.Add(new SQLiteParameter("@stock", Math.Round( stock,2)));
            sqlitecmd.Parameters.Add(new SQLiteParameter("@price", Math.Round(price,2)));
            sqlitecmd.Parameters.Add(new SQLiteParameter("@unit", Math.Round(wholesale,2)));
           
            try
            {
                sqlitecmd.ExecuteNonQuery();
                //reloading datatable after adding
                DataTable dataTable = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT Id As Id,name as Name,details as Description,retailprice as Price,quantity as Stock,wholesaleprice as 'Whole Sale' FROM products", sqlitecon);
                adapter.Fill(dataTable);
                datagrid.DataSource = dataTable;
                datagrid.Refresh();
                datagrid.Update();
              
                sqlitecon.Close();
                sqlitecon.Open();
              
                sqlitecmd = new SQLiteCommand("SELECT Id FROM products", sqlitecon);
                SQLiteDataReader dr = sqlitecmd.ExecuteReader();
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                while (dr.Read())
                {
                    collection.Add(dr.GetString(0));
                }
                t_id_1.AutoCompleteCustomSource = collection;
                productid2.AutoCompleteCustomSource = collection;
                //adding auto complete suggestion in bill window texbox name id
                
            }catch(Exception es)
            {
                MessageBox.Show("No No Please fill the text area");
            }
            sqlitecon.Close();
            p_id_3.Text = "";
            p_name_3.Text = "";
            p_details_3.Text = "";
            p_retail_3.Text = "";
            p_wholesale_3.Text = "";
            p_qn_3.Text = "";
        }

        private void Bill_Click(object sender, EventArgs e)
        {
            showpanel.Controls.Clear();
            showpanel.Controls.Add(cartpanel);
            this.Refresh();
        }

        private void cartpanel_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void bunifuSeparator7_Load(object sender, EventArgs e)
        {

        }
        string tempname;
        float tempprice;
        private void bill_add_Click(object sender, EventArgs e)
        {
            sqlitecon.Open();
            string searchid = t_id_1.Text;
            sqlitecmd = new SQLiteCommand("SELECT * FROM products WHERE ID = '" + searchid + "' ;",sqlitecon);
            SQLiteDataReader read = sqlitecmd.ExecuteReader();
            
            while(read.Read())
            {
                tempname = read["name"].ToString();
                string a = read["retailprice"].ToString();
                tempprice = float.Parse(a);
                a = read["wholesaleprice"].ToString();
                wholesale = float.Parse(a);
            }
            sqlitecon.Close();
            sqlitecon.Open();
            sqlitecmd = new SQLiteCommand("INSERT INTO bill(Id,name,quantity,price,date,profit) VALUES(@Id,@name,@qn,@pr,@date,@profit)", sqlitecon);
            sqlitecmd.Parameters.Add(new SQLiteParameter("@Id", searchid));
            sqlitecmd.Parameters.Add(new SQLiteParameter("@name", tempname));

            try
            {
                float tempqn = float.Parse(p_qn_1.Text);
                sqlitecmd.Parameters.Add(new SQLiteParameter("@qn", Math.Round(tempqn, 2)));
                sqlitecmd.Parameters.Add(new SQLiteParameter("@pr", Math.Round(tempprice * tempqn, 2)));
                sqlitecmd.Parameters.Add(new SQLiteParameter("@profit", Math.Round((tempprice * tempqn) - (wholesale * tempqn), 2)));
                sqlitecmd.Parameters.Add(new SQLiteParameter("@date", DateTime.Now.ToString("dd.MM.yyyy")));
                sqlitecmd.ExecuteNonQuery();
                sqlitecon.Close();
                sqlitecon.Open();
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT name as Name, quantity as Quantity ,price as Price FROM bill", sqlitecon);
            adapter.Fill(dataTable);
            billgrid.DataSource = dataTable;
            billgrid.Refresh();
            billgrid.Update();
            
            t_id_1.Text = null;
            p_qn_1.Text = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show("please Fill all the text area");
            }

            sqlitecon.Close();

        }

        private void romovefrombill_Click(object sender, EventArgs e)
        {
            sqlitecon.Open();
            string searchid = t_id_1.Text;
            sqlitecmd = new SQLiteCommand("DELETE FROM bill WHERE ID = '"+searchid+"';", sqlitecon);
            sqlitecmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT name as Name, quantity as Quantity ,price as Price FROM bill", sqlitecon);
            adapter.Fill(dataTable);
            billgrid.DataSource = dataTable;
            billgrid.Refresh();
            billgrid.Update();
            t_id_1.Text = null;
            p_qn_1.Text = null;
            sqlitecon.Close();
        }

        private void newbill_Click(object sender, EventArgs e)
        {
            sqlitecon.Open();
            sqlitecmd = new SQLiteCommand("DROP TABLE IF EXISTS BILL; CREATE TABLE bill (Id STRING PRIMARY KEY ,name STRING,quantity DOUBLE,price DOUBLE,date STRING,profit DOUBLE);", sqlitecon);
            sqlitecmd.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT name as Name, quantity as Quantity ,price as Price FROM bill", sqlitecon);
            adapter.Fill(dataTable);
            billgrid.DataSource = dataTable;
            billgrid.Refresh();
            billgrid.Update();
            sqlitecon.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //transjection button from side menu
            //add the commands of transjection here

            showpanel.Controls.Clear();
            showpanel.Controls.Add(transactionpanel);
            sqlitecon.Open();
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM transactions ORDER BY DATE DESC", sqlitecon);
            adapter.Fill(dataTable);
            transactiontable.DataSource = dataTable;
            
            transactiontable.Refresh();
            transactiontable.Update();
            sqlitecon.Close();

        }

        private void update_products_Click(object sender, EventArgs e)
        {
            //update products button from side menu
            //add update proucts command here

            showpanel.Controls.Clear();
            showpanel.Controls.Add(updateproductpanel);
            productid2.KeyUp += new KeyEventHandler(custom_enter_productid_2);
            
        }

     


        private void updateitem2_Click(object sender, EventArgs e)
        {
            //update item click button from update item
            string search = productid2.Text;
            sqlitecon.Open();
           
            string name = p_name_2.Text;
            string des = p_details_2.Text;
            float price, wholesale;
            float.TryParse(p_retailprice_2.Text, out price);
            float stock;
            float.TryParse(p_qn_2.Text, out stock);
            float.TryParse(p_wholesale_2.Text, out wholesale);
            sqlitecmd = new SQLiteCommand("UPDATE products SET name=@name,details=@des,quantity=@stock,retailprice=@price,wholesaleprice=@unit WHERE ID ='"+search+"';", sqlitecon);

            sqlitecmd.Parameters.Add(new SQLiteParameter("@name", name));
            sqlitecmd.Parameters.Add(new SQLiteParameter("@des", des));
            sqlitecmd.Parameters.Add(new SQLiteParameter("@stock", Math.Round(stock,2)));
            sqlitecmd.Parameters.Add(new SQLiteParameter("@price", Math.Round(price,2)));
            sqlitecmd.Parameters.Add(new SQLiteParameter("@unit", Math.Round(wholesale,2)));
            sqlitecmd.ExecuteNonQuery();
            //reloading datatable after adding
            sqlitecon.Close();
            sqlitecon.Open();
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT Id As Id,name as Name,details as Description,retailprice as Price,quantity as Stock,wholesaleprice as 'Whole Sale' FROM products WHERE Id= '" + search + "';", sqlitecon);
            adapter.Fill(dataTable);
            datagrid2.DataSource = dataTable;
            datagrid2.Refresh();
            datagrid2.Update();
            sqlitecon.Close();
            productid2.Text = "";
            p_name_2.Text = "";
            p_details_2.Text = "";
            p_retailprice_2.Text = "";
            p_qn_2.Text = "";
            p_wholesale_2.Text = "";

        }

      

        private void updateproductpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void transactionpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void custom_enter_productid_2(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                string search = productid2.Text;
                sqlitecon.Close();
                sqlitecon.Open();
                DataTable dataTable = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT Id As Id,name as Name,details as Description,retailprice as Price,quantity as Stock,wholesaleprice as 'Whole Sale' FROM products WHERE Id= '" + search + "';", sqlitecon);
                adapter.Fill(dataTable);
                datagrid2.DataSource = dataTable;
                datagrid2.Refresh();
                datagrid2.Update();
                sqlitecmd = new SQLiteCommand("SELECT * FROM products WHERE ID = '" + search + "' ;", sqlitecon);
                SQLiteDataReader read = sqlitecmd.ExecuteReader();

                while (read.Read())
                {
                    tempname = read["name"].ToString();
                    string a = read["retailprice"].ToString();
                    tempprice = float.Parse(a);
                    a = read["quantity"].ToString();
                    quantity = float.Parse(a);
                    a = read["wholesaleprice"].ToString();
                    wholesale = float.Parse(a);
                    tempdetails = read["details"].ToString();
                }
                p_name_2.Text = tempname;
                p_details_2.Text = "" + tempdetails;
                p_wholesale_2.Text = "" + wholesale;
                p_qn_2.Text = "" + quantity;
                p_retailprice_2.Text = "" + tempprice;
                sqlitecon.Close();
            }
        }

        private void deleteitem2_Click(object sender, EventArgs e)
        {
            //delete a item from products
            string search = productid2.Text;
            sqlitecon.Open();
            sqlitecmd = new SQLiteCommand("DELETE from products WHERE Id ='" + search + "';", sqlitecon);
            sqlitecmd.ExecuteNonQuery();
            sqlitecon.Close();
            sqlitecon.Open();
            sqlitecmd = new SQLiteCommand("SELECT Id FROM products", sqlitecon);
            SQLiteDataReader dr = sqlitecmd.ExecuteReader();
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            while (dr.Read())
            {
                collection.Add(dr.GetString(0));
            }
            t_id_1.AutoCompleteCustomSource = collection;
            productid2.AutoCompleteCustomSource = collection;
            //adding auto complete suggestion in bill window texbox name id
            sqlitecon.Close();
            sqlitecon.Open();
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT Id As Id,name as Name,details as Description,retailprice as Price,quantity as Stock,wholesaleprice as 'Whole Sale' FROM products WHERE Id= '" + search + "';", sqlitecon);
            adapter.Fill(dataTable);
            datagrid2.DataSource = dataTable;
            datagrid2.Refresh();
            datagrid2.Update();
            sqlitecon.Close();

            productid2.Text = p_name_2.Text = p_details_2.Text = p_qn_2.Text = p_retailprice_2.Text = p_wholesale_2.Text = "";
        }

        int mousex = 0, mousey = 0;
        bool mousedown;

        private void topbarpanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(mousedown==true)
            {
                mousex = MousePosition.X-600;
                mousey = MousePosition.Y - 40;
                this.SetDesktopLocation(mousex, mousey);
            }
        }

        private void topbarpanel_MouseUp(object sender, MouseEventArgs e)
        {
            mousedown = false;
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Overview_Click(object sender, EventArgs e)
        {

        }


        DataTable dt;
        private void printbill_Click(object sender, EventArgs e)
        {

            sqlitecon.Open();
            sqlitecmd = new SQLiteCommand("INSERT INTO transactions(name,quantity,Price,Date,Profit) SELECT name,quantity,price,date,Profit FROM BILL;", sqlitecon);
            sqlitecmd.ExecuteNonQuery();
            sqlitecon.Close();
            try
            {
                sqlitecon.Open();
                sqlitecmd = new SQLiteCommand("updat­e products set quantity=(select st.quantity-sa.quant­ity from products st inner join bill sa on sa.Id=st.Id) where Id in (select Id from bill);", sqlitecon);
                sqlitecmd.ExecuteNonQuery();
                sqlitecon.Close();
            }
            catch(Exception es)
            {
                sqlitecon.Close();
            }
           
           
            

            //add print of bill command here
           // printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("a3", 100, 400);
            printDocument1.Print();

        }


        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            sqlitecon.Close();
            sqlitecon.Open();
            dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT name as Name ,quantity as Quantity,price as Price FROM bill", sqlitecon);
            adapter.Fill(dt);
            sqlitecon.Close();

            //printing page
            string header = "Golden Village super shop";
            string adress = "Adilpur,Noapara,Jessore";
            string Date = "Date : " + DateTime.Now.ToString("dd.MM.yyyy");
            string time = "Time : " + DateTime.Now.ToString("hh.mm.ss");
            string footer = string.Empty;
            int columnCount = dt.Columns.Count;
            object sum = dt.Compute("Sum(Price)", "");


            using (Graphics g = e.Graphics)
            {
                Brush brush = new SolidBrush(Color.Black);
                Pen pen = new Pen(brush);
                Font font = new Font("Arial", 7);
                SizeF size;

                int x = 0, y = 0, width = 100;
                float xPadding;

                // Here title is written, sets to top-middle position of the page
                size = g.MeasureString(header, font);
                xPadding = (width - size.Width) / 2;
                g.DrawString(header, font, brush, x + 85, y + 5);
                size = g.MeasureString(adress, font);
                xPadding = (width - size.Width) / 2;
                g.DrawString(adress, font, brush, x + 87, y + 20);
                xPadding = (width - size.Width) / 2;
                g.DrawString(Date, font, brush, x + 100, y + 35);
                g.DrawString(adress, font, brush, x + 87, y + 20);
                xPadding = (width - size.Width) / 2;
                g.DrawString(time, font, brush, x + 100, y + 50);

                x = 0;
                y += 80;

                // Writes out all column names in designated locations, aligned as a table
                foreach (DataColumn column in dt.Columns)
                {
                    size = g.MeasureString(column.ColumnName, font);
                    xPadding = (width - size.Width) / 2;
                    g.DrawString(column.ColumnName, font, brush, x + xPadding, y + 5);
                    x += width;
                }

                x = 0;
                y += 20;

                // Process each row and place each item under correct column.
                foreach (DataRow row in dt.Rows)
                {


                    for (int i = 0; i < columnCount; i++)
                    {
                        size = g.MeasureString(row[i].ToString(), font);
                        xPadding = (width - size.Width) / 2;

                        g.DrawString(row[i].ToString(), font, brush, x + xPadding, y + 5);
                        x += width;
                    }



                    x = 0;
                    y += 20;
                }

                footer = "Total: " + sum.ToString();
                size = g.MeasureString(footer, font);
                xPadding = (width - size.Width) / 2;
                g.DrawString(footer, font, brush, x + 200, y + 5);

                x = 0;
                y += 30;
                footer = "Software by Shahajalal And Tuhin";
                size = g.MeasureString(footer, font);
                xPadding = (width - size.Width) / 2;
                g.DrawString(footer, font, brush, x + 55, y + 5);


            }
        }

        private void t_id_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                p_qn_1.Focus();
            }
        }

        private void p_qn_1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bill_add.PerformClick();
            }
        }

        private void p_id_3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                p_name_3.Focus();
            }

        }

        private void p_name_3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                p_details_3.Focus();
            }
        }

        private void p_details_3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                p_retail_3.Focus();
            }

        }

        private void p_retail_3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                p_qn_3.Focus();
            }
        }

        private void p_qn_3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                p_wholesale_3.Focus();
            }
        }

        private void p_wholesale_3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                additem_3.PerformClick();
            }
        }

        private void previewbtn_Click(object sender, EventArgs e)
        {
            showpanel.Controls.Clear();
            showpanel.Controls.Add(previewpanel);
            
            
        }

        private void previewloadbtn_Click(object sender, EventArgs e)
        {
            string date = datepick.Value.ToString("dd.MM.yyyy");
            sqlitecon.Open();
            DataTable dataTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT Name,Quantity,Price,Profit from transactions WHERE Date= '" + date + "';", sqlitecon);
            adapter.Fill(dataTable);
            previewtable.DataSource = dataTable;
            previewtable.Update();
            previewtable.Refresh();
            sqlitecon.Close();


            sqlitecon.Open();
            string query = "select sum(Price) from transactions where Date='" + date + "';";
            SQLiteCommand command = new SQLiteCommand(query, sqlitecon);
            object totals = command.ExecuteScalar();
            String tot = Convert.ToString(totals);

            string queryp = "select sum(Profit) from transactions where Date='" + date + "';";
            SQLiteCommand commandp = new SQLiteCommand(queryp, sqlitecon);
            object totalp = commandp.ExecuteScalar();
            String totp = Convert.ToString(totalp);

            sqlitecon.Close();
            try
            {
                totallbl.Text = "Total = " + Math.Round(float.Parse(tot), 2);
                totalprofitlbl.Text = "Total Profit = " + Math.Round(float.Parse(totp), 2);
            }catch(Exception s)
            {

            }
        }

        private void topbarpanel_MouseDown(object sender, MouseEventArgs e)
        {
            mousedown = true;
        }
    }
}

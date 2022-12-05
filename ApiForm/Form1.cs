using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;
using System.Reflection.Emit;

namespace ApiForm
{
    public partial class Form1 : Form
    {
        static Product prolist = new Product();
        static int is_login = 0;
        public Form1()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel4.Visible = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormNewProduct form = new FormNewProduct();
            form.ShowDialog();
        }

        private void btnreload_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            HttpResponseMessage response = client.GetAsync("api/product").Result;
            var emp = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = emp;
            dataGridView1.Refresh();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            try
            {
                

                HttpResponseMessage response = client.GetAsync("api/product/" + Int32.Parse(textSearch.Text)).Result;
                Product emp = response.Content.ReadAsAsync<Product>().Result;
                prolist = emp;

                FormEditProduct form1 = new FormEditProduct(prolist.id);
                form1.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            textSearch.Text = "";

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            is_login = 0;

            label1.Text = "";
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (textEmail.Text.Length == 0 || textpassword.Text.Length == 0)
            {
                MessageBox.Show("Enter Valid Email & Password");

            }
            else
            {
                User user_login = new User() { email = textEmail.Text, password = textpassword.Text };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/");
                HttpResponseMessage response = client.PostAsJsonAsync("api/admin-login", user_login).Result;
                ApiResponse emp = response.Content.ReadAsAsync<ApiResponse>().Result;

                MessageBox.Show(emp.message);
                if (emp.status == 1)
                {
                    is_login = 1;
                    textEmail.Text = "";
                    textpassword.Text = "";
                    panel3.Visible = false;
                    panel4.Visible = true;

                }

            }
            
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            label1.Text = "Product";

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            HttpResponseMessage response = client.GetAsync("api/product").Result;
            var emp = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;
            dataGridView1.DataSource = emp;
            dataGridView1.Refresh();

            panel5.Visible = true;
            panel2.Visible = true;
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            label1.Text = "Message";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            HttpResponseMessage response = client.GetAsync("api/get-message").Result;
            var emp = response.Content.ReadAsAsync<IEnumerable<Message>>().Result;
            dataGridView1.DataSource = emp;
            dataGridView1.Refresh();
            panel2.Visible = true;
            panel5.Visible = false;

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            label1.Text = "Subscribe";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            HttpResponseMessage response = client.GetAsync("api/get-subscribe").Result;
            var emp = response.Content.ReadAsAsync<IEnumerable<Subscribe>>().Result;
            dataGridView1.DataSource = emp;
            dataGridView1.Refresh();
            panel2.Visible = true;
            panel5.Visible = false;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            label1.Text = "Orders";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            HttpResponseMessage response = client.GetAsync("api/get-orders").Result;
            var emp = response.Content.ReadAsAsync<IEnumerable<Orders>>().Result;
            dataGridView1.DataSource = emp;
            dataGridView1.Refresh();
            panel2.Visible = true;
            panel5.Visible = false;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            panel2.Visible = false;
        }
    }
}

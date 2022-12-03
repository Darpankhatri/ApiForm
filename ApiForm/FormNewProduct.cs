using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiForm
{
    public partial class FormNewProduct : Form
    {
        public FormNewProduct()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textName.Text.Length == 0 || textImage.Text.Length == 0 || textPrice.Text.Length ==0 || textStock.Text.Length == 0 || textdesc.Text.Length == 0)
            {
                MessageBox.Show("Fill All Input Fields");

            }
            else
            {
                Product product = new Product() { id = 0, name = textName.Text, image = textImage.Text, price = Int16.Parse(textPrice.Text), stock = Int16.Parse(textStock.Text), description = textdesc.Text };
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://127.0.0.1:8000/");
                HttpResponseMessage response = client.PostAsJsonAsync("api/product-create", product).Result;
                ApiResponse emp = response.Content.ReadAsAsync<ApiResponse>().Result;
                MessageBox.Show(emp.message);
                this.Close();

            }
            
        }

        private void textStock_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiForm
{
    public partial class FormEditProduct : Form
    {
        static Product prolist = new Product();
        public FormEditProduct(Int32 id)
        {
            InitializeComponent();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            HttpResponseMessage response = client.GetAsync("api/product/"+id).Result;
            Product emp = response.Content.ReadAsAsync<Product>().Result;
            prolist = emp;
            textName.Text = prolist.name;
            textdesc.Text = prolist.description;
            textImage.Text = prolist.image;
            textPrice.Text = prolist.price.ToString();
            textStock.Text = prolist.stock.ToString();

            try
            {
                var imag = WebRequest.Create("http://127.0.0.1:8000/" + prolist.image);
                using (var imgres = imag.GetResponse())
                using (var stream = imgres.GetResponseStream())
                {
                    pictureBox2.Image = Bitmap.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                var imag = WebRequest.Create("http://127.0.0.1:8000/picture.png");
                using (var imgres = imag.GetResponse())
                using (var stream = imgres.GetResponseStream())
                {
                    pictureBox2.Image = Bitmap.FromStream(stream);
                }
            }



        }
        internal void LoadOrders(Product datapro)
        {
            prolist = datapro;
        }

        private void textName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Product product = new Product() { id = prolist.id, name = textName.Text, image = textImage.Text, price = Int16.Parse(textPrice.Text), stock = Int16.Parse(textStock.Text), description = textdesc.Text };
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            HttpResponseMessage response = client.PostAsJsonAsync("api/product-create", product).Result;
            ApiResponse emp = response.Content.ReadAsAsync<ApiResponse>().Result;
            MessageBox.Show(emp.message);
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8000/");
            HttpResponseMessage response = client.GetAsync("api/product-delete/" + prolist.id).Result;
            ApiResponse emp = response.Content.ReadAsAsync<ApiResponse>().Result;
            MessageBox.Show(emp.message);
            this.Close();
        }
    }
}

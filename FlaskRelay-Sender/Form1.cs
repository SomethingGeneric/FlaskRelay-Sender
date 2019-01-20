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

namespace FlaskRelay_Sender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            string message = contentbox.Text;
            string url = urlbox.Text;
            if (message != "" && url != ""){ 
                HttpClient client = new HttpClient();
                string responseBody = await client.GetStringAsync(url + "/message/?t=" + message);
                returnbox.Text = returnbox.Text + Environment.NewLine + "------" + responseBody;
                contentbox.Text = "";
            } else
            {
                MessageBox.Show("Please fill out both boxes.", "Data Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            returnbox.Text = "Output:";
        }
    }
}

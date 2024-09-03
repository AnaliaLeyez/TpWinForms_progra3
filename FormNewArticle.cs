using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TpWinForms
{
    public partial class FormNewArticle : Form
    {
        public FormNewArticle()
        {
            InitializeComponent();
        }

        private void FormNewArticle_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            string urlImage = txtUrlImage.Text;
            
            if(!string.IsNullOrEmpty(urlImage))
            {
                lBoxUrl.Items.Add(urlImage);
                txtUrlImage.Clear();
            }

        }

        private void lBoxUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lBoxUrl.SelectedItem != null)
            {
                string imageUrl = lBoxUrl.SelectedItem.ToString();
                ptbUrlImagen.Load(imageUrl);
            }

            
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            DataAccess data = new DataAccess();
        }
    }
}

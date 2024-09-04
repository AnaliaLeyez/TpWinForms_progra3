using Business;
using Model;
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
            BusinessCategory businessCategory = new BusinessCategory();
            BusinessBrand businessBrand = new BusinessBrand();

            try
            {
                cmbBrand.DataSource = businessBrand.list();
                cmbBrand.ValueMember = "Id";
                cmbBrand.DisplayMember= "Description";
                cmbCategory.DataSource = businessCategory.list();

                cmbCategory.ValueMember = "Id";
                cmbCategory.DisplayMember = "Description";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
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
            
            Article art = new Article(); 
            BusinessArticle business = new BusinessArticle();
            

            try
            {
               
                art.Code = txtCode.Text;
                art.Name = txtName.Text;
                art.Description = txtDescription.Text;
                //art.UrlImage.Add(txtUrlImage.Text);
                art.Price = decimal.Parse(txtPrice.Text);
                art.Brand = (Brand)cmbBrand.SelectedItem;
                art.Category = (Category)cmbCategory.SelectedItem;


                business.AddArticle(art);
                MessageBox.Show("Articulo agregado exitosamente");
                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

       
    }
}

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
    public partial class FormArticle : Form
    {
        private Article art = null;
        public FormArticle()
        {
            InitializeComponent();
            Text = "Add";
            lblTitle.Text = "Add new item";
            btnOk.Text = "Add";
        }

        public FormArticle(Article art)
        {
            InitializeComponent();
            this.art = art;
            Text = "Modify";
            lblTitle.Text = "Modify an existing item";
            btnOk.Text = "Modify";
        }

        private void FormArticle_Load(object sender, EventArgs e)
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

                if (art != null)
                {
                    txtCode.Text = art.Code;
                    txtName.Text = art.Name;
                    txtPrice.Text = art.Price.ToString("0.00");
                    cmbBrand.SelectedValue = art.Brand.Id;
                    cmbCategory.SelectedValue = art.Category.Id;
                    txtDescription.Text = art.Description;

                    foreach(var item in art.UrlImages)
                    {
                      lBoxUrl.Items.Add(item);
                    }

                    loadImage(art.UrlImages[0]);
                }
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
                ptbImage.Load(imageUrl);
                btnDeleteImg.Enabled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (art == null)
                art = new Article();
            BusinessArticle business = new BusinessArticle();
            BusinessImage businessImage = new BusinessImage();

            try
            {
                art.Code = txtCode.Text;
                art.Name = txtName.Text;
                art.Description = txtDescription.Text;
             //   art.UrlImage.Add(lBoxUrl.Items[0].ToString());  //CORREGIR
                art.Price = decimal.Parse(txtPrice.Text);
                art.Brand = (Brand)cmbBrand.SelectedItem;
                art.Category = (Category)cmbCategory.SelectedItem;
                art.UrlImages = new List<string>();

              
                foreach(var item in lBoxUrl.Items)
                {
                    art.UrlImages.Add(item.ToString());
                }

                if (art.Id != 0)
                {
                    business.modifyArticle(art);
                    MessageBox.Show("Successfully modified");
                }
                else
                {
                    business.AddArticle(art);
                    MessageBox.Show("Successfully added");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void loadImage(string imagen)
        {
            try
            {
                ptbImage.Load(imagen);
            }
            catch (Exception ex)
            {
                ptbImage.Load("https://faculty.eng.ufl.edu/elliot-douglas/wp-content/uploads/sites/70/2015/11/img-placeholder.png");
            }
        }

        private void btnDeleteImg_Click(object sender, EventArgs e)
        {
            if(lBoxUrl.SelectedItem != null)
            {
                lBoxUrl.Items.Remove(lBoxUrl.SelectedItem);
                ptbImage.Image = null;
                btnDeleteImg.Enabled = false;
            }
        }
    }
}

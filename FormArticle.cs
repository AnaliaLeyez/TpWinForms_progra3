using Business;
using Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Forms;

namespace TpWinForms
{
    public partial class FormArticle : Form
    {
        private Article art = null;
        private BusinessImage businessImage = null;
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
        }

        private void FormArticle_Load(object sender, EventArgs e)
        {
            BusinessCategory businessCategory = new BusinessCategory();
            BusinessBrand businessBrand = new BusinessBrand();
            try
            {
                if (art != null)
                {
                    businessImage = new BusinessImage();
                    art.UrlImages = businessImage.list(art.Id);
                }
                cmbBrand.DataSource = businessBrand.list();
                cmbCategory.DataSource = businessCategory.list();
                cmbBrand.ValueMember = "Id";
                cmbBrand.DisplayMember = "Description";
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

                    foreach (var item in art.UrlImages)
                    {
                        lBoxUrl.Items.Add(item);
                    }

                    if(lBoxUrl.Items.Count > 0)
                    {
                        loadImage(art.UrlImages[0].UrlImage);
                      
                    }
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
            AddImgToBox();
        }

        private void AddImgToBox()
        {
            string urlImage = txtUrlImage.Text;

            if (!string.IsNullOrEmpty(urlImage))
            {
                Model.Image img = new Model.Image();
                img.UrlImage = urlImage;
                lBoxUrl.Items.Add(img);
                txtUrlImage.Clear();
            }
        }
        private void lBoxUrl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lBoxUrl.SelectedItem != null)
            {
                string imageUrl = lBoxUrl.SelectedItem.ToString();
                loadImage(imageUrl);
                btnDeleteImg.Enabled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            BusinessArticle business = new BusinessArticle();
            resetColors();
           
            try
            {
                if (art == null)
                {
                    art = new Article();
                    art.UrlImages = new List<Model.Image>();
                }
                if (!Model.Validation.mandatoryField(txtCode, txtName, txtPrice))
                    return;

                if (Model.Validation.onlyNumbers(txtPrice.Text))
                {
                    txtPrice.Text = txtPrice.Text.Replace('.', ',');
                    art.Price = decimal.Parse(txtPrice.Text);
                    if (art.Price == 0)
                    {
                        MessageBox.Show("Price must be greater than zero");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Only real numbers for the price");
                    return;
                }
                art.Code = txtCode.Text;
                art.Name = txtName.Text;
                art.Description = txtDescription.Text;
                art.Price = decimal.Parse(txtPrice.Text);
                art.Brand = (Brand)cmbBrand.SelectedItem;
                art.Category = (Category)cmbCategory.SelectedItem;

                foreach (Model.Image item in lBoxUrl.Items)
                {
                    art.UrlImages.Add(item);
                }
                
                if (art.Id!=0)
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
        private void resetColors()
        {
            txtCode.BackColor = System.Drawing.Color.White;
            txtName.BackColor = System.Drawing.Color.White;
            txtPrice.BackColor = System.Drawing.Color.White;
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
            Model.Image img = (Model.Image)lBoxUrl.SelectedItem;

            //Delete para nuevos registros
            if (lBoxUrl.SelectedItem != null && img.Id == 0)
            {
                DeleteImageBox();
                return;
            }

            if (art != null && img.Id > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure to delete the image from the database? This action cannot be undone", "Delete image", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    //Model.Image img = (Model.Image)lBoxUrl.SelectedItem;
                    businessImage.DeleteImage(img.Id);
                    DeleteImageBox();
                }
            }
        }
        private void DeleteImageBox()
        {
            lBoxUrl.Items.Remove(lBoxUrl.SelectedItem);
            ptbImage.Image = null;
            btnDeleteImg.Enabled = false;
        }
        private void txtUrlImage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                AddImgToBox();
                e.Handled = true;
            }
        }
        
    }
}

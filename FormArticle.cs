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
using System.Windows.Controls;
using System.Windows.Forms;

namespace TpWinForms
{
    public partial class FormArticle : Form
    {
        private Article art = null;
        private BusinessImage businessImage = null;
        private string mode;
        public FormArticle()
        {
            InitializeComponent();
            Text = "Add";
            lblTitle.Text = "Add new item";
            btnOk.Text = "Add";
        }

        public FormArticle(Article art, string mode)
        {
            InitializeComponent();
            this.art = art;
            this.mode = mode;
            SetMode(mode);
        }


        public void SetMode(string mode)
        {
            switch (mode)
            {
                case "Modify":
                    Text = "Modify";
                    lblTitle.Text = "Modify an existing item";
                    btnOk.Text = "Modify";
                    break;
                case "Details":
                    Text = "Details";
                    lblTitle.Text = "View item details";
                    btnOk.Text = "Close";
                    // Puedes deshabilitar controles o ajustar otros elementos aquí si es necesario
                    btnOk.Visible = false; // Ejemplo para ocultar el botón en modo "Details"
                    break;
                default:
                    throw new ArgumentException("Unknown mode", nameof(mode));
            }
        }



        private void FormArticle_Load(object sender, EventArgs e)
        {
            BusinessCategory businessCategory = new BusinessCategory();
            BusinessBrand businessBrand = new BusinessBrand();
            btnOk.Enabled = false;

            if (art != null)
            {
                businessImage = new BusinessImage();
                art.UrlImages = businessImage.list(art.Id);
            }

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

                    loadImage(art.UrlImages[0].UrlImage);
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
            {
                art = new Article();
                art.UrlImages = new List<Model.Image>();
            }


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
              
                foreach(var item in lBoxUrl.Items)
                {
                    Model.Image img = new Model.Image();
                    img.UrlImage = item.ToString();
                    img.IdArticle = art.Id;

                    art.UrlImages.Add(img);
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
            if(lBoxUrl.SelectedItem != null && art == null)
            {
                lBoxUrl.Items.Remove(lBoxUrl.SelectedItem);
                ptbImage.Image = null;
                btnDeleteImg.Enabled = false;
            }

            if(art != null)
            {
                DialogResult result = MessageBox.Show("Do you want to delete the image from the database, This action cannot be undone ?", "Delete image", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    Model.Image img = (Model.Image)lBoxUrl.SelectedItem;
                    businessImage.DeleteImage(img.Id);
                    //Hay que ver como recargamos el form para que se actualice.
                }
            }
        }

        private void validateField()
        {
            var vr = !string.IsNullOrEmpty(txtCode.Text) &&
            !string.IsNullOrEmpty(txtPrice.Text) &&
            !string.IsNullOrEmpty(txtName.Text);
            btnOk.Enabled = vr;
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateField();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateField();
            Model.Validation.onlyNumbers((KeyPressEventArgs)e);
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            validateField();
            Model.Validation.onlyLetters((KeyPressEventArgs)e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using System.Xml.Linq;
using Model;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace TpWinForms
{
    public partial class FormDetails : Form
    {
        private Article article;
        private BusinessImage businessImage;
        private int indexImages = 0;
        public FormDetails()
        {
            InitializeComponent();
        }

        public FormDetails(Article art)
        {
            InitializeComponent();
            article = art;

        }

        private void FormDetails_Load(object sender, EventArgs e)
        {
            businessImage = new BusinessImage();
            article.UrlImages = businessImage.list(article.Id);

            lblCode.Text = "Code: "+article.Code;
            lblName.Text = "Name: "+article.Name;
            lblBrand.Text = "Brand: " + article.Brand.ToString();
            lblPrice.Text = "Price: $" + article.Price.ToString();
            lblCategory.Text = "Category: " + article.Category.ToString();
            lblDescription.Text = article.Description;

            if (article.UrlImages.Count > 0)
            {
                ptBox.ImageLocation = article.UrlImages[0].UrlImage;
            }
            else
            {
                ptBox.ImageLocation = "https://faculty.eng.ufl.edu/elliot-douglas/wp-content/uploads/sites/70/2015/11/img-placeholder.png";
            }

            if (article.UrlImages.Count > 1) 
            {
                btnNext.Enabled = true;
            }
            else 
            {
                btnNext.Enabled = false;
            }
            btnPrevious.Enabled = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(article.UrlImages.Count>indexImages+1)
            {
                indexImages++;
                ptBox.ImageLocation = article.UrlImages[indexImages].UrlImage;
                if (article.UrlImages.Count == indexImages + 1)
                {
                    btnNext.Enabled = false;
                }
            }
            if (indexImages>0)
            {
                btnPrevious.Enabled = true;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (indexImages> 0)
            {
                indexImages--;
                ptBox.ImageLocation = article.UrlImages[indexImages].UrlImage;
                if (indexImages==0)
                {
                    btnPrevious.Enabled = false;
                }
            }
            if (indexImages +1 < article.UrlImages.Count)
            {
                btnNext.Enabled = true;
            }
        }
    }
}

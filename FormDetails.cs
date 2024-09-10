using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace TpWinForms
{
    public partial class FormDetails : Form
    {
        private Article article = null;
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
            lblCode.Text = article.Code;
            lblName.Text = article.Name;
            lblBrand.Text = article.Brand.ToString();
            lblPrice.Text = article.Price.ToString();
            lblCategory.Text = article.Category.ToString();
            lblDescription.Text = article.Description;
            ptBox.ImageLocation = article.UrlImages[indexImages].UrlImage;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(article.UrlImages.Count > 0)
            {
                indexImages++;
                ptBox.ImageLocation = article.UrlImages[indexImages].UrlImage;
            }
        }
    }
}

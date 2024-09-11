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
    public partial class FormBrand : Form
    {
        private List<Brand> listBrand;
        private Brand brn = null;

        public FormBrand()
        {
            InitializeComponent();
        }


        private void load()
        {
            BusinessBrand business = new BusinessBrand();
            try
            {
                listBrand = business.list();
                dgvBrands.DataSource = listBrand;

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void FormBrand_Load(object sender, EventArgs e)
        {
            load();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BusinessBrand business = new BusinessBrand();
            try
            {
                if (brn == null)
                    brn = new Brand();

                brn.Description = (string)txtNewBrand.Text;
                business.add(brn);
                MessageBox.Show("Category added successfully");
                load();
                txtNewBrand.Text = "";
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            BusinessBrand business = new BusinessBrand();
            Brand selected;
            try
            {
                DialogResult response = MessageBox.Show("Are you sure to delete this brand?", "Eliminating", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (response == DialogResult.Yes)
                {
                    selected = (Brand)dgvBrands.CurrentRow.DataBoundItem;
                    business.delete(selected.Id);
                    load();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtNewBrand_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.onlyLetters((KeyPressEventArgs)e);

        }
    }
}

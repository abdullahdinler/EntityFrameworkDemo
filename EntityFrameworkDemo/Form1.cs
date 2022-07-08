using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
         
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                UnitePrice = Convert.ToDecimal(tbxUnitePrice.Text),
                StockAmount = Convert.ToInt16(tbxStockAmount.Text)
            });
            MessageBox.Show("Added a product");
            LoadProduct();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                _productDal.Update(new Product
                {
                    Id = Convert.ToInt32(dgvProduct.CurrentRow.Cells[0].Value),
                    Name = tbxName.Text,
                    UnitePrice = Convert.ToDecimal(tbxUnitePrice.Text),
                    StockAmount = Convert.ToInt32(tbxStockAmount.Text)
                });
                MessageBox.Show("Update a product");
                LoadProduct();
            }
            catch (FormatException)
            {
                Console.WriteLine("Lütfen öncelikle tablodan bır ürun seciniz.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgvProduct.CurrentRow.Cells[0].Value),

            });
            MessageBox.Show("Delete a product");
            LoadProduct();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvProduct.CurrentRow.Cells[0].Value);
            tbxName.Text = dgvProduct.CurrentRow.Cells[1].Value.ToString();
            tbxUnitePrice.Text = dgvProduct.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmount.Text = dgvProduct.CurrentRow.Cells[3].Value.ToString();
        }
        private void LoadProduct()
        {
            dgvProduct.DataSource = _productDal.GetAll();
        }
    }
}

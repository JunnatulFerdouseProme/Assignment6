using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Assignment6.BLL;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class OrderUi : Form
    {
        OrderManager _orderManager = new OrderManager();
        public OrderUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Mandatory
            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("Customer Name can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                MessageBox.Show("Item can not be Empty!!");
                return;
            }
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price can not be Empty!!");
                return;
            }

            ////Unique
            //if (_itemManager.IsNameExist(nameTextBox.Text))
            //{
            //    MessageBox.Show(nameTextBox.Text + " Already Exist!!");
            //    return;
            //}

            //Add/Insert
            if (_orderManager.Add(customerNameTextBox.Text,itemNameTextBox.Text, Convert.ToDouble(priceTextBox.Text),Convert.ToDouble(quantityTextBox.Text)))
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            idTextBox.Clear();
            customerNameTextBox.Clear();
            itemNameTextBox.Clear();
            priceTextBox.Clear();
            quantityTextBox.Clear();

        }

        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void quantityLabel_Click(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Display();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }

            //Delete
            if (_orderManager.Delete(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _orderManager.Display();
            idTextBox.Clear();
            customerNameTextBox.Clear();
            itemNameTextBox.Clear();
            priceTextBox.Clear();
            quantityTextBox.Clear();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(customerNameTextBox.Text))
            {
                MessageBox.Show("CustomerName Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(itemNameTextBox.Text))
            {
                MessageBox.Show("ItemName Can not be Empty!!!");
                return;
            }
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(quantityTextBox.Text))
            {
                MessageBox.Show("Quantity Can not be Empty!!!");
                return;
            }

            if (_orderManager.Update(customerNameTextBox.Text,itemNameTextBox.Text, Convert.ToDouble(priceTextBox.Text),Convert.ToDouble(quantityTextBox.Text) ,Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _orderManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
            idTextBox.Clear();
            customerNameTextBox.Clear();
            itemNameTextBox.Clear();
            priceTextBox.Clear();
            quantityTextBox.Clear();

        }

        private void serachButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _orderManager.Search(itemNameTextBox.Text);
            itemNameTextBox.Clear();
        }
    }
}

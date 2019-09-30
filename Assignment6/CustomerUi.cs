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
    public partial class CustomerUi : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        public CustomerUi()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Mandatory
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name can not be Empty!!");
                return;
            }
            if (_customerManager.IsNameExist(nameTextBox.Text))
            {
                MessageBox.Show(nameTextBox.Text + " Already Exist!!\n Please enter a valid Name ");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Conatct can not be Empty!!");
                return;
            }

            //Unique
            if (_customerManager.IsContactExist(contactTextBox.Text))
            {
                MessageBox.Show(contactTextBox.Text + " Already Exist!!\n Please enter a valid Conatct ");
                return;
            }
           

            //Add/Insert
            if (_customerManager.Add(nameTextBox.Text, contactTextBox.Text,addressTextBox.Text))
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            idTextBox.Clear();
            nameTextBox.Clear();
            contactTextBox.Clear();
            addressTextBox.Clear();


        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Display();
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
            if (_customerManager.Delete(Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            showDataGridView.DataSource = _customerManager.Display();
            idTextBox.Clear();
            nameTextBox.Clear();
            contactTextBox.Clear();
            addressTextBox.Clear();

        }

        private void updateButton_Click(object sender, EventArgs e)
        {//Set Id as Mandatory
            if (String.IsNullOrEmpty(idTextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Name Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(contactTextBox.Text))
            {
                MessageBox.Show("Contact Can not be Empty!!!");
                return;
            }
            if (String.IsNullOrEmpty(addressTextBox.Text))
            {
                MessageBox.Show("Address Can not be Empty!!!");
                return;
            }

            if (_customerManager.Update(nameTextBox.Text, contactTextBox.Text, addressTextBox.Text, Convert.ToInt32(idTextBox.Text)))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _customerManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
            idTextBox.Clear();
            nameTextBox.Clear();
            contactTextBox.Clear();
            addressTextBox.Clear();


        }

        private void serachButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _customerManager.Search(nameTextBox.Text);
        }
    }
}

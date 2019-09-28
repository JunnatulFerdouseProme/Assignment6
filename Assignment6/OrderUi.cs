using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Assignment6
{
    public partial class OrderUi : Form
    {
        public OrderUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Connection
            string Connectionstring = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(Connectionstring);

            //Sql Command
            //INSERT INTO Customer(Name, Contact,Address) Values ('Prome','01724127760','Narrinda Police Fari')
            string commandString = @"INSERT INTO Orders (CustomerName, ItemName,Price,Quantity) Values ('" + customerNameTextBox.Text + "','" + itemNameTextBox.Text + "','" + priceTextBox.Text + "','" + quantityTextBox.Text + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Clear
            customerNameTextBox.Clear();
            itemNameTextBox.Clear();
            priceTextBox.Clear();
            quantityTextBox.Clear();
            //Open Connection
            sqlConnection.Open();
            //Execute
            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }


            //Close Connection
            sqlConnection.Close();

        }

        private void idLabel_Click(object sender, EventArgs e)
        {

        }

        private void quantityLabel_Click(object sender, EventArgs e)
        {

        }

        private void showButton_Click(object sender, EventArgs e)
        {

        }
    }
}

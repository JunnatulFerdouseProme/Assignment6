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
    public partial class ItemUi : Form
    {
        public ItemUi()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Sql Command
            //INSERT INTO Items (Name, Price) Values ('Black', 120)
            string commandString = @"INSERT INTO Items (Name, Price) Values ('" + nameTextBox.Text + "', " + priceTextBox.Text + ")";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

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

        private void showButton_Click(object sender, EventArgs e)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Sql Command
            //SELECT * FROM Items
            string commandString = @"SELECT * FROM Items";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open Connection
            sqlConnection.Open();

            //Execute
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
            }
            else
            {
                showDataGridView.DataSource = null;
                MessageBox.Show("Data not found!");

            }

            //Close Connection
            sqlConnection.Close();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            //Connection
            string connectionString = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //Sql Command
            //DELETE FROM Items WHERE ID = 3
            string commandString = @"DELETE FROM Items WHERE ID = " + idTextBox.Text + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open Connection
            sqlConnection.Open();
            //Execute
            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                MessageBox.Show("Deleted");
            }
            else
            {
                MessageBox.Show("Not Deleted");
            }

            //Close Connection
            sqlConnection.Close();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //Connection
            string Connectionstring = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(Connectionstring);

            //Sql Command
            //Update Customer 
            string commandString = @"UPDATE Items SET Name = '" + nameTextBox.Text + "', Price= " + priceTextBox.Text + "," +
                    "WHERE ID = " + idTextBox.Text + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            nameTextBox.Clear();
            priceTextBox.Clear();
            
            //Open Connection
            sqlConnection.Open();
            //Execute
            int isExecuted = sqlCommand.ExecuteNonQuery();
            if (isExecuted > 0)
            {
                MessageBox.Show("Updated");
            }
            else
            {
                MessageBox.Show("Not Update");
            }

            //Close Connection
            sqlConnection.Close();

        }

        private void serachButton_Click(object sender, EventArgs e)
        {
            //Connection
            string Connectionstring = @"Server=DESKTOP-IL4U8GL; Database=CoffeeShop; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(Connectionstring);

            //Sql Command
            //Search into Customer
            string commandString = @"SELECT * FROM Items WHERE Id =" + idTextBox.Text + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            //Open Connection
            sqlConnection.Open();
            //Execute
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                showDataGridView.DataSource = dataTable;
            }
            else
            {
                showDataGridView.DataSource = null;
                MessageBox.Show("Data not found!");

            }


            //Close Connection
            sqlConnection.Close();
        }
    }
}

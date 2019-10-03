using CoffeeShopAssignmentUI.BLL;
using CoffeeShopAssignmentUI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopAssignmentUI
{
    public partial class ItemAssignmentUI : Form
    {
        ItemManager _itemManager = new ItemManager();
        Item _item = new Item();
        public ItemAssignmentUI()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            _item.Name = nameTextBox.Text;
            //Check UNIQUE
            if (_itemManager.IsNameExists(_item))
            {
                MessageBox.Show(nameTextBox.Text + "Already Exists!");
                return;
            }

            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }

            _item.Price = Convert.ToDouble(priceTextBox.Text);

            //Add/Insert Item
            bool isAdded = _itemManager.Add(_item);

            if (isAdded)
            {
                MessageBox.Show("Saved");
            }
            else
            {
                MessageBox.Show("Not Saved");
            }
            
                if (!string.IsNullOrEmpty(priceTextBox.Text) || string.IsNullOrEmpty(itemComboBox.Text))

                {
                    showDataGridView.DataSource = (Convert.ToInt32(priceTextBox.Text) + Convert.ToInt32(itemComboBox.Text).ToString());
                }
            

            showDataGridView.DataSource = _itemManager.Display();
            nameTextBox.Clear();
            priceTextBox.Clear();
            idtextBox.Clear();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _itemManager.Display();
            nameTextBox.Clear();
            priceTextBox.Clear();
            idtextBox.Clear();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Set Id as Mandatory
                if (String.IsNullOrEmpty(idtextBox.Text))
                {
                    MessageBox.Show("Id Can not be Empty!!!");
                    return;
                }

                //Delete
                _item.ID = Convert.ToInt32(idtextBox.Text);
                if (_itemManager.Delete((_item)))
                {
                    MessageBox.Show("Deleted");
                }
                else
                {
                    MessageBox.Show("Not Deleted");
                }
            }
            catch (Exception exception)
            {

                MessageBox.Show(exception.Message+ "Server Error!!!");
            }
            

            showDataGridView.DataSource = _itemManager.Display();
            nameTextBox.Clear();
            priceTextBox.Clear();
            idtextBox.Clear();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //Set Id as Mandatory
            if (String.IsNullOrEmpty(idtextBox.Text))
            {
                MessageBox.Show("Id Can not be Empty!!!");
                return;
            }
            //Set Price as Mandatory
            if (String.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show("Price Can not be Empty!!!");
                return;
            }
            _item.Name = nameTextBox.Text;
            _item.Price = Convert.ToDouble(priceTextBox.Text);
            _item.ID = Convert.ToInt32(idtextBox.Text);
            if (_itemManager.Update(_item))
            {
                MessageBox.Show("Updated");
                showDataGridView.DataSource = _itemManager.Display();
            }
            else
            {
                MessageBox.Show("Not Updated");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            //Set Price as Mandatory
            _item.Name = nameTextBox.Text;
            if (String.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Eield is Empty!");
                return;
            }

            showDataGridView.DataSource =
           _itemManager.Search(_item);
            nameTextBox.Clear();
            priceTextBox.Clear();
            idtextBox.Clear();
        }

        private void ItemAssignmentUI_Load(object sender, EventArgs e)
        {
            itemComboBox.DataSource = _itemManager.ItemCombobox();

           
        }
        
    }
}

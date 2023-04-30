using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsMVP.View
{
    internal partial class CustomerForm : Form, ICustomerView
    {
        private bool _isEditMode = false;

        public CustomerForm()
        {
            InitializeComponent();
        }

        public IList<string> CustomerList
        {
            get { return (IList<string>)customerListBox.DataSource; }
            set { customerListBox.DataSource = value; }
        }

        public int SelectedCustomer
        {
            get { return customerListBox.SelectedIndex; }
            set { customerListBox.SelectedIndex = value; }
        }

        public string Address
        {
            get { return addressTextBox.Text; }
            set { addressTextBox.Text = value; }
        }

        public string CustomerName
        {
            get { return nameTextBox.Text; }
            set { nameTextBox.Text = value; }
        }

        public string Phone
        {
            get { return phoneTextBox.Text; }
            set { phoneTextBox.Text = value; }
        }

        public Presenter.CustomerPresenter Presenter
        { private get; set; }

        private void CustomerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // FIXME: try/catch
            Presenter.UpdateCustomerView(customerListBox.SelectedIndex);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            addressTextBox.ReadOnly = _isEditMode;
            nameTextBox.ReadOnly = _isEditMode;
            phoneTextBox.ReadOnly = _isEditMode;

            _isEditMode = !_isEditMode;

            editButton.Text = _isEditMode ? "Save" : "Edit";
            // TODO: add cancel button

            if (!_isEditMode)
            {
                // TODO: validation
                // FIXME: try/catch
                Presenter.SaveCustomer();
            }
        }
    }
}
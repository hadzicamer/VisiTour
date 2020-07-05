using Flurl.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisiTour.Model.Requests;

namespace VisiTour.WinUI.Customers
{
    public partial class frmDetalis : Form
    {
        private readonly APIService _service = new APIService("Customers");
        private int? _CustomerID = null;
        public frmDetalis(int? CustomerID = null)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var req = new CustomersUpsertRequest()
                {
                    Email = txtEmail.Text,
                    Username = txtUsername.Text,
                    Name = txtName.Text,
                    Country = txtCountry.Text,
                    Password = txtPass.Text,
                    ConfirmPassword = txtPassConfirm.Text,
                    DateOfBirth = DateTime.Parse(txtDate.Text)
                };

                if (_CustomerID.HasValue)
                {
                    await _service.Update<Model.Customers>(_CustomerID, req);
                    MessageBox.Show("Customer updated!");
                }
                else
                {
                    await _service.Insert<Model.Customers>(req);
                    MessageBox.Show("New customer added!");
                }

            }
        }

        private async void frmDetalis_Load(object sender, EventArgs e)
        {
            if (_CustomerID.HasValue)
            {
                var customer = await _service.GetById<Model.Customers>(_CustomerID);

                txtName.Text = customer.Name;
                txtEmail.Text = customer.Email;
                txtCountry.Text = customer.Country;
                txtDate.Text = customer.DateOfBirth.ToString().Substring(0, 10);
                txtUsername.Text = customer.Username;
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider.SetError(txtName, Properties.Resources.validation_required);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtName, null);
            }

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Properties.Resources.validation_required);
                e.Cancel = true;

            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtDate_Validating_1(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDate.Text))
            {
                errorProvider.SetError(txtDate, Properties.Resources.validation_required);
                e.Cancel = true;

            }
            else
            {
                errorProvider.SetError(txtDate, null);
            }


        }
    }
}

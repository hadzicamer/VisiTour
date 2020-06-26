using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Flurl.Http;
using Flurl;
using VisiTour.Model.Requests;

namespace VisiTour.WinUI.Customers
{
    public partial class frmCustomers : Form
    {
        private readonly APIService _apiService = new APIService("Customers");
        public frmCustomers()
        {
            InitializeComponent();
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var search = new CustomerSearchRequest()
            {
                Name=txtSearch.Text

            };
            var res = await _apiService.Get<List<Model.Customers>>(search);
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = res;
        }

        private void dgvCustomers_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvCustomers.SelectedRows[0].Cells[0].Value;
            frmDetalis frm = new frmDetalis(int.Parse(id.ToString()));
            frm.Show();

        }
    }
}

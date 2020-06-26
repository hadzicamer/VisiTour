using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisiTour.Model.Requests;

namespace VisiTour.WinUI.Payments
{
    public partial class frmPayments : Form
    {
        private readonly APIService _service = new APIService("Payments");
        public frmPayments()
        {
            InitializeComponent();
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var search = new PaymentsSearchRequest()
            {
                PaymentMethod = txtSearch.Text
            };

            var res = await _service.Get<List<Model.Payments>>(search);
            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.DataSource = res;
        }
        private void dgvPayments_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            var id = dgvPayments.SelectedRows[0].Cells[0].Value;
            frmPaymentsDetails frm = new frmPaymentsDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}

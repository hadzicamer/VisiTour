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
    public partial class frmPaymentsDetails : Form
    {
        private readonly APIService _service = new APIService("Payments");
        private int? _PaymentId = null;
        public frmPaymentsDetails(int? PaymentId = null)
        {
            InitializeComponent();
            _PaymentId = PaymentId;
        }

        private async void frmPaymentsDetails_Load(object sender, EventArgs e)
        {
            if (_PaymentId.HasValue)
            {
                var payment = await _service.GetById<Model.Payments>(_PaymentId);

                txtAmount.Text = payment.Amount.ToString();
                txtPaymentMethod.Text = payment.PaymentMethod;
                txtPaymentDate.Text = payment.PaymentDate.ToString().Substring(0,10);
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var req = new PaymentsUpsertRequest()
            {
                Amount = decimal.Parse(txtAmount.Text),
                PaymentMethod=txtPaymentMethod.Text,
                PaymentDate = DateTime.Parse(txtPaymentDate.Text),
            };

            if (_PaymentId.HasValue)
            {
                await _service.Update<Model.Payments>(_PaymentId, req);
                MessageBox.Show("Payment updated!");
            }
            else
            {
                await _service.Insert<Model.Payments>(req);
                MessageBox.Show("New payment added!");
            }
        }
    }
}

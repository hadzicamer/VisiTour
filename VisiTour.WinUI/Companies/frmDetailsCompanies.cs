using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisiTour.Model.Requests;

namespace VisiTour.WinUI.Companies
{
    public partial class frmDetailsCompanies : Form
    {
        private readonly APIService _service = new APIService("Companies");
        private int? _CompanyId = null;
        public frmDetailsCompanies(int? CompanyId = null)
        {
            InitializeComponent();
            _CompanyId = CompanyId;
        }

        private static Image GetImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return (Image.FromStream(ms));
            }
        }
        private async void frmDetailsCompanies_Load(object sender, EventArgs e)
        {
            if (_CompanyId.HasValue)
            {
                var company = await _service.GetById<Model.Companies>(_CompanyId);

                txtName.Text = company.Name;
                txthq.Text = company.Headquarter;
                txtfoundingyear.Text = company.FoundingYear;
                pictureBox1.Image = GetImage(company.photo);
            }
        }

        private async void btnSave_Click_1(object sender, EventArgs e)
        {
           
            var req = new CompaniesUpsertRequest()
            {
                Name = txtName.Text,
                Headquarter = txthq.Text,
                FoundingYear = txtfoundingyear.Text,
            };

            if (_CompanyId.HasValue)
            {
                await _service.Update<Model.Companies>(_CompanyId, req);
                MessageBox.Show("Company updated!");
            }
            else
            {
                await _service.Insert<Model.Companies>(req);
                MessageBox.Show("New company addded!");
            }
        }

        CompaniesUpsertRequest req = new CompaniesUpsertRequest();

        private void btnAddImage_Click_1(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                req.Photo = file;
                txtphoto.Text = fileName;
                Image image = Image.FromFile(fileName);
                pictureBox1.Image = image;
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                errorProvider1.SetError(txtName, Properties.Resources.validation_required);
                e.Cancel = true;

            }
            else
            {
                errorProvider1.SetError(txtName, null);
            }

        }

        private void txthq_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txthq.Text))
            {
                errorProvider1.SetError(txthq, Properties.Resources.validation_required);
                e.Cancel = true;

            }
            else
            {
                errorProvider1.SetError(txthq, null);
            }

        }

        private void txtfoundingyear_TextChanged(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtfoundingyear.Text))
            {
                errorProvider1.SetError(txtfoundingyear, Properties.Resources.validation_required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtfoundingyear, null);
            }
        }

       
    }
}

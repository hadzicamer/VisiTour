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

        private async void frmDetailsCompanies_Load(object sender, EventArgs e)
        {
            if (_CompanyId.HasValue)
            {
                var company = await _service.GetById<Model.Companies>(_CompanyId);

                txtName.Text = company.Name;
                txthq.Text = company.Headquarter;
                txtfoundingyear.Text = company.FoundingYear;
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
    }
}

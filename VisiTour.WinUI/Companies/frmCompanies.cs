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
    public partial class frmCompanies : Form
    {
        private readonly APIService _apiService = new APIService("Companies");
        public frmCompanies()
        {
            InitializeComponent();
        }

        private async void btnShowCompanies_Click(object sender, EventArgs e)
        {
            var srch = new CompaniesSearchRequest()
            {
                Name = txtName.Text
            };
            var res = await _apiService.Get<List<Model.Companies>>(srch);
            dgvCompanies.AutoGenerateColumns = false;
            dgvCompanies.DataSource = res;
        }

        private void dgvCompanies_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var id = dgvCompanies.SelectedRows[0].Cells[0].Value;
            frmDetailsCompanies frm = new frmDetailsCompanies(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}

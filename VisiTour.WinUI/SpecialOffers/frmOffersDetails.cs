using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisiTour.Model.Requests;

namespace VisiTour.WinUI.SpecialOffers
{
    public partial class frmOffersDetails : Form
    {
        private readonly APIService _companiesService = new APIService("Companies");
        private readonly APIService _classesService = new APIService("FlightClasses");
        private readonly APIService _citiesService = new APIService("Cities");
        private readonly APIService _offersService = new APIService("SpecialOffers");
        private int? _OfferID = null;


        public frmOffersDetails(int? OfferID = null)
        {
            InitializeComponent();
            _OfferID = OfferID;

        }

        private async void frmOffersDetails_Load(object sender, EventArgs e)
        {
            await loadCitiesFrom();
            await loadCitiesTo();
            await loadClasses();
            await loadCompanies();
        }

        private async Task loadCompanies()
        {
            var res = await _companiesService.Get<List<Model.Companies>>(null);
            res.Insert(0, new Model.Companies());
            cbCompany.DataSource = res;
            cbCompany.DisplayMember = "Name";
            cbCompany.ValueMember = "CompanyId";
        }

        private async Task loadCitiesFrom()
        {
            var res = await _citiesService.Get<List<Model.Cities>>(null);
            res.Insert(0, new Model.Cities());

            cbFrom.DisplayMember = "Name";
            cbFrom.ValueMember = "CityId";
            cbFrom.DataSource = res;
        }

        private async Task loadCitiesTo()
        {
            var res = await _citiesService.Get<List<Model.Cities>>(null);
            res.Insert(0, new Model.Cities());

            cbTo.DisplayMember = "Name";
            cbTo.ValueMember = "CityId";
            cbTo.DataSource = res;
        }

        private async Task loadClasses()
        {
            var res = await _classesService.Get<List<Model.FlightClasses>>(null);
            res.Insert(0, new Model.FlightClasses());

            cbClass.DisplayMember = "Name";
            cbClass.ValueMember = "FlightClassId";
            cbClass.DataSource = res;
        }

        SpecialOffersUpsertRequest req = new SpecialOffersUpsertRequest();
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            var res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                var file = File.ReadAllBytes(fileName);
                req.Photo = file;
                txtImageInput.Text = fileName;
                Image image = Image.FromFile(fileName);
                pictureBox1.Image = image;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            var ClassidObj = cbClass.SelectedValue;
            if(int.TryParse(ClassidObj.ToString(),out int classId))
            {
                req.FlightClassId = classId;
            }
            var CompanyidObj = cbCompany.SelectedValue;
            if (int.TryParse(CompanyidObj.ToString(), out int companyId))
            {
                req.CompanyId = companyId;
            }
            var CityFromidObj = cbFrom.SelectedValue;
            if (int.TryParse(CityFromidObj.ToString(), out int cityFromId))
            {
                req.CityFromId = cityFromId;
            }
            var CityToidObj = cbTo.SelectedValue;
            if (int.TryParse(CityToidObj.ToString(), out int cityToId))
            {
                req.CityToId = cityToId;
            }

            req.DateFrom = DateTime.Parse(dateTimePicker1.Text);
            req.DateTo = DateTime.Parse(dateTimePicker2.Text);
            req.Price = decimal.Parse(txtPrice.Text);

            if (_OfferID.HasValue)
            {
                await _offersService.Update<Model.SpecialOffers>(_OfferID, req);
                MessageBox.Show("Offer updated!");
            }
            else
            {
                await _offersService.Insert<Model.SpecialOffers>(req);
                MessageBox.Show("New offer added!");
            }

        }
    }
}

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

namespace VisiTour.WinUI.Flights
{
    public partial class frmFlightsDetails : Form
    {
        private readonly APIService _companiesService = new APIService("Companies");
        private readonly APIService _classesService = new APIService("FlightClasses");
        private readonly APIService _citiesService = new APIService("Cities");
        private readonly APIService _flightsService = new APIService("Flights");
        private int? _FlightID = null;

        public frmFlightsDetails(int? FlightID = null)
        {
            InitializeComponent();
            _FlightID = FlightID;
        }

        private async void frmFlightsDetails_Load(object sender, EventArgs e)
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

            cbCityFrom.DisplayMember = "Name";
            cbCityFrom.ValueMember = "CityId";
            cbCityFrom.DataSource = res;
        }

        private async Task loadCitiesTo()
        {
            var res = await _citiesService.Get<List<Model.Cities>>(null);
            res.Insert(0, new Model.Cities());

            cbCityTo.DisplayMember = "Name";
            cbCityTo.ValueMember = "CityId";
            cbCityTo.DataSource = res;
        }

        private async Task loadClasses()
        {
            var res = await _classesService.Get<List<Model.FlightClasses>>(null);
            res.Insert(0, new Model.FlightClasses());

            cbClass.DisplayMember = "Name";
            cbClass.ValueMember = "FlightClassId";
            cbClass.DataSource = res;
        }

        FlightsUpsertRequest req = new FlightsUpsertRequest();
        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
            {
                var ClassidObj = cbClass.SelectedValue;
                if (int.TryParse(ClassidObj.ToString(), out int classId))
                {
                    req.FlightClassId = classId;
                }
                var CompanyidObj = cbCompany.SelectedValue;
                if (int.TryParse(CompanyidObj.ToString(), out int companyId))
                {
                    req.CompanyId = companyId;
                }
                var CityFromidObj = cbCityFrom.SelectedValue;
                if (int.TryParse(CityFromidObj.ToString(), out int cityFromId))
                {
                    req.CityFromId = cityFromId;
                }
                var CityToidObj = cbCityTo.SelectedValue;
                if (int.TryParse(CityToidObj.ToString(), out int cityToId))
                {
                    req.CityToId = cityToId;
                }

                req.DateFrom = DateTime.Parse(dateFrom.Text);
                req.DateTo = DateTime.Parse(dateTo.Text);

                if (_FlightID.HasValue)
                {
                    await _flightsService.Update<Model.Flights>(_FlightID, req);
                    MessageBox.Show("Flight updated!");
                }
                else
                {
                    await _flightsService.Insert<Model.Flights>(req);
                    MessageBox.Show("New flight added!");
                }
            }
        }

        private void cbCityFrom_Validating(object sender, CancelEventArgs e)
        {
            if (cbCityFrom.SelectedIndex == 0 || cbCityFrom.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbCityFrom, Properties.Resources.validation_required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbCityFrom, null);
            }
        }

        private void cbCityTo_Validating(object sender, CancelEventArgs e)
        {
            if (cbCityTo.SelectedIndex == 0 || cbCityTo.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbCityTo, Properties.Resources.validation_required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbCityTo, null);
            }
        }

        private void cbClass_Validating(object sender, CancelEventArgs e)
        {
            if (cbClass.SelectedIndex == 0 || cbClass.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbClass, Properties.Resources.validation_required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbClass, null);
            }
        }

        private void cbCompany_Validating(object sender, CancelEventArgs e)
        {
            if (cbCompany.SelectedIndex == 0 || cbCompany.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbCompany, Properties.Resources.validation_required);
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(cbCompany, null);
            }
        }
    }
    }


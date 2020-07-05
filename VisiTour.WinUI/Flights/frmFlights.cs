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
using VisiTour.WinUI.Models;

namespace VisiTour.WinUI.Flights
{
    public partial class frmFlights : Form
    {
        private readonly APIService _apiService = new APIService("Flights");

        public frmFlights()
        {
            InitializeComponent();
        }

        private async void btnShow_Click(object sender, EventArgs e)
        {
            var srch = new FlightsSearchRequest()
            {
                selectedClass = txtClass.Text
            };
            var res = await _apiService.Get<List<Model.Flights>>(srch);
            //dataGridView1.AutoGenerateColumns = false;
            List<FlightsSearch> vm = new List<FlightsSearch>();
            foreach (var item in res)
            {
                FlightsSearch fs = new FlightsSearch
                {
                    selectedFlightTo=item.CityFrom.Name,
                    selectedFlightFrom = item.CityTo.Name,
                    selectedClass=item.FlightClass.Name,
                    DateFrom=item.DateFrom,
                    DateTo=item.DateTo
                };
                vm.Add(fs);
            }
            dataGridView1.DataSource = vm;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;
            frmFlightsDetails frm = new frmFlightsDetails(int.Parse(id.ToString()));
            frm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisiTour.WinUI.SpecialOffers
{
    public partial class frmOffersDetails : Form
    {
        private readonly APIService _companiesService = new APIService("Companies");
        private readonly APIService _classesService = new APIService("FlightClasses");
        private readonly APIService _citiesService = new APIService("Cities");


        public frmOffersDetails()
        {
            InitializeComponent();
        }

      

        private void frmOffersDetails_Load(object sender, EventArgs e)
        {

        }
    }
}

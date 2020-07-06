using System;
using System.Windows.Forms;
using VisiTour.WinUI.Companies;
using VisiTour.WinUI.Customers;
using VisiTour.WinUI.Flights;
using VisiTour.WinUI.SpecialOffers;

namespace VisiTour.WinUI
{
    public partial class frmIndex : Form
    {
        private int childFormNumber = 0;

        public frmIndex()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void newCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetalis frm = new frmDetalis();
            frm.Show();
        }

        private void searchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCompanies frm = new frmCompanies();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetailsCompanies frm = new frmDetailsCompanies();
            frm.Show();
        }


        private void btnCompanies_Click(object sender, EventArgs e)
        {
            frmCompanies frm = new frmCompanies();
            frm.Show();
        }

     

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            frmCustomers frm = new frmCustomers();
            frm.Show();
        }

        private void btnOffers_Click(object sender, EventArgs e)
        {
            frmOffersDetails frm = new frmOffersDetails();
            frm.Show();
        }

        private void addNewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmOffersDetails frm = new frmOffersDetails();
            frm.Show();
        }

        private void searchToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmFlights frm = new frmFlights();
            frm.Show();
        }

        private void addNewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmFlightsDetails frm = new frmFlightsDetails();
            frm.Show();
        }

        private void btnFlights_Click_1(object sender, EventArgs e)
        {
            frmFlights frm = new frmFlights();
            frm.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers.frmReport frm = new Customers.frmReport();
            frm.Show();
        }

        private void reportToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Companies.frmReport frm = new Companies.frmReport();
            frm.Show();
        }

    }
}

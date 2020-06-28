using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiTour.Model;
using VisiTour.Model.Requests;
using Xamarin.Forms;

namespace VisiTour.Mobile.ViewModels
{
    public class ClassesViewModel:BaseViewModel
    {
        private readonly APIService _companiesService = new APIService("Companies");
        private readonly APIService _classesService = new APIService("FlightClasses");

        public ClassesViewModel()
        {
            CompaniesCommand = new Command(async () => await InitCompanies());
            ClassesCommand = new Command(async () => await InitClasses());
        }

        public ObservableCollection<Companies> CompaniesList { get; set; } = new ObservableCollection<Companies>();
        public ObservableCollection<FlightClasses> ClassesList { get; set; } = new ObservableCollection<FlightClasses>();


        private Companies _selectedCompany;
        public Companies SelectedCompany
        {
            get { return _selectedCompany; }
            set {
                _selectedCompany = value;
                OnPropertyChanged();
            }
        }

        private FlightClasses _selectedClass;
        public FlightClasses SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                OnPropertyChanged();
            }
        }



        public ICommand CompaniesCommand { get; set; }
        public ICommand ClassesCommand { get; set; }

        public async Task InitClasses()
        {
            if (ClassesList.Count == 0)
            {
                var list = await _classesService.Get<List<FlightClasses>>(null);

                ClassesList.Clear();
                foreach (var classes in list)
                {
                    ClassesList.Add(classes);
                }
            }
        }

        public async Task InitCompanies()
        {

            if (CompaniesList.Count == 0)
            {
                var list = await _companiesService.Get<List<Companies>>(null);

                CompaniesList.Clear();
                foreach (var companies in list)
                {
                    CompaniesList.Add(companies);

                }
            }
        }

    }
}

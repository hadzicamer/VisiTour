using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiTour.Model;
using Xamarin.Forms;

namespace VisiTour.Mobile.ViewModels
{
    public class ClassesViewModel
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

        public ICommand CompaniesCommand { get; set; }
        public ICommand ClassesCommand { get; set; }

        public async Task InitClasses()
        {
            var list = await _classesService.Get<List<FlightClasses>>(null);

        foreach(var classes in list)
            {
                ClassesList.Add(classes);
            }
        }

        public async Task InitCompanies()
        {
            var list = await _companiesService.Get<List<Companies>>(null);

            foreach (var companies in list)
            {
                CompaniesList.Add(companies);
            }
        }

    }
}

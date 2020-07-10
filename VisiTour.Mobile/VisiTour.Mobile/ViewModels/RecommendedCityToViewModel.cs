using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiTour.Model;
using VisiTour.Model.Requests;
using Xamarin.Forms;

namespace VisiTour.Mobile.ViewModels
{
    public class RecommendedCityToViewModel
    {
        private readonly APIService _recommendService = new APIService("Recommend");
        public RecommendedCityToViewModel()
        {
            RecommendCommand = new Command(async () => await LoadRecommendedCityTo());
        }

        public ObservableCollection<Cities> RecommendList { get; set; } = new ObservableCollection<Cities>();
        public SpecialOffers Offers { get; set; }

        public ICommand RecommendCommand { get; set; }


        public async Task LoadRecommendedCityTo()
        {
            if (RecommendList.Count == 0)
            {
                var list = await _recommendService.Get<List<Cities>>(new RecommendSearchRequest()
                {
                    CityToID=(int)Offers.CityToId
                });
                RecommendList.Clear();
                foreach (var cities in list)
                {
                    RecommendList.Add(cities);
                }
            }
        }
    }
}

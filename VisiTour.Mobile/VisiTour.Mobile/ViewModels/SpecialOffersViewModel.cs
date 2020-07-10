using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VisiTour.Model;
using Xamarin.Forms;

namespace VisiTour.Mobile.ViewModels
{
    public class SpecialOffersViewModel : BaseViewModel
    {
        private readonly APIService _offersService = new APIService("SpecialOffers");


        public SpecialOffersViewModel(){

            OfferCommand = new Command(async () => await InitOffers());
        }

        public ObservableCollection<SpecialOffers> SpecialOffersList { get; set; } = new ObservableCollection<SpecialOffers>();



        private SpecialOffers _offers;
        public SpecialOffers Offers
        {
            get { return _offers; }
            set
            {
                _offers = value;
                OnPropertyChanged();
            }
        }
        public ICommand OfferCommand { get; set; }


        public async Task InitOffers()
        {
            if (SpecialOffersList.Count == 0)
            {
                var list = await _offersService.Get<List<SpecialOffers>>(null);

                SpecialOffersList.Clear();
                foreach (var offers in list)
                {
                    SpecialOffersList.Add(offers);
                }
            }

        }

    }
}

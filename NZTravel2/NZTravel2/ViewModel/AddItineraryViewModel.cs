using Xamarin.Forms;
using NZTravel2.Persistence;

namespace NZTravel2

{
    class AddItineraryViewModel : BaseFodyObservable
    {

        public AddItineraryViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Save = new Command(HandleSave);
            Cancel = new Command(HandleCancel);
        }

        private INavigation _navigation;
        public string TodoTitle { get; set; }

        public Command Save { get; set; }
        public async void HandleSave()
        {
            await App.ItineraryRepository.AddItem(new Itinerary { Title = TodoTitle });
            await _navigation.PopModalAsync();
        }

        public Command Cancel { get; set; }
        public async void HandleCancel()
        {
            await _navigation.PopModalAsync();
        }
    }
}
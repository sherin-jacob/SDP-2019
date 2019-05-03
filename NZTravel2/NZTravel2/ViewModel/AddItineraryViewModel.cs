using Xamarin.Forms;
using NZTravel2.Persistence;

namespace NZTravel2

{
    class AddItineraryViewModel : BaseFodyObservable
    {
        string placeName { get; set; }
        private INavigation _navigation;

        public AddItineraryViewModel(INavigation navigation, string PlaceName)
        {
            _navigation = navigation;
            placeName = PlaceName;
            Save = new Command(HandleSave);
            Cancel = new Command(HandleCancel);
        }

        public Command Save { get; set; }
        public async void HandleSave()
        {
            await App.ItineraryRepository.AddItem(new Itinerary { Title = placeName });
            await _navigation.PopModalAsync();
        }

        public Command Cancel { get; set; }
        public async void HandleCancel()
        {
            await _navigation.PopModalAsync();
            //need soemthing for if edit button pushed and then they press cancel
        }
    }
}
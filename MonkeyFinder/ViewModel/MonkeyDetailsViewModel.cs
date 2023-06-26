using MonkeyFinder.Pages;

namespace MonkeyFinder.ViewModel
{
    [QueryProperty(nameof(Monkey), "Monkey")]
	public partial class MonkeyDetailsViewModel : BaseViewModel
	{
        IMap _map;

        public MonkeyDetailsViewModel(IMap map)
        {
            _map = map;
        }

        [ObservableProperty]
        private Monkey _monkey;

        [RelayCommand]
        async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task OpenMapAsync()
        {
            try
            {
                await _map.OpenAsync(Monkey.Longitude, Monkey.Latitude, 
                    new MapLaunchOptions
                {
                        Name = Monkey.Name,
                        NavigationMode = NavigationMode.None
                }); ;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to open map: {ex.Message}", "OK");
            }
        }
    }
}

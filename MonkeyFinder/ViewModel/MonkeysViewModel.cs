using MonkeyFinder.Pages;
using MonkeyFinder.Services;

namespace MonkeyFinder.ViewModel
{
	public partial class MonkeysViewModel : BaseViewModel
	{
		MonkeyService _monkeyService;
        IConnectivity _connectivity;
        IGeolocation _geolocation;
		public ObservableCollection<Monkey> Monkeys { get; } = new ObservableCollection<Monkey>();

		public MonkeysViewModel(MonkeyService service, IConnectivity connectivity, IGeolocation geolocation)
		{
			Title = "Monkey Finder";
			_monkeyService = service;
            _connectivity = connectivity;
            _geolocation = geolocation;
		}

        [RelayCommand]
		async Task GetMonkeysAsync()
		{
			if (IsBusy) return;

            try
            {
                if(_connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("Internet Issue", "Check your internet and try again!", "Ok");
                    return;
                }

                IsBusy = true;

                var monkeys = await _monkeyService.GetMonkeys();

                if (Monkeys.Count != 0)
                    Monkeys.Clear();

                foreach (var monkey in monkeys)
                    Monkeys.Add(monkey);
            }
			catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]
        async Task GoToDetailsPageAsync(Monkey monkey)
        {
            if (monkey is null)
                return;

            await Shell.Current.GoToAsync(nameof(DetailsPage), true, new Dictionary<string, object>
            {
                {"Monkey", monkey }
            });
        }
    }
}

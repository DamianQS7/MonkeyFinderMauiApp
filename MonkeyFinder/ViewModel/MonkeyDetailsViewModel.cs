using MonkeyFinder.Pages;

namespace MonkeyFinder.ViewModel
{
    [QueryProperty(nameof(Monkey), "Monkey")]
	public partial class MonkeyDetailsViewModel : BaseViewModel
	{
        public MonkeyDetailsViewModel()
        {
        }

        [ObservableProperty]
        private Monkey _monkey;

        [RelayCommand]
        async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

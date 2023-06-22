namespace MonkeyFinder.ViewModel
{
	public partial class BaseViewModel : ObservableObject
	{
		public BaseViewModel()
		{

		}

		[ObservableProperty]
		private string _title;

		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(IsNotBusy))]
		private bool _isBusy;

		public bool IsNotBusy => !IsBusy;
	}
}

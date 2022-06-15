using maui_to_do.ViewModels;

namespace maui_to_do;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel mvm)
	{
		InitializeComponent();
		BindingContext = mvm;
	}
}


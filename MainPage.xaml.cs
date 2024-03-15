using MonopolyGUI.Classes;

namespace MonopolyGUI;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnLoadClick(object sender, EventArgs e)
	{
		HelperClass.Load();
		Navigation.PushModalAsync(new GamePage());
	}

	private void OnNewClicked(object sender, EventArgs e)
	{
        /////////////
        List<string> names = new List<string>();
        names.Add("Levi baba");
        names.Add("Szonja baba");
        HelperClass.NewGame(names);
        /////////////

        Navigation.PushModalAsync(new GamePage());
    }
}


using MonopolyGUI.Classes;

namespace MonopolyGUI;

public partial class StartMoneyPage : ContentPage
{
	Player selectedPlayer = null;
	public StartMoneyPage()
	{
		InitializeComponent();
		PlayersList.ItemsSource = HelperClass.GetPlayersNames();
	}

    private void PlayersList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        string selectedPlayerName = (string)PlayersList.SelectedItem;
        selectedPlayer = HelperClass.Sg.GetPlayerFromName(selectedPlayerName);
        EnsureChoice();
    }

    private void OnGameClicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new GamePage());
    }

	private void EnsureChoice()
	{
		StartMoneyLabel.IsVisible = false;
		PlayersList.IsVisible = false;
		EnsureBtnHolder.IsVisible = true;
		EnsureLabel.IsVisible = true;
		EnsureLabel.Text = $"{selectedPlayer.Name} ment at a start mezon?";
	}

    private void EnsureOkBtn_Clicked(object sender, EventArgs e)
    {
		HelperClass.Sg.StartTile(selectedPlayer);
		Navigation.PushModalAsync(new GamePage());
    }

    private void EnsureNoBtn_Clicked(object sender, EventArgs e)
    {
		StartMoneyLabel.IsVisible = true;
		PlayersList.IsVisible = true;
		EnsureBtnHolder.IsVisible = false;
		EnsureLabel.IsVisible = false;
    }

}
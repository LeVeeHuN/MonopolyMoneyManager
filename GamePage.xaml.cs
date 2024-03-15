using MonopolyGUI.Classes;

namespace MonopolyGUI;

public partial class GamePage : ContentPage
{
	public GamePage()
	{
		InitializeComponent();

		if (HelperClass.Sg != null)
		{
            GameNameLabel.Text = HelperClass.Sg.SaveName;
			ShowPlayerData();
        }
		else
		{
			GameNameLabel.Text = "Nem letezo mentes!";
		}
		HelperClass.Save();
	}

	private void ShowPlayerData()
	{
		for (int i = 0; i < HelperClass.Sg.Players.Count; i++)
		{
			if (HelperClass.Sg.Players[i].IsReal)
			{
				if (i == 0)
				{
					Player1Label.IsVisible = true;
					Player1Label.Text = $"{HelperClass.Sg.Players[i].Name}: {HelperClass.Sg.Players[i].Balance}";
				}
				else if (i == 1)
				{
					Player2Label.IsVisible = true;
					Player2Label.Text = $"{HelperClass.Sg.Players[i].Name}: {HelperClass.Sg.Players[i].Balance}";
				}
				else if (i == 2)
				{
                    Player3Label.IsVisible = true;
					Player3Label.Text = $"{HelperClass.Sg.Players[i].Name}: {HelperClass.Sg.Players[i].Balance}";
				}
				else if (i == 3)
				{
                    Player4Label.IsVisible = true;
					Player1Label.Text = $"{HelperClass.Sg.Players[i].Name}: {HelperClass.Sg.Players[i].Balance}";
				}
			}
		}
	}

	private void OnAddMoneyClick(object sender, EventArgs e)
	{
		Navigation.PushModalAsync(new AddMoneyPage());
	}

	private void OnRemoveMoneyClicked(object sender, EventArgs e)
	{
		Navigation.PushModalAsync(new RemoveMoneyPage());
	}

	private void OnTransferClicked(object sender, EventArgs e)
	{
		Navigation.PushModalAsync(new TransferPage());
	}

	private void OnStartClicked(object sender, EventArgs e)
	{
		Navigation.PushModalAsync(new StartMoneyPage());
	}
}
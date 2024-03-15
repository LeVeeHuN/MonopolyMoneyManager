using MonopolyGUI.Classes;

namespace MonopolyGUI;

public partial class RemoveMoneyPage : ContentPage
{
	Player playerToRemoveFrom = null;
    string beforeValue = "0";
	public RemoveMoneyPage()
	{
		InitializeComponent();
		PlayersList.ItemsSource = HelperClass.GetPlayersNames();
        MoneyEntry.Text = "0";
	}

    private void PlayersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		string selectedPlayerName = (string)PlayersList.SelectedItem;
		Player selectedPlayer = HelperClass.Sg.GetPlayerFromName(selectedPlayerName);
		playerToRemoveFrom = selectedPlayer;
		RemoveMoneyLabel.Text = RemoveMoneyLabel.Text + $": {selectedPlayer.Name}";
		PlayersList.IsVisible = false;
		RemoveMoneyCommLabel.IsVisible = true;
		MoneyEntry.IsVisible = true;
		MoneyRemoveBtn.IsVisible = true;
        MoneyButtons.IsVisible = true;
    }

	private void OnRemoveMoneyClicked(object sender, EventArgs e)
	{
		int moneyToRemove = 0;
		try
		{
			moneyToRemove = int.Parse(MoneyEntry.Text);
		}
		catch
		{
			RemoveMoneyCommLabel.Text = "Ervenyes erteket adj meg!";
			return;
		}
		if (HelperClass.Sg.RemoveMoney(playerToRemoveFrom, moneyToRemove))
		{
			Navigation.PushModalAsync(new GamePage());
		}
		RemoveMoneyCommLabel.Text = "Nem all rendelkezesre eleg fedezet!";
	}

	private void OnGameClicked(object sender, EventArgs e)
	{
		Navigation.PushModalAsync(new GamePage());
	}

    private void Plus10KBtn_Clicked(object sender, EventArgs e)
    {
        int currentValue = int.Parse(MoneyEntry.Text);
        currentValue += 10_000;
        MoneyEntry.Text = currentValue.ToString();
    }

    private void Plus100KBtn_Clicked(object sender, EventArgs e)
    {
        int currentValue = int.Parse(MoneyEntry.Text);
        currentValue += 100_000;
        MoneyEntry.Text = currentValue.ToString();
    }

    private void Plus500KBtn_Clicked(object sender, EventArgs e)
    {
        int currentValue = int.Parse(MoneyEntry.Text);
        currentValue += 500_000;
        MoneyEntry.Text = currentValue.ToString();
    }

    private void Plus1MBtn_Clicked(object sender, EventArgs e)
    {
        int currentValue = int.Parse(MoneyEntry.Text);
        currentValue += 1_000_000;
        MoneyEntry.Text = currentValue.ToString();
    }

    private void Minus10KBtn_Clicked(object sender, EventArgs e)
    {
        int currentValue = int.Parse(MoneyEntry.Text);
        if (currentValue - 10_000 < 0)
        {
            currentValue = 0;
        }
        else
        {
            currentValue -= 10_000;
        }
        MoneyEntry.Text = currentValue.ToString();
    }

    private void Minus100KBtn_Clicked(object sender, EventArgs e)
    {
        int currentValue = int.Parse(MoneyEntry.Text);
        if (currentValue - 100_000 < 0)
        {
            currentValue = 0;
        }
        else
        {
            currentValue -= 100_000;
        }
        MoneyEntry.Text = currentValue.ToString();
    }

    private void Minus500kBtn_Clicked(object sender, EventArgs e)
    {
        int currentValue = int.Parse(MoneyEntry.Text);
        if (currentValue - 500_000 < 0)
        {
            currentValue = 0;
        }
        else
        {
            currentValue -= 500_000;
        }
        MoneyEntry.Text = currentValue.ToString();
    }

    private void Minus1MBtn_Clicked(object sender, EventArgs e)
    {
        int currentValue = int.Parse(MoneyEntry.Text);
        if (currentValue - 1_000_000 < 0)
        {
            currentValue = 0;
        }
        else
        {
            currentValue -= 1_000_000;
        }
        MoneyEntry.Text = currentValue.ToString();
    }

    private void MoneyEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        try
        {
            int.Parse(MoneyEntry.Text);
        }
        catch
        {
            MoneyEntry.Text = beforeValue;
        }
        beforeValue = MoneyEntry.Text;
    }
}
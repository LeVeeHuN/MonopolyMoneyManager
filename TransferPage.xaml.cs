using MonopolyGUI.Classes;

namespace MonopolyGUI;

public partial class TransferPage : ContentPage
{
	Player playerFrom = null;
	Player playerTo = null;
    string beforeValue = "0";

    public TransferPage()
	{
		InitializeComponent();
		PlayerFromList.ItemsSource = HelperClass.GetPlayersNames();
        MoneyEntry.Text = "0";
	}

    private void PlayerFromList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		string playerFromName = (string)PlayerFromList.SelectedItem;
		Player selectedPlayerFrom = HelperClass.Sg.GetPlayerFromName(playerFromName);
		playerFrom = selectedPlayerFrom;
		PlayerFromList.IsVisible = false;
		PlayerToList.IsVisible = true;
		TransferCommLabel.IsVisible = true;
		TransferCommLabel.Text = $"{playerFrom.Name} -> ";

		List<string> newNames = new List<string>();
		foreach (string name in HelperClass.GetPlayersNames())
		{
			if (!name.Equals(playerFromName))
			{
				newNames.Add(name);
			}
		}
		PlayerToList.ItemsSource = newNames;

        if (newNames.Count == 1)
        {
            PlayerToList.IsVisible = false;
            playerTo = HelperClass.Sg.GetPlayerFromName(newNames[0]);
            TransferCommLabel.Text = TransferCommLabel.Text + playerTo.Name;
            MoneyEntry.IsVisible = true;
            MoneyEntryBtn.IsVisible = true;
            ErrorLabel.IsVisible = true;
            MoneyButtons.IsVisible = true;
        }
    }

    private void PlayerToList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		string playerToName = (string)PlayerToList.SelectedItem;
		playerTo = HelperClass.Sg.GetPlayerFromName(playerToName);
		PlayerToList.IsVisible = false;
		TransferCommLabel.Text = TransferCommLabel.Text + playerTo.Name;
		MoneyEntry.IsVisible = true;
		MoneyEntryBtn.IsVisible = true;
		ErrorLabel.IsVisible = true;
        MoneyButtons.IsVisible = true;
    }

    private void MoneyEntry_Completed(object sender, EventArgs e)
    {
		int moneyToTransfer = 0;
		try
		{
			moneyToTransfer = int.Parse(MoneyEntry.Text);
		}
		catch
		{
			ErrorLabel.Text = "Ervenyes mennyiseget adj meg!";
			return;
		}

		if (HelperClass.Sg.TransferMoney(playerFrom, playerTo, moneyToTransfer))
		{
			Navigation.PushModalAsync(new GamePage());
		}
		ErrorLabel.Text = "Nem all rendelkezesre elegendo egyenleg!";
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
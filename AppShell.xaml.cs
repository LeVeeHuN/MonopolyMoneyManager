namespace MonopolyGUI;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(GamePage), typeof(GamePage));
		Routing.RegisterRoute(nameof(AddMoneyPage), typeof(AddMoneyPage));
		Routing.RegisterRoute(nameof(RemoveMoneyPage), typeof(RemoveMoneyPage));
		Routing.RegisterRoute(nameof(TransferPage), typeof(TransferPage));
		Routing.RegisterRoute(nameof(StartMoneyPage), typeof(StartMoneyPage));
	}
}

namespace Health;

public partial class Menu : ContentPage
{
	bool CalculosAtivo = false;

	public Menu()
	{
		InitializeComponent();
    }

    private void CalculosButton(object sender, EventArgs e)
    {
		if(CalculosAtivo == false)
		{
			CalculosAtivo = true;
			CalculoItems.IsVisible = true;
		}
		else if(CalculosAtivo == true)
		{
            CalculosAtivo = false;
            CalculoItems.IsVisible = false;
        }
    }

    private void IMC(object sender, EventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new TelaIMC());
    }

    private void TMB(object sender, EventArgs e)
    {
        ((FlyoutPage)App.Current.MainPage).Detail = new NavigationPage(new TelaTMB());
    }

}
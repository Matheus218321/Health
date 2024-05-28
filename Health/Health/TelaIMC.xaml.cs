using System.Text.RegularExpressions;

namespace Health;

public partial class TelaIMC : ContentPage
{
	public TelaIMC()
	{
		InitializeComponent();
    }

    private void Calcular(object sender, EventArgs e)
    {
		if (Peso.Text != "" && Peso.Text != null && Altura.Text != "" && Altura.Text != null)
		{
			double PesoInt = Convert.ToDouble(Peso.Text);
			double AlturaInt = Convert.ToDouble(Altura.Text);

			double IMC = PesoInt / ((AlturaInt / 100) * (AlturaInt / 100));

			Resultado.Text = "IMC: " + IMC.ToString("F2");

			if(Altura.Text == "0")
			{
				Resultado.Text = "Infinito";
            }

            else
            {
                if(IMC < 18.5)
                {
                    Categoria.Text = "Magreza";
                }

                if(IMC == 18.5 || IMC == 24.9 || (IMC < 24.9 && IMC > 18.5))
                {
                    Categoria.Text = "Normal";
                }

                if(IMC == 25 || IMC == 29.9 || (IMC < 29.9 && IMC > 25))
                {
                    Categoria.Text = "Sobrepeso";
                }

                if(IMC == 30 || IMC == 34.9 || (IMC < 34.9 && IMC > 30))
                {
                    Categoria.Text = "Obesidade Grau |";
                }

                if(IMC == 35 || IMC == 39.9 || (IMC < 39.9 && IMC > 35))
                {
                    Categoria.Text = "Obesidade Grau ||";
                }

                if(IMC > 40)
                {
                    Categoria.Text = "Obesidade Grau |||";
                }
            }
		}
    }

    private void OnNumericEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            string newText = e.NewTextValue;

            // Remove caracteres não numéricos usando expressão regular
            string filteredText = Regex.Replace(newText, @"\D", "");

            // Se o texto filtrado for diferente do novo texto, atualize o texto do Entry
            if (newText != filteredText)
            {
                entry.Text = filteredText;
            }
        }
    }

}
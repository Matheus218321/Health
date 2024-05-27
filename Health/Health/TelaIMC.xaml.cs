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

			double IMC = PesoInt / (AlturaInt * AlturaInt);

			Resultado.Text = "IMC: " + IMC.ToString("F2");

			if(Altura.Text == "0")
			{
				Resultado.Text = "Infinito";
			}
		}
    }

    private void OnNumericEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            string newText = e.NewTextValue;

            // Remove caracteres inválidos usando expressão regular
            string filteredText = Regex.Replace(newText, @"[^0-9\.,]", "");

            // Verifique se há múltiplas ocorrências de vírgula ou ponto decimal
            int commaCount = filteredText.Count(c => c == ',');
            int periodCount = filteredText.Count(c => c == '.');
            if (commaCount > 1 || periodCount > 1)
            {
                // Se houver múltiplas ocorrências, mantenha apenas a primeira
                filteredText = filteredText.Replace(",", "").Replace(".", "");
            }

            // Se o texto filtrado for diferente do novo texto, atualize o texto do Entry
            if (newText != filteredText)
            {
                entry.Text = filteredText;
            }
        }
    }
}
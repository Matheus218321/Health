using Microsoft.Maui.Platform;
using System.Text.RegularExpressions;

namespace Health;

public partial class TelaTMB : ContentPage
{
	public TelaTMB()
	{
		InitializeComponent();
        Genero.SelectedItem = "";
	}

    private void OnNumericEntryTextChanged(object sender, TextChangedEventArgs e)
    {
        if (sender is Entry entry)
        {
            string newText = e.NewTextValue;

            // Remove caracteres inv�lidos usando express�o regular
            string filteredText = Regex.Replace(newText, @"[^0-9\.,]", "");

            // Verifique se h� m�ltiplas ocorr�ncias de v�rgula ou ponto decimal
            int commaCount = filteredText.Count(c => c == ',');
            int periodCount = filteredText.Count(c => c == '.');
            if (commaCount > 1 || periodCount > 1)
            {
                // Se houver m�ltiplas ocorr�ncias, mantenha apenas a primeira
                filteredText = filteredText.Replace(",", "").Replace(".", "");
            }

            // Se o texto filtrado for diferente do novo texto, atualize o texto do Entry
            if (newText != filteredText)
            {
                entry.Text = filteredText;
            }
        }
    }



    private void Calcular(object sender, EventArgs e)
    {
        if (Idade.Text != "" && Altura.Text != "" && Peso.Text != "" && Idade.Text != null && Altura.Text != null && Peso.Text != null && Genero.SelectedItem.ToString() != "" && Genero.SelectedItem.ToString() != null)
        {
            double Taxa = 0;
            double IdadeInt = Convert.ToDouble(Idade.Text);
            double AlturaInt = Convert.ToDouble(Altura.Text);
            double PesoInt = Convert.ToDouble(Peso.Text);

            if (Genero.SelectedItem.ToString() == "Masculino")
            {
                Taxa = 66.5 + (PesoInt * 13.05) + (AlturaInt * 5) - (IdadeInt * 6.8);
            }

            if (Genero.SelectedItem.ToString() == "Feminino")
            {
                Taxa = 665.1 + (PesoInt * 9.56) + (AlturaInt * 1.8) - (IdadeInt * 4.7);
            }

            Resultado.Text = "TMB: " + Taxa.ToString();
        }
    }
}
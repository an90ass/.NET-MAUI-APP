namespace gorselProOdev1;

public partial class RenkSececi : ContentPage
{
	public RenkSececi()
	{
		InitializeComponent();
	}
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int red = (int)redSlider.Value;
        int green = (int)greenSlider.Value;
        int blue = (int)blueSlider.Value;

        Color clr = Color.FromRgb(red, green, blue);
        renkCodeLabel.Text = clr.ToArgbHex();

        btn1.BackgroundColor = clr;
        //fram_renk.BackgroundColor = clr;
        fram_kod_kopya.BorderColor = clr;
        bak.Background = clr;

    }
    private void Button_Clicked(object sender, EventArgs e)
    {
        // Generate random RGB values
        Random rand = new Random();
        int randomRed = rand.Next(0, 256);
        int randomGreen = rand.Next(0, 256);
        int randomBlue = rand.Next(0, 256);

        // Set the values to the sliders
        redSlider.Value = randomRed;
        greenSlider.Value = randomGreen;
        blueSlider.Value = randomBlue;

        


    }
    private void ImageButton_Clicked(object sender, EventArgs e)
{
        var colorCode = renkCodeLabel.Text;
        Clipboard.SetTextAsync(colorCode);
        DisplayAlert("Kopyalandı", $"Renk kodu '{colorCode}' kopyalandı.", "Tamam");

    }

}
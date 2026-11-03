namespace AU26_Counter.Views;

public partial class CounterCreatePage : ContentPage
{
	public CounterCreatePage()
	{
		InitializeComponent();
	}

    private async void createButtonClicked(object sender, EventArgs e)
    {
        if (TextInput.Text == "" || ValueInput.Text == "")
        {
            DisplayAlert("Input error", "both fields need to be filled", "ok");
        } else if (!ValueInput.Text.All(char.IsDigit)) {
            DisplayAlert("Input error", "counter value must be a number", "ok");
        } else
        {
            Models.Counter counter = new Models.Counter();
            string appDataPath = FileSystem.AppDataDirectory;
            string randomFileName = $"{Path.GetRandomFileName()}.counters.txt";
            counter.Filename = Path.Combine(appDataPath, randomFileName);
            counter.Text = TextInput.Text;
		    counter.CountValue = int.Parse(ValueInput.Text);
            File.WriteAllText(counter.Filename, counter.CountValue + ";" + counter.Text);
            await Shell.Current.GoToAsync("..");
        }
    }
}
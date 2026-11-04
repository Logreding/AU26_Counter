namespace AU26_Counter.Views;

public partial class CounterCreatePage : ContentPage
{
	public CounterCreatePage()
	{
		InitializeComponent();
	}

    private async void createButtonClicked(object sender, EventArgs e)
    {
        if (!int.TryParse(ValueInput.Text, out _))
        {
            DisplayAlert("Input error", "counter value must be a number", "ok");
        } else
        {
            Models.Counter counter = new Models.Counter();
            string appDataPath = FileSystem.AppDataDirectory;
            string randomFileName = $"{Path.GetRandomFileName()}.counters.txt";
            counter.Filename = Path.Combine(appDataPath, randomFileName);
            counter.Text = TextInput.Text;
		    counter.CountValue = int.Parse(ValueInput.Text);
            string[] textToWrite = {counter.CountValue.ToString(), counter.Text};
            File.WriteAllLines(counter.Filename, textToWrite);
            await Shell.Current.GoToAsync("..");
        }
    }
}
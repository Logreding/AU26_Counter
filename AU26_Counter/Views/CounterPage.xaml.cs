using AU26_Counter.Models;
using System.Threading.Tasks;

namespace AU26_Counter.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class CounterPage : ContentPage
{
    public string ItemId
    {
        set { LoadCounter(value); }
    }
    public CounterPage()
	{
        InitializeComponent();
    }

    private void LoadCounter(String fileName)
    {
        Models.Counter counterModel = new();
        counterModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            counterModel.CountValue = int.Parse(File.ReadAllText(fileName).Split(";")[0]);
            counterModel.Text = File.ReadAllText(fileName).Split(';')[1];
        } else
        {
            counterModel.CountValue = 0;
        }

        BindingContext = counterModel;
    }

    public void OnCounterAddClicked(object sender, EventArgs e)
    {
        Models.Counter counter = (Models.Counter)BindingContext;
        counter.AddCount();
        cntr.Text = counter.CountValue.ToString();
        counter.Text = CounterName.Text;
        File.WriteAllText(counter.Filename, counter.CountValue + ";" + counter.Text);
    }

    public void OnCounterDecreaseClicked (object sender, EventArgs e)
    { 
        Models.Counter counter = (Models.Counter)BindingContext;
        counter.DecreaseCount();
        cntr.Text = counter.CountValue.ToString();
        counter.Text = CounterName.Text;
        File.WriteAllText(counter.Filename, counter.CountValue + ";" + counter.Text);
    }

    private void NameChanged(object sender, TextChangedEventArgs e)
    {
        Models.Counter counter = (Models.Counter)BindingContext;
        counter.Text = CounterName.Text;
        File.WriteAllText(counter.Filename, counter.CountValue + ";" + counter.Text);
    }

    private async void returnButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AllCountersPage));
    }
}
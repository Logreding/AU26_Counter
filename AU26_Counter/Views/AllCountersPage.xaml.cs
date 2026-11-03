using AU26_Counter.Models;

namespace AU26_Counter.Views;

public partial class AllCountersPage : ContentPage
{
	public AllCountersPage()
	{
		InitializeComponent();

        BindingContext = new Models.AllCounters();
    }
    protected override void OnAppearing()
    {
        ((Models.AllCounters)BindingContext).LoadCounters();
    }
    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(CounterCreatePage));
    }

    private async void CountersCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var counter = (Models.Counter)e.CurrentSelection[0];

            await Shell.Current.GoToAsync($"{nameof(CounterPage)}?{nameof(CounterPage.ItemId)}={counter.Filename}");

            CountersCollection.SelectedItem = null;
        }
    }
}
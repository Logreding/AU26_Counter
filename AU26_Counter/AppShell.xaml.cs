namespace AU26_Counter
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.CounterPage), typeof(Views.CounterPage));
            Routing.RegisterRoute(nameof(Views.AllCountersPage), typeof(Views.AllCountersPage));
            Routing.RegisterRoute(nameof(Views.CounterCreatePage), typeof(Views.CounterCreatePage));
        }
    }
}

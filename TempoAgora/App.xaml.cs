using System.Globalization;

namespace TempoAgora
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            var culture = new CultureInfo("pt-BR");
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}
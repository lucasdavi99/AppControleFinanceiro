using AppControleFinanceiro.Views;

namespace AppControleFinanceiro
{
    public partial class App : Application
    {
        private readonly TransactionList _list;

        public App(TransactionList list)
        {
            InitializeComponent();
            _list = list;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(_list));
        }
    }
}
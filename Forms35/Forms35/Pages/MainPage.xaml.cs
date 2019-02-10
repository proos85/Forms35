using Forms35.Models;

namespace Forms35.Pages
{
    public partial class MainPage
    {
        public MainPage()
        {
            var vm = new MainPageViewModel(this)
            {
                PhoneNumber = "0682781934"
            };
            BindingContext = vm;

            InitializeComponent();
        }
    }
}

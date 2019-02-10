using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Forms35.Models
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        private readonly ContentPage _page;
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public ICommand CallCommand { get; set; }

        public MainPageViewModel(ContentPage page)
        {
            _page = page;
            CallCommand = new Command(CallNumber);
        }

        private async void CallNumber()
        {
            try
            {
                PhoneDialer.Open(PhoneNumber);
            }
            catch (ArgumentNullException ex)
            {
                await _page.DisplayAlert("Error", ex.ToString(), "OK");
            }
            catch (FeatureNotSupportedException ex)
            {
                await _page.DisplayAlert("Error", ex.ToString(), "OK");
            }
            catch (Exception ex)
            {
                await _page.DisplayAlert("Error", ex.ToString(), "OK");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
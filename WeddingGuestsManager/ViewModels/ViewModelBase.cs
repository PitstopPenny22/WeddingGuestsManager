using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WeddingGuestsManager.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                if (_isBusy == value)
                {
                    return;
                }
                _isBusy = value;
                OnPropertyChanged();
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected async Task SetBusyWhilstDoingAction(Func<Task> actionToDo)
        {
            try
            {
                IsBusy = true;
                await actionToDo();
            }
            catch (Exception ex)
            {
                // TODO DS log
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
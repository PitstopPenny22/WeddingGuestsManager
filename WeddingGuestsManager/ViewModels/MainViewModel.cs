using GalaSoft.MvvmLight.CommandWpf;
using GuestsManagerService.Interfaces;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeddingGuestsManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IGuestsServiceWcfClient _guestsServiceClient;

        #region Properties

        public GuestsManagerViewModel GuestsManager { get; set; }
        public TablePlannerViewModel TablePlanner { get; set; }
        public ICommand InitCommand { get; set; }

        #endregion

        public MainViewModel(IGuestsServiceWcfClient guestsServiceWcfClient)
        {
            _guestsServiceClient = guestsServiceWcfClient;
            GuestsManager = new GuestsManagerViewModel(_guestsServiceClient);
            TablePlanner = new TablePlannerViewModel();
            InitCommand = new RelayCommand(async () => await Initialize());
        }

        private async Task Initialize()
        {
            await SetBusyWhilstDoingAction(() => GuestsManager.LoadAllHouseholdsAndAllGuests());
        }
    }
}
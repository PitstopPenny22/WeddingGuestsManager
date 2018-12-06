using System.Collections.ObjectModel;
using System.Linq;
using WeddingGuestsManager.ViewModels.SeatPlan;

namespace WeddingGuestsManager.ViewModels.SeatPlan
{
    public class TablePlannerViewModel : ViewModelBase
    {
        private const int NumberOfTables = 16;
        private const int NumberOfSeats = 50;
    

        public ObservableCollection<SeatViewModel> Seats { get; set; }
        public ObservableCollection<TableViewModel> Tables { get; set; }

        public TablePlannerViewModel()
        {
            InitialiseTables();
            InitialiseSeats();
        }

        private void InitialiseTables()
        {
            Tables = new ObservableCollection<TableViewModel>(Enumerable.Range(1, NumberOfTables).Select(tableNumber => new TableViewModel(tableNumber)));
        }

        private void InitialiseSeats()
        {
            Seats = new ObservableCollection<SeatViewModel>(Enumerable.Range(1, NumberOfSeats).Select(seatNumber => new SeatViewModel(seatNumber)));
        }
    }
}

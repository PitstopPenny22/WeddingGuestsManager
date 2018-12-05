using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WeddingGuestsManager.ViewModels
{
    public class TablePlannerViewModel : ViewModelBase
    {
        private const int NumberOfSeats = 50;
        public ObservableCollection<SeatViewModel> Seats { get; set; }

        public TablePlannerViewModel()
        {
            InitialiseSeats();
        }

        private void InitialiseSeats()
        {
            Seats = new ObservableCollection<SeatViewModel>(Enumerable.Range(1, NumberOfSeats).Select(seatNumber => new SeatViewModel(seatNumber)));
        }
    }
}

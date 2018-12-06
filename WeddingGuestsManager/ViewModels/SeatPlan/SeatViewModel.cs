namespace WeddingGuestsManager.ViewModels.SeatPlan
{
    public class SeatViewModel : ViewModelBase
    {
        private GuestViewModel m_assignedGuest;
        private int _canvasX;
        private int _canvasY;
        private int _seatNumber;
        private static int _numberOfTablesInARow = 8;
        private static int _numberOfSeatsPerTable = 3;
        private static int _numberOfRows = 2;
        private static int _topSeatLeftX = 100;
        private static int _topSeatLeftY = 110;
        private static int _seatMargin = 7;
        private static int _tableMargin = 4;

        public int SeatHeight { get => 25; }
        public int SeatWidth { get => 25; }
        public int SeatNumber
        {
            get => _seatNumber;
            set
            {
                _seatNumber = value;
                OnPropertyChanged();
            }
        }
        public GuestViewModel AssignedGuest
        {
            get => m_assignedGuest;
            set
            {
                m_assignedGuest = value;
                OnPropertyChanged();
            }
        }
        public int CanvasX
        {
            get => _canvasX;
            set
            {
                _canvasX = value;
                OnPropertyChanged();
            }
        }
        public int CanvasY
        {
            get => _canvasY;
            set
            {
                _canvasY = value;
                OnPropertyChanged();
            }
        }

        public SeatViewModel(int seatNumber)
        {
            SeatNumber = seatNumber;
            var seatSpace = SeatWidth + _seatMargin;

            var tableNumber = ((seatNumber - 1) / _numberOfSeatsPerTable) + 1; // this is only suitable for seats on the rows
            if (seatNumber > (_numberOfTablesInARow * _numberOfSeatsPerTable * _numberOfRows)) // seats at the edge of the table (49 - 50)
            {
                CanvasX = _topSeatLeftX - 40;
                CanvasY = _topSeatLeftY + 40 + ((seatNumber - (_numberOfTablesInARow * _numberOfSeatsPerTable * _numberOfRows)) * seatSpace);
            }
            else if (seatNumber > (_numberOfTablesInARow * _numberOfSeatsPerTable)) // seats on the second row (25 - 48)
            {
                CanvasX = _topSeatLeftX + (seatSpace * ((seatNumber - (_numberOfSeatsPerTable * _numberOfTablesInARow)) - 1)) + ((tableNumber - _numberOfTablesInARow) * _tableMargin);
                CanvasY = _topSeatLeftY + SeatHeight + _seatMargin + 130;
            }
            else // seats on top row (1 - 24)
            {
                CanvasX = _topSeatLeftX + (seatSpace * (seatNumber - 1)) + (tableNumber * _tableMargin);
                CanvasY = _topSeatLeftY;
            }
        }
    }
}
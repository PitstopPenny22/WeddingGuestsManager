namespace WeddingGuestsManager.ViewModels
{
    public class SeatViewModel : ViewModelBase
    {
        private GuestViewModel m_assignedGuest;

        public int SeatNumber { get; set; }
        public GuestViewModel AssignedGuest
        {
            get => m_assignedGuest;
            set
            {
                m_assignedGuest = value;
                OnPropertyChanged();
            } 
        }

        public SeatViewModel(int seatNumber)
        {
            SeatNumber = seatNumber;
        }
    }
}
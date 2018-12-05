using GuestsShared.Enums;
using GuestsShared.Models;

namespace WeddingGuestsManager.ViewModels
{
    public class GuestViewModel : ViewModelBase
    {
        #region Fields

        private string _firstName;
        private string _lastName;
        private bool _isChild;
        private HouseholdViewModel _selectedHousehold;

        #endregion

        #region Properties

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            } 
        }
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public bool IsChild
        {
            get => _isChild;
            set
            {
                _isChild = value;
                OnPropertyChanged();
            } 
        }
        public int? SeatNumber { get; set; }
        public int RsvpStatusId { get; set; }
        public string DietaryRequirements { get; set; }
        public string SongRequest { get; set; }
        public bool NeedsTransport { get; set; }
        public HotelRequirement HotelRequirement { get; set; }
        public HouseholdViewModel SelectedHousehold
        {
            get => _selectedHousehold;
            set
            {
                _selectedHousehold = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public GuestViewModel(GuestModel guestModel = null, HouseholdViewModel householdViewModel = null)
        {
            if (guestModel == null)
            {
                return;
            }
            FirstName = guestModel.FirstName;
            LastName = guestModel.LastName;
            IsChild = guestModel.IsChild;
            
            SelectedHousehold = householdViewModel;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + (IsChild ? "(child)" : string.Empty);
        }
    }
}

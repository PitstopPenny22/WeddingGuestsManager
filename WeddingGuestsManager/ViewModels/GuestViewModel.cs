using System;
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
        private RsvpOption _rsvpStatusId;
        private int? _seatNumber;

        #endregion

        #region Properties

        public Guid Id { get; }
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
        public int? SeatNumber
        {
            get => _seatNumber;
            set
            {
                _seatNumber = value;
                OnPropertyChanged();
            }
        }
        public RsvpOption RsvpStatusId
        {
            get => _rsvpStatusId;
            set
            {
                _rsvpStatusId = value;
                OnPropertyChanged();
            }
        }
        public string DietaryRequirements { get; }
        public string SongRequest { get; }
        public bool NeedsTransport { get; }
        public HotelRequirement HotelRequirement { get; }
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
            Id = guestModel.Id;
            FirstName = guestModel.FirstName;
            LastName = guestModel.LastName;
            IsChild = guestModel.IsChild;
            SeatNumber = guestModel.SeatNumber;
            RsvpStatusId = (RsvpOption)guestModel.RsvpStatusId;
            DietaryRequirements = guestModel.DietaryRequirements;
            SongRequest = guestModel.SongRequest;
            NeedsTransport = guestModel.NeedsTransport;
            HotelRequirement = guestModel.HotelRequirement;
            SelectedHousehold = householdViewModel;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + (IsChild ? " (child)" : string.Empty);
        }
    }
}

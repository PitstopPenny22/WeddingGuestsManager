﻿using GuestsShared.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace WeddingGuestsManager.ViewModels
{
    public class HouseholdViewModel : ViewModelBase
    {
        internal Guid HouseholdId { get; private set; }
        private ObservableCollection<GuestViewModel> _guestsInHousehold;
        private string _rsvpUrl;

        public string EmailAddress { get; set; }
        public ObservableCollection<GuestViewModel> GuestsInHousehold
        {
            get => _guestsInHousehold;
            set
            {
                _guestsInHousehold = value;
                OnPropertyChanged();
            }
        }
        public string RsvpUrl
        {
            get => _rsvpUrl;
            set
            {
                _rsvpUrl = value;
                OnPropertyChanged();
            }
        }

        public HouseholdViewModel(HouseholdModel household)
        {
            EmailAddress = household.EmailAddress;
            HouseholdId = household.Id;
            GuestsInHousehold = new ObservableCollection<GuestViewModel>(
                household.GuestsInHousehold
                    .Select(guest => new GuestViewModel(guest, this))
                    .OrderBy(g => g.FirstName)
                    .ThenBy(g => g.LastName)
                    .ToList());
            RsvpUrl = "https://rsvpchrisdorielle.azurewebsites.net/" + HouseholdId;
        }
    }
}
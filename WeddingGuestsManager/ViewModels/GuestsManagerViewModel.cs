﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using GuestsManagerService.Interfaces;
using GuestsShared.Models;

namespace WeddingGuestsManager.ViewModels
{
    public class GuestsManagerViewModel : ViewModelBase
    {
        private readonly IGuestsServiceWcfClient _guestsServiceClient;

        #region Fields

        private bool _isAddNewGuestVisible;
        private ObservableCollection<GuestViewModel> _allGuests;
        private ObservableCollection<HouseholdViewModel> _allHouseholds;

        #endregion

        #region Properties

        public bool IsAddNewGuestVisible
        {
            get => _isAddNewGuestVisible;
            set
            {
                if (_isAddNewGuestVisible == value)
                {
                    return;
                }
                _isAddNewGuestVisible = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<GuestViewModel> AllGuests
        {
            get => _allGuests;
            private set
            {
                _allGuests = value;
                OnPropertyChanged();
            } 
        }
        public ObservableCollection<HouseholdViewModel> AllHouseholds
        {
            get => _allHouseholds;
            set
            {
                _allHouseholds = value;
                OnPropertyChanged();
            } 
        }
        public GuestViewModel NewGuestViewModel { get; set; }
        public ICommand AddNewGuestCommand { get; set; }
        public ICommand ShowAddNewGuestCommand { get; set; }
        public ICommand HideAddNewGuestCommand { get; set; }

        #endregion

        public GuestsManagerViewModel(IGuestsServiceWcfClient guestsServiceClient)
        {
            _guestsServiceClient = guestsServiceClient;
            AddNewGuestCommand = new RelayCommand(async() => await AddNewGuest());
            ShowAddNewGuestCommand = new RelayCommand(ShowAddNewGuest);
            HideAddNewGuestCommand = new RelayCommand(HideAddNewGuest);
            NewGuestViewModel = new GuestViewModel();
        }
     
        private void ShowAddNewGuest()
        {
            IsAddNewGuestVisible = true;
        }
        private void HideAddNewGuest()
        {
            ClearNewGuestDetails();
            IsAddNewGuestVisible = false;
        }
        private void ClearNewGuestDetails()
        {
            NewGuestViewModel.FirstName = NewGuestViewModel.LastName = string.Empty;
            NewGuestViewModel.IsChild = false;
            NewGuestViewModel.SelectedHousehold = null;
        }

        internal async Task LoadAllHouseholdsAndAllGuests()
        {
            await SetBusyWhilstDoingAction(async () =>
            {
                AllHouseholds = await RefreshHouseholdsFromService();
                AllGuests = await RefreshGuestsFromService();
            });
        }

        private async Task<ObservableCollection<GuestViewModel>> RefreshGuestsFromService()
        {
            var guestsModels = await Task.Run(() => _guestsServiceClient.GetAllGuests());
           
            return new ObservableCollection<GuestViewModel>(
                guestsModels.Select(model => new GuestViewModel(model, AllHouseholds.FirstOrDefault(household => household.HouseholdId == model.HouseholdId)))
                    .OrderBy(g => g.SelectedHousehold.EmailAddress)
                    .ThenBy(g => g.FirstName));
        }

        private async Task<ObservableCollection<HouseholdViewModel>> RefreshHouseholdsFromService()
        {
            var householdModels = await Task.Run(() => _guestsServiceClient.GetAllHouseholds());
            return new ObservableCollection<HouseholdViewModel>(householdModels.Select(model => new HouseholdViewModel(model)).OrderBy(h => h.EmailAddress));
        }

        private async Task AddNewGuest()
        {
            await SetBusyWhilstDoingAction(async () =>
            {
                await Task.Run(() =>
                    _guestsServiceClient.AddNewGuest(new GuestModel
                    {
                        FirstName = NewGuestViewModel.FirstName,
                        LastName = NewGuestViewModel.LastName,
                        IsChild = NewGuestViewModel.IsChild,
                        HouseholdId = NewGuestViewModel.SelectedHousehold.HouseholdId
                    }));
                await LoadAllHouseholdsAndAllGuests();
                HideAddNewGuestCommand.Execute(null);
            });
        }
    }
}
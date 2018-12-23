using System;
using System.Collections.Generic;
using GuestsShared.Models;

namespace GuestsManagerService.Interfaces
{
    public interface IGuestsServiceWcfClient
    {
        List<HouseholdModel> GetAllHouseholds();

        HouseholdModel GetHouseholdById(Guid householdId);

        List<GuestModel> GetAllGuests();

        GuestModel GetGuestById(Guid guestId);

        List<GuestModel> GetGuestsInHousehold(Guid householdId);

        bool UpdateSeatByGuestId(Guid id, int seatNumber);

        void AddNewGuest(GuestModel newGuestModel);

        void MarkHouseholdAsInvited(Guid householdId);
    }
}

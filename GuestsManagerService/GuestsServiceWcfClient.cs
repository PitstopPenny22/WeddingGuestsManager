using System;
using System.Collections.Generic;
using System.ServiceModel;
using GuestsManagerService.Interfaces;
using GuestsShared.Models;

namespace GuestsManagerService
{
    public class GuestsServiceWcfClient : WcfClientBase<IGuestsManagerServiceChannel>, IGuestsServiceWcfClient
    {
        public GuestsServiceWcfClient()
        {
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress("http://localhost:53215/GuestsService.svc?wsdl");

            WcfChannelFactory = new ChannelFactory<IGuestsManagerServiceChannel>(binding, endpoint);
        }

        public List<HouseholdModel> GetAllHouseholds()
        {
            return CallServiceClientSafely<List<HouseholdModel>>(channel => channel.GetAllHouseholds(), "An error occurred whilst calling GuestsService to get all households.");
        }

        public HouseholdModel GetHouseholdById(Guid householdId)
        {
            return CallServiceClientSafely<HouseholdModel>(channel => channel.GetHouseholdById(householdId), $"An error occurred whilst calling GuestsService to get household with Id {householdId}.");
        }

        public List<GuestModel> GetAllGuests()
        {
            return CallServiceClientSafely<List<GuestModel>>(channel => channel.GetAllGuests(), $"An error occurred whilst calling GuestsService to get all guests.");
        }

        public GuestModel GetGuestById(Guid guestId)
        {
            return CallServiceClientSafely<GuestModel>(channel => channel.GetGuestById(guestId), $"An error occurred whilst calling GuestsService to get guest with Id {guestId}.");
        }

        public List<GuestModel> GetGuestsInHousehold(Guid householdId)
        {
            return CallServiceClientSafely<List<GuestModel>>(channel => channel.GetGuestsInHousehold(householdId), $"An error occurred whilst calling GuestsService to get guest in household with Id {householdId}.");
        }

        public bool UpdateSeatByGuestId(Guid guestId, int seatNumber)
        {
            return CallServiceClientSafely<bool>(channel => channel.UpdateSeatByGuestId(guestId, seatNumber), $"An error occurred whilst calling GuestsService to update seat number to {seatNumber} for guest with Id {guestId}.");
        }

        public void AddNewGuest(GuestModel newGuestModel)
        {
            CallServiceClientSafely(channel => channel.AddNewGuest(newGuestModel), $"An error occurred whilst calling GuestsService to add a new guest for '{newGuestModel.FirstName} {newGuestModel.LastName}.");
        }

        public void MarkHouseholdAsInvited(Guid householdId)
        {
            CallServiceClientSafely(channel => channel.MarkHouseholdAsInvited(householdId), $"An error occurred whilst calling GuestsService to mark househould with Id '{householdId} as invited.");
        }
    }
}

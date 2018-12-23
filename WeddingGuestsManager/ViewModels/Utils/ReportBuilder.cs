using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingGuestsManager.ViewModels.Utils
{
    public static class ReportBuilder
    {
        static readonly string _pathBase = $"C:\\Wedding\\";

        private static string GetToday()
        {
            return DateTime.Now.ToString().Replace('/', '_').Replace(':', '-');
        }

        public static async Task GenerateDietaryRequirementsReport(ICollection<GuestViewModel> guests)
        {
            var path = _pathBase + $"DietaryRequirements_{GetToday()}.txt";

            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                var guestsWithDietaryRequirements = guests.Where(g => !string.IsNullOrEmpty(g.DietaryRequirements));
                foreach (var guest in guestsWithDietaryRequirements)
                {
                   await writer.WriteLineAsync($"{guest.FirstName} {guest.LastName} - {guest.DietaryRequirements}");
                }
            }
        }

        public static async Task GenerateSongRequirementsReport(ICollection<GuestViewModel> guests)
        {
            var path = _pathBase + $"SongRequests_{GetToday()}.txt";

            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                var guestsWithSongRequests = guests.Where(g => !string.IsNullOrEmpty(g.SongRequest));
                foreach (var guest in guestsWithSongRequests)
                {
                    await writer.WriteLineAsync($"{guest.FirstName} {guest.LastName} - {guest.SongRequest}");
                }
            }
        }

        public static async Task GenerateTransportRequirementReport(ICollection<GuestViewModel> guests)
        {
            var path = _pathBase + $"TransportRequirements_{GetToday()}.txt";

            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                await writer.WriteLineAsync("Guests who require transport from hotel to the venue: ");
                await writer.WriteLineAsync();
                var guestsWhoNeedTransport = guests.Where(g => g.NeedsTransport);
                foreach (var guest in guestsWhoNeedTransport)
                {
                    await writer.WriteLineAsync($"{guest.FirstName} {guest.LastName}");
                }
            }
        }

        public static async Task GenerateHotelRequirementReport(ICollection<GuestViewModel> guests)
        {
            var path = _pathBase + $"HotelRequirements_{GetToday()}.txt";

            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                await writer.WriteLineAsync("Guests who require hotel accommodation on Saturday only: ");
                await writer.WriteLineAsync();
                var saturdayOnly = guests.Where(g => g.HotelRequirement == GuestsShared.Enums.HotelRequirement.SaturdayOnly);
                foreach (var guest in saturdayOnly)
                {
                    await writer.WriteLineAsync($"{guest.FirstName} {guest.LastName}");
                }
                await writer.WriteLineAsync();
                await writer.WriteLineAsync();
                await writer.WriteLineAsync("Guests who require hotel accommodation on Friday and Saturday: ");
                var fridayAndSaturday = guests.Where(g => g.HotelRequirement == GuestsShared.Enums.HotelRequirement.FridayAndSaturday);
                foreach (var guest in fridayAndSaturday)
                {
                    await writer.WriteLineAsync($"{guest.FirstName} {guest.LastName}");
                }
            }
        }

        public static async Task GenerateFullReport(ICollection<GuestViewModel> guests)
        {
            var path = _pathBase + $"FullReport_{GetToday()}.txt";
            var guestsGroupedByHousehold = guests.GroupBy(g => g.SelectedHousehold.HouseholdId);
            FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                foreach (var guest in guests)
                {
                    await writer.WriteLineAsync($"{guest.FirstName} {guest.LastName} - {guest.RsvpStatus}");
                    await writer.WriteLineAsync($"Seat Number: {guest.SeatNumber}");
                    await writer.WriteLineAsync($"Is child: {guest.IsChild}");
                    await writer.WriteLineAsync($"Dietary Requirements: {guest.DietaryRequirements}");
                    await writer.WriteLineAsync($"Song Request: {guest.SongRequest}");
                    await writer.WriteLineAsync($"Hotel Requirement: {guest.HotelRequirement}");
                    await writer.WriteLineAsync($"Transport Requirement: {guest.NeedsTransport}");
                    await writer.WriteLineAsync();
                }
            }
        }
    }
}
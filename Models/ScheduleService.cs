using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mr_XL_Graduation.Services
{
    public class ScheduleService
    {
        public async Task<List<ScheduleItem>> GetWeeklyScheduleAsync(string username)
        {
            // Replace this with a database or API call that fetches schedule based on username.
            await Task.Delay(100);  // Simulate async delay.

            // Example schedule items (in real scenarios, filter by username)
            return new List<ScheduleItem>
    {
        new ScheduleItem { DayOfWeek = "Monday", TimeSlot = "08:00 AM - 09:00 AM", Subject = "Mathematics", Room = "Room 101" },
        new ScheduleItem { DayOfWeek = "Monday", TimeSlot = "09:00 AM - 10:00 AM", Subject = "Physics", Room = "Room 102" },
        new ScheduleItem { DayOfWeek = "Wednesday", TimeSlot = "10:00 AM - 11:00 AM", Subject = "Chemistry", Room = "Room 103" },
        // Add more items as needed
    };
        }

    }
}

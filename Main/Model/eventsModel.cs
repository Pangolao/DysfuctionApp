
namespace Dysfunction.Model
{
    public class eventsModel
    {
        private string id;
        private string name;
        private string description;
        private DateTime startDate;
        private DateTime? endDate;
        private TimeSpan? hour;

        public eventsModel(string id, string name, string description, DateTime startDate, DateTime? endDate, TimeSpan? hour)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.hour = hour;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime? EndDate { get => endDate; set => endDate = value; }
        public TimeSpan? Hour { get => hour; set => hour = value; }
    }
}

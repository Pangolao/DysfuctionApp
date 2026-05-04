namespace Dysfunction.Model
{
    public class periodModel
    {
        private int year;
        private string period;
        private DateTime startDate;
        private DateTime endDate;
        private List<string> asignatures;

        public periodModel(int year, string period, DateTime startDate, DateTime endDate, List<string> asignatures)
        {
            this.year = year;
            this.period = period;
            this.startDate = startDate;
            this.endDate = endDate;
            this.asignatures = asignatures;
        }
        public int Year { get => year; set => year = value; }
        public string Period { get => period; set => period = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime EndDate { get => endDate; set => endDate = value; }
        public List<string> Asignatures { get => asignatures; set => asignatures = value; }
    }
}

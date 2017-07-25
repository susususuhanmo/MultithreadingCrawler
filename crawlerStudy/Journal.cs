namespace crawlerStudy
{
    public class Journal
    {
        public string Year { get; set; }

        public string Issue { get; set; }

        public string JournalName { get; set; }


        public Journal( string year, string issue, string journalName)
        {
            Year = year;
            Issue = issue;
            JournalName = journalName;

        }

        public Journal(string journalName)
        {
            JournalName = journalName;
        }

        
            
    }
}
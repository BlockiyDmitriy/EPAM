namespace ATS.Models
{
    public class Connection
    {
        private PhoneNumber From { get; set; }
        private PhoneNumber To { get; set; }
        public Connection(PhoneNumber from, PhoneNumber to)
        {
            this.From = from;
            this.To = to;
        }


        public PhoneNumber GetNumberFrom() => From;
        public PhoneNumber GetNumberTo() => To;
    }
}

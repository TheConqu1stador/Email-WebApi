namespace testTask.Models
{
    public class Mail
    {
        public long Id { get; set; }
        public string Subject { get; set; }

        public string Body { get; set; }

        public string Recipient { get; set; }

        public DateTime SendDate { get; set; }

        public string Result { get; set; }

        public string? FailedMessage { get; set; }
    }
}
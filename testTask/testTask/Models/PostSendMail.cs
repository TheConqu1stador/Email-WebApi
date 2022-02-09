namespace testTask.Models
{
    public class PostSendMail
    {
        public string Subject { get; set; }

        public string Body { get; set; }

        public IReadOnlyCollection<string> Recipients { get; set; }
    }
}
namespace testTask.Models
{
    public class PostSendMail
    {
        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Тело сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Получатели сообщения
        /// </summary>
        public IReadOnlyCollection<string> Recipients { get; set; }
    }
}
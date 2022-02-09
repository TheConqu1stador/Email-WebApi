namespace testTask.Models
{
    public class PostSendMail
    {
        /// <summary>
        /// ���� ���������
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// ���� ���������
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// ���������� ���������
        /// </summary>
        public IReadOnlyCollection<string> Recipients { get; set; }
    }
}
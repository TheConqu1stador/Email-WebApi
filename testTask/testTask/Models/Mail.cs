namespace testTask.Models
{
    public class Mail
    {
        /// <summary>
        /// ID ���������
        /// </summary>
        public long Id { get; set; }

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
        public string Recipient { get; set; }

        /// <summary>
        /// ���� ��������
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// ��������� �������� (OK | Failed)
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// ��������� �� ������
        /// </summary>
        public string? FailedMessage { get; set; }
    }
}
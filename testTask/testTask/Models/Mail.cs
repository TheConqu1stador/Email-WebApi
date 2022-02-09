namespace testTask.Models
{
    public class Mail
    {
        /// <summary>
        /// ID сообщения
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Тело сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Получатель сообщения
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Дата отправки
        /// </summary>
        public DateTime SendDate { get; set; }

        /// <summary>
        /// Результат отправки (OK | Failed)
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// Сообщение об ошибке
        /// </summary>
        public string? FailedMessage { get; set; }
    }
}
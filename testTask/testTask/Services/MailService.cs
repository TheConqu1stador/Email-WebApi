using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using testTask.Models;

namespace testTask.Services
{
    /// <summary>
    /// Сервис для работы с сообщениями
    /// </summary>
    public class MailService
    {
        private readonly ILogger<MailService> _logger;
        private readonly MailDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        private readonly MailAddress _fromAddress;

        /// <summary>
        /// Конструктор сервиса для работы с сообщениями
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="dbContext"></param>
        /// <param name="configuration"></param>
        public MailService(
            ILogger<MailService> logger,
            MailDbContext dbContext,
            IConfiguration configuration)
        {
            _dbContext = dbContext;
            _logger = logger;
            _configuration = configuration;
            _fromAddress = new MailAddress(
                _configuration.GetSection("MailAccountCredentials")
                    .GetSection("Login").Value);
            _smtpClient = SetupSmtp();
        }

        /// <summary>
        /// Метод для получения всех сообщений, отсортированных по ID 
        /// </summary>
        /// <returns></returns>
        public IReadOnlyCollection<Mail> GetAllMails()
        {
            return _dbContext.Mail.OrderBy(x => x.Id).ToList();
        }

        /// <summary>
        /// Метод для получения сообщения по ID
        /// </summary>
        /// <param name="id">ID искомого сообщения</param>
        /// <returns></returns>
        public Mail? GetMail(long id)
        {
            return _dbContext.Mail.Find(id);
        }

        /// <summary>
        /// Метод для отправки сообщений всем указанным получателям
        /// </summary>
        /// <param name="request">Тело запроса</param>
        /// <returns></returns>
        public IReadOnlyCollection<Mail> SendMails(PostSendMail request)
        {
            var mails = new List<Mail>();
            Parallel.ForEach(request.Recipients, (recipient) =>
            {
                mails.Add(SendMail(request.Body, request.Subject, recipient));
            });

            _dbContext.AddRange(mails);
            _dbContext.SaveChanges();

            return mails.AsReadOnly();
        }

        private Mail SendMail(string body, string subject, string recipient)
        {
            var errMsg = "";
            Mail mail;
            try
            {
                var toAddress = new MailAddress(recipient);

                using (var message = new MailMessage(_fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    _smtpClient.Send(message);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                mail = new Mail()
                {
                    Body = body,
                    Subject = subject,
                    Recipient = recipient,
                    SendDate = DateTime.Now,
                    Result = string.IsNullOrEmpty(errMsg) ? "OK" : "Failed",
                    FailedMessage = errMsg
                };
            }

            return mail;
        }

        private SmtpClient SetupSmtp()
        {
            string fromPassword =
                _configuration.GetSection("MailAccountCredentials")
                    .GetSection("Password").Value;

            return new SmtpClient
            {
                Host = _configuration.GetSection("SmtpSettings")
                    .GetSection("Host").Value,
                Port = int.Parse(_configuration.GetSection("SmtpSettings")
                    .GetSection("Port").Value),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_fromAddress.Address, fromPassword)
            };
        }
    }
}

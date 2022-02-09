using Microsoft.AspNetCore.Mvc;
using testTask.Models;
using testTask.Services;

namespace testTask.Controllers
{
    /// <summary>
    /// Контроллер для работы с сообщениями
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly ILogger<MailController> _logger;
        private readonly MailService _mailService;

        /// <summary>
        /// Конструктор контроллера для работы с сообщениями
        /// </summary>
        /// <param name="mailService"></param>
        /// <param name="logger"></param>
        public MailController( 
            MailService mailService, 
            ILogger<MailController> logger)
        {
            _logger = logger;
            _mailService = mailService;
        }

        #region Post: /api/mail/send

        /// <summary>
        /// Отправка сообщений для всех получателей
        /// </summary>
        /// <param name="request">Тело запроса</param>
        /// <returns>Список отправленных сообщений</returns>
        [Route("/api/mail/send")]
        [HttpPost]
        [Produces(typeof(Mail))]
        public IReadOnlyCollection<Mail> SendMails(PostSendMail request)
        {
            return _mailService.SendMails(request);
        }

        #endregion

        #region Get: /api/mail/{id}

        /// <summary>
        /// Получение сообщения по ID
        /// </summary>
        /// <param name="id">ID искомого сообщения</param>
        /// <returns>Информация об отправленном сообщении</returns>
        [Route("/api/mail/{id}")]
        [HttpGet]
        [Produces(typeof(Mail))]
        public ActionResult<Mail> GetMail(long id)
        {
            var mail = _mailService.GetMail(id);
            return (mail is not null) ? mail : NotFound();
        }

        #endregion

        #region Get: /api/mail

        /// <summary>
        /// Получение полного списка сообщений
        /// </summary>
        /// <returns>Список всех сообщений</returns>
        [Route("/api/mail")]
        [HttpGet]
        [Produces(typeof(IReadOnlyCollection<Mail>))]
        public IReadOnlyCollection<Mail> GetMails()
        {
            return _mailService.GetAllMails();
        }

        #endregion

    }
}
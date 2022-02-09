using Microsoft.AspNetCore.Mvc;
using testTask.Models;
using testTask.Services;

namespace testTask.Controllers
{
    /// <summary>
    /// ���������� ��� ������ � �����������
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MailController : ControllerBase
    {
        private readonly ILogger<MailController> _logger;
        private readonly MailService _mailService;

        /// <summary>
        /// ����������� ����������� ��� ������ � �����������
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
        /// �������� ��������� ��� ���� �����������
        /// </summary>
        /// <param name="request">���� �������</param>
        /// <returns>������ ������������ ���������</returns>
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
        /// ��������� ��������� �� ID
        /// </summary>
        /// <param name="id">ID �������� ���������</param>
        /// <returns>���������� �� ������������ ���������</returns>
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
        /// ��������� ������� ������ ���������
        /// </summary>
        /// <returns>������ ���� ���������</returns>
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
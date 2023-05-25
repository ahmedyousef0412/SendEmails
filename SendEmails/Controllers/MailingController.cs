using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendEmails.Dtos;
using SendEmails.Services;

namespace SendEmails.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {

        private readonly IMailingService _mailingService;
        public MailingController(IMailingService mailingService)
        {
            _mailingService= mailingService;
        }

        [HttpPost("SendEmail")]

        public async Task<IActionResult> SendEmail([FromForm] MailingRequestDto dto)
        {

            await _mailingService.SendEmailAsync(dto.MailTo, dto.Subject, dto.Body, dto.Attatchment);
            return Ok();
        }


        [HttpPost("Welcome")]
        public async Task<IActionResult> SendWelocmeEmail([FromBody] WelcomeRequestDto dto)
        {
            var filePath = $"{Directory.GetCurrentDirectory()}\\Template\\EmailTemplate.html";

            var streamReader = new StreamReader(filePath);

            var mailText = streamReader.ReadToEnd();

            streamReader.Close();

            mailText = mailText.Replace("[username]",dto.UserName)
                .Replace("[email]",dto.Email);


           await _mailingService.SendEmailAsync(dto.Email, "Welcome Message", mailText);

            return Ok();
        }
    }
}

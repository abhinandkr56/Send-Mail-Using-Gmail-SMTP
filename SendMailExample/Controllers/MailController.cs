using Microsoft.AspNetCore.Mvc;

namespace SendMailExample.Controllers;

[ApiController]
[Route("[controller]")]
public class MailController : ControllerBase
{
    [HttpPost]
    public IActionResult Send(string toAddress, string subject, string body)
    {
        Mailer m = new Mailer();
        m.SendEmail(toAddress, subject, body);
        return Ok("Success");
    }
}
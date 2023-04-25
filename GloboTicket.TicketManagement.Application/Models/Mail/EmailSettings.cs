namespace GloboTicket.TicketManagement.Application.Models.Mail;

public class EmailSettings
{
    public const string SectionName = "EmailSettings";
    public string ApiKey { get; set; } = string.Empty;
    public string FromAddress { get; set; } = string.Empty;
    public string FromName { get; set; } = string.Empty;
}

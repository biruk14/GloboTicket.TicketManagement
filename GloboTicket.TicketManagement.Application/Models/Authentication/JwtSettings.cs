﻿namespace GloboTicket.TicketManagement.Application.Models.Authentication;

public class JwtSettings
{
    public const string SectionName = "JwtSettings";
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; }= string.Empty;
    public string Audience { get; set; } = string.Empty;
    public double DurationInMinutes { get; set; } 

}
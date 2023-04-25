using CsvHelper;
using GloboTicket.TicketManagement.Application.Contracts.Infrastructure;
using System.Globalization;

namespace GloboTicket.TicketManagement.Infrastructure.FileExport;

public class CsvExporter : ICsvExporter
{
    public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWrite = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWrite,CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(eventExportDtos);
        }

        return memoryStream.ToArray();
    }
}

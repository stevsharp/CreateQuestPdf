using QuestPDF.Fluent;


public class PdfService
{
    public byte[] GeneratePdf()
    {
        var document = new SimpleDocument();
        using var stream = new MemoryStream();
        document.GeneratePdf(stream);
        return stream.ToArray();
    }
}

using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

public class SimpleDocument : IDocument
{
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Margin(40);
            page.Content().Column(column =>
            {
                column.Item().Text("POLITIS").FontSize(20).Bold();
                column.Item().Text("Εισαγωγές - Αντιπροσωπείες - Εμπόριο").FontSize(12);
                column.Item().Text("ΔΙΕΥΘΥΝΣΗ: __________").FontSize(14);
                column.Item().Text("ΠΟΛΗ: __________").FontSize(14);
                column.Item().Text("ΤΗΛ: __________").FontSize(14);
            });
        });
    }
}

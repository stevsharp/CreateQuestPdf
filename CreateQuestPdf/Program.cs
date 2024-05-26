using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;


QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

Document.Create(container =>
{
    container.Page(page =>
    {
        page.Size(PageSizes.A4);
        page.Margin(2, Unit.Centimetre);
        page.PageColor(Colors.White);
        page.DefaultTextStyle(x => x.FontSize(12));

        page.Header()
            .Text("Sample PDF with Table")
            .SemiBold().FontSize(24).FontColor(Colors.Blue.Medium);

        page.Content()
            .PaddingVertical(1, Unit.Centimetre)
            .Column(column =>
            {
                column.Spacing(20);

                column.Item().Text("sample data:");

                column.Item().Table(table =>
                {
                    // Define the columns
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();  // Auto-width column
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    // Header row
                    table.Header(header =>
                    {
                        header.Cell().Element(CellStyle).Text("Column 1");
                        header.Cell().Element(CellStyle).Text("Column 2");
                        header.Cell().Element(CellStyle).Text("Column 3");

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.DefaultTextStyle(x => x.SemiBold()).Padding(5).Background(Colors.Grey.Lighten3);
                        }
                    });

                    // Data rows
                    for (int i = 0; i < 10; i++)
                    {
                        table.Cell().Element(CellStyle).Text($"Row {i + 1} - Cell 1");
                        table.Cell().Element(CellStyle).Text($"Row {i + 1} - Cell 2");
                        table.Cell().Element(CellStyle).Text($"Row {i + 1} - Cell 3");

                        static IContainer CellStyle(IContainer container)
                        {
                            return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5);
                        }
                    }
                });
            });

        page.Footer()
            .AlignCenter()
            .Text(x =>
            {
                x.CurrentPageNumber();
                x.Span(" / ");
                x.TotalPages();
            });
    });
})
           .GeneratePdf("sample-table.pdf");

Console.WriteLine("PDF document with table has been created successfully!");

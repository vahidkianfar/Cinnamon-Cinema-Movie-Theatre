using Spectre.Console;

namespace Cinnamon_Cinema_Movie_Theatre.UI;

public class DrawSeatsTable
{
    public async Task LiveTable(List<Tuple<string, int, int>> seats)
    {
        var table = new Table().LeftAligned().BorderColor(Color.Gold3_1);
        var delayTable = 0;
        var delaySeats = 0;
        await AnsiConsole.Live(table).AutoClear(false).StartAsync(async ctx =>
        {
            table.AddColumn(" ");
        
            for (var column = 1; column < 6; column++)
            {
                table.AddColumn($"{column}");
                ctx.Refresh();
                await Task.Delay(delayTable);
            }
        
            for (var row = 3; row > 0; row--)
            {
                switch (row)
                {
                    case 3:
                        table.AddRow("A");
                        break;
                    case 2:
                        table.AddRow("B");
                        break;
                    case 1:
                        table.AddRow("C");
                        break;
                }

                ctx.Refresh();
                await Task.Delay(delayTable);
            }
            var allotedSeats = 0;
            foreach (var (row, column, status) in seats)
            {
                if (status == 0) continue;
                switch (row)
                {
                    case "A":
                        table.UpdateCell(0, column, "[red]X[/]");
                        allotedSeats++;
                        break;
                    case "B":
                        table.UpdateCell(1, column, "[red]X[/]");
                        allotedSeats++;
                        break;
                    case "C":
                        table.UpdateCell(2, column, "[red]X[/]");
                        allotedSeats++;
                        break;
                }

                ctx.Refresh();
                await Task.Delay(delaySeats);

            }
            
            table.Title = new TableTitle("\nCinnamon Cinema Theatre");
            table.Caption = new TableTitle("Remaining Seats: " + (15 - allotedSeats));
        });
    }
}
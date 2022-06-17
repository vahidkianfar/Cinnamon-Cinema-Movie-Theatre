﻿using Spectre.Console;

namespace Cinnamon_Cinema_Movie_Theatre;

public class DrawSeatsTable
{
    public async Task<Table> LiveTable(List<Tuple<string,int,int>> seats)
    {
        var table = new Table().LeftAligned().BorderColor(Color.Blue);
        var delayTable = 100;
        var delaySeats = 200;
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
        
            var counter = 0;
            foreach (var (row, column, status) in seats)
            {
                if (status == 0) continue;
                switch (row)
                {
                    case "A":
                        table.UpdateCell(0, column, "X");
                        break;
                    case "B":
                        table.UpdateCell(1, column, "X");
                        break;
                    case "C":
                        table.UpdateCell(2, column, "X");
                        break;
                }

                ctx.Refresh();
                await Task.Delay(delaySeats);

            }

            // while(counter<15)
            // {
            //     table.UpdateCell(counter, 0, "X");
            //     ctx.Refresh();
            //     await Task.Delay(delayRover);
            //     counter++;
            // }
            table.Title = new TableTitle("\nSeats Table");
            table.Caption = new TableTitle("SeatManager Availability");
        });
        return table;
    }
}
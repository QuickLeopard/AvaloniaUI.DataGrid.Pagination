using AvaloniaUI.DataGrid.Pagination.Interfaces;
using AvaloniaUI.DataGrid.Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaUI.DataGrid.Pagination.Services
{
    public class HistoryGeneratorService : IHistoryService
    {

        public Task<IEnumerable<HistoryPosition>> GenerateHistoryPositionsAsync() => Task.FromResult (Enumerable.Empty<HistoryPosition>());

    }
}

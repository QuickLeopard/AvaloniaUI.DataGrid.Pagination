using AvaloniaUI.DataGrid.Pagination.Interfaces;
using AvaloniaUI.DataGrid.Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaUI.DataGrid.Pagination.Services
{
    public class HistoryService
    {
        private readonly IHistoryLoader _historyLoader;

        public HistoryService (IHistoryLoader historyLoader)
        {
            _historyLoader = historyLoader;
        }

        public Task<IEnumerable<HistoryPosition>> LoadHistoryPositionsAsync () => _historyLoader.LoadHistoryPositionsAsync ();

    }
}

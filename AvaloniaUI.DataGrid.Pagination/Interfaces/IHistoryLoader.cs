﻿using AvaloniaUI.DataGrid.Pagination.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaUI.DataGrid.Pagination.Interfaces
{
    public interface IHistoryLoader
    {

        public Task<IEnumerable<HistoryPosition>> LoadHistoryPositionsAsync ();

    }
}

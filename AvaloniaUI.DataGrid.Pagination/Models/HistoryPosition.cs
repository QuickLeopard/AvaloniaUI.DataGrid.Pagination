using AvaloniaUI.DataGrid.Pagination.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaUI.DataGrid.Pagination.Models
{
    public class HistoryPosition
    {

        public required string PosId { get; set;}

        public required string Ticker { get; set; }

        public required PositionSide Side { get; set; }

        public required decimal OpenPrice { get; set; }

        public required decimal ClosePrice { get; set; }

        public required decimal Quantity { get; set; }

        // Profit and Loss in %, print with precision: 2 decimals after dot
        public decimal PnL { get => Convert.ToInt32 (Side) * 100m * (ClosePrice - OpenPrice) / OpenPrice; }

        public required DateTime OpenTime { get; set; }

        public required DateTime CloseTime { get; set; }

    }
}

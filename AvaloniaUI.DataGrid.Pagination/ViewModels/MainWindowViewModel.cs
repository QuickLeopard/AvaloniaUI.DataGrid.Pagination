using AvaloniaUI.DataGrid.Pagination.Models;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Reactive;

namespace AvaloniaUI.DataGrid.Pagination.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ReadOnlyObservableCollection<HistoryPosition> _positionHistory;

        public ReadOnlyObservableCollection<HistoryPosition> PositionHistory
        {
            get => _positionHistory;
            set => this.RaiseAndSetIfChanged(ref _positionHistory, value);
        }

        public ReactiveCommand<Unit, Unit> GenerateTradeHistoryCommand { get; }

        public MainWindowViewModel ()
        {
            _positionHistory = 
                
                new (new () 
                { 
                        new HistoryPosition() 
                        { 
                            PosId = new Guid ().ToString (),
                            Ticker = "BTCUSDT",
                            Side = Enums.PositionSide.BUY,
                            Quantity = 100,
                            OpenPrice = 1.15m,
                            ClosePrice = 1.29m,
                            OpenTime = DateTime.UtcNow.AddSeconds (-60),
                            CloseTime = DateTime.UtcNow,
                        } 
                });
        }
    }
}

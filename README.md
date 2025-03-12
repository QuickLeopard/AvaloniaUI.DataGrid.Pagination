# Техническое задание на разработку Desktop приложения

### 1. Используя AvaloniaUI + [ReactiveUI](https://www.reactiveui.net/) + [SOLID](https://ru.wikipedia.org/wiki/SOLID_(%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5)) + [DI](https://learn.microsoft.com/ru-ru/dotnet/core/extensions/dependency-injection) разработать UserControl _PaginatedDataGrid_, использующий пагинацию, для DataGrid.
#### Настраиваемые свойства _PaginatedDataGrid_
  - _PageSize_ - количество отображемых строк на одной странице
  - _NumPageButtons_ - количество отображаемых кнопок для быстрого перехода на страницы, допустимый диапазон от 3 до 10

_PaginatedDataGrid_ отображает внизу DataGrid кнопки First(Переход на первую страницу), Previous, далее отображает _NumPageButtons_ кнопок быстрого перехода на страницы(если старниц меньше, чем _NumPageButtons_, то отображем только столько кнопок, сколько есть страниц), потом идут кнопки Next, Last(переход на последнюю страницу).
Если мы находимся на 1-ой странице, то кнопка First не активна и кнопка с надписью `1`, аналогично для последней страницы.

Пример кнопок пагинации(5 кнопок для быстрого перехода на страницы, по номеру страницы):

![alt text](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/Images/Pagination.png)

### 2. Для генерации данных для таблицы, необходимо реализовать ReactiveUI команду [_GenerateTradeHistoryCommand_](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/AvaloniaUI.DataGrid.Pagination/ViewModels/MainWindowViewModel.cs#GenerateTradeHistoryCommand), через DI сервис [_HistoryGeneratorService_](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/AvaloniaUI.DataGrid.Pagination/Services/HistoryGeneratorService.cs)(в шаблоне сервис имеет реализацию интерфейса [_IHistoryService_](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/AvaloniaUI.DataGrid.Pagination/Interfaces/IHistoryService.cs) в виде заглушки, возвращающей пустые данные)
#### Модель данных [_HistoryPosition_](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/AvaloniaUI.DataGrid.Pagination/Models/HistoryPosition.cs) для тестирования генерируется случайным образом, значение свойств модели генерируются следующим образом:
- PosId -> GUID
- Ticker -> случайно выбранный элемент из _["BTCUSDT", "ETHUSDT", "XRPUSDT", "SOLUSDT", "DOGEUSDT"]_
- Side -> случайно выбранный элемент _BUY или SELL_
- Quantity -> случайно выбранная величина из диапазона: _[1..1000]_
- OpenPrice -> случайно выбранная величина из диапазона: _[1..100]_
- ClosePrice -> случайно выбранная величина из диапазона: _[1..100]_
- CloseTime -> ```DateTime.UtcNow.AddMinutes (-x),``` где x = случайно выбранная величина из диапазона: _[1..100]_
- OpenTime -> ```CloseTime.AddMinutes (-60)```

# Техническое задание на разработку Desktop приложения

### 1. Используя AvaloniaUI + [ReactiveUI](https://www.reactiveui.net/) + [SOLID](https://ru.wikipedia.org/wiki/SOLID_(%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5)) + [DI](https://learn.microsoft.com/ru-ru/dotnet/core/extensions/dependency-injection) разработать [UserControl](https://docs.avaloniaui.net/docs/basics/user-interface/controls/creating-controls/choosing-a-custom-control-type) _PaginatedDataGrid_, использующий пагинацию, для DataGrid.
#### Настраиваемые свойства _PaginatedDataGrid_
  - _PageSize_ - количество отображемых строк на одной странице
  - _NumPageButtons_ - количество отображаемых кнопок для быстрого перехода на страницы, допустимый диапазон от 3 до 10

_PaginatedDataGrid_ отображает внизу DataGrid кнопки `First`(Переход на первую страницу), `Previous`, далее отображает _NumPageButtons_ кнопок быстрого перехода на страницы(если старниц меньше, чем _NumPageButtons_, то отображем только столько кнопок, сколько есть страниц), потом идут кнопки `Next`, `Last`(переход на последнюю страницу).
Если мы находимся на 1-ой странице, то не активны кнопка `First` и кнопка с надписью `1`, аналогично для последней страницы.

Пример кнопок пагинации(пять кнопок для быстрого перехода на страницы, по номеру страницы, для текущей страницы `3` отображаются кнопки `1` `2` `3` `4` `5`, для текущей страницы `5` это будут кнопки `3` `4` `5` `6` `7`):

![alt text](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/Images/Pagination.png)

### 2. Для генерации данных для таблицы, необходимо реализовать ReactiveUI команду [_GenerateTradeHistoryCommand_](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/AvaloniaUI.DataGrid.Pagination/ViewModels/MainWindowViewModel.cs#GenerateTradeHistoryCommand), которая генерирует случайное количество строк данных(в диапазоне от 50 до 200) для DataGrid, через DI сервис [_HistoryService_](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/AvaloniaUI.DataGrid.Pagination/Services/HistoryService.cs)(необходимо создать класс, который реализует интерфейс [_IHistoryLoader_](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/AvaloniaUI.DataGrid.Pagination/Interfaces/IHistoryLoader.cs))
#### Модель данных [_HistoryPosition_](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/AvaloniaUI.DataGrid.Pagination/Models/HistoryPosition.cs) для тестирования генерируется случайным образом с помощью библиотеки [Bogus](https://github.com/bchavez/Bogus), значение свойств модели генерируются следующим образом:
- PosId -> GUID
- Ticker -> случайно выбранный элемент из _["BTCUSDT", "ETHUSDT", "XRPUSDT", "SOLUSDT", "DOGEUSDT"]_
- Side -> случайно выбранный элемент _BUY или SELL_
- Quantity -> случайно выбранная величина из диапазона: _[1..1000]_
- OpenPrice -> случайно выбранная величина из диапазона: _[1..100]_
- ClosePrice -> случайно выбранная величина из диапазона: _[1..100]_
- CloseTime -> ```DateTime.UtcNow.AddMinutes (-x),``` где x = случайно выбранная величина из диапазона: _[1..100]_
- OpenTime -> ```CloseTime.AddMinutes (-60)```

### 3. Данные выводить(все свойства [_HistoryPosition_](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/AvaloniaUI.DataGrid.Pagination/Models/HistoryPosition.cs)) в виде таблицы в DataGrid. Колонка PnL: значение выводится с точностью до 2-х знаков после запятой.

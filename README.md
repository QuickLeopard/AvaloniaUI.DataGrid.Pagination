# Техническое задание на разработку Desktop приложения

### 1. Используя AvaloniaUI + ReactiveUI + [SOLID](https://ru.wikipedia.org/wiki/SOLID_(%D0%BF%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5)) + DI разработать UserControl PaginatedDataGrid, использующий пагинацию, для DataGrid.
#### Настраиваемые свойства PaginatedDataGrid
  - PageSize - количество отображемых строк на одной странице
  - NumPageButtons - количество отображаемых кнопок для быстрого перехода на страницы, допустимый диапазон от 3 до 10

PaginatedDataGrid отображает внизу DataGrid кнопки First(Переход на первую страницу), Previous, далее отображает _NumPageButtons_ кнопок быстрого перехода на страницы(если старниц меньше, чем _NumPageButtons_, то отображем только столько кнопок, сколько есть страниц), потом идут кнопки Next, Last(переход на последнюю страницу).
Если мы находимся на 1-ой странице, то кнопка First не активна и кнопка с надписью `1`, аналогично для последней страницы.

Пример кнопок пагинации(5 кнопок для быстрого перехода на страницы, по номеру страницы):

![alt text](https://github.com/QuickLeopard/AvaloniaUI.DataGrid.Pagination/blob/master/Images/Pagination.png)

### 2. Для генерации данных для таблицы, необходимо реализовать ReactiveUI команду GenerateTradeHistoryCommand, через DI сервис HistoryGeneratorService(в шаблоне сервис имеет реализацию интерфейса IHistoryService в виде заглушки, возвращающей пустые данные)
#### Модель данных HistroyPosition для тестирования генерируется случайным образом, значение свойств модели генерируются следующим образом:
- PosId -> GUID
- Ticker -> случайно выбранный элемент из ["BTCUSDT", "ETHUSDT", "XRPUSDT", "SOLUSDT", "DOGEUSDT"]
- Side -> случайно выбранный элемент BUY или SELL
- Quantity -> случайно выбранная величина из диапазона: [1..1000]
- OpenPrice -> случайно выбранная величина из диапазона: [1..100]
- ClosePrice -> случайно выбранная величина из диапазона: [1..100]
- CloseTime -> DateTime.UtcNow.AddMinutes (-x), где x = случайно выбранная величина из диапазона: [1..100]
- OpenTime -> CloseTime.AddMinutes (-60)

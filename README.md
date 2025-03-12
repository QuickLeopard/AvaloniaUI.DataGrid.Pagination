# Техническое задание на разработку Desktop приложения

### 1. Используя AvaloniaUI + ReactiveUI разработать UserControl, использующий пагинацию, для DataGrid.
#### Настраиваемые свойства UserControl
  - PageSize - количество отображемых строк на одной странице
  - NumPageButtons - количество отображаемых кнопок для быстрого перехода на страницы

Пример кнопок пагинации:

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

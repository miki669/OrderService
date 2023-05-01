# Сервис заказов на базе ASP.NET Core
Данный репозиторий содержит исходный код сервиса заказов. С помощью данного сервиса можно: 
* создавать
* изменять
* удалять 
* получать заказы

Состояние заказов сохраняется в базу данных.

# Инструкция по запуску проекта через Docker

```
git clone https://github.com/miki669/OrderService.git
```
```
cd OrderService/
```
```
docker-compose up -d
```
<div align="center"> <h1 align="center"> Пример использования </h1> </div>

# `Добавление товара` #
### Request
```rb
curl -X 'POST' \
'http://localhost/api/Product' \
--header 'Content-Type: application/json' \
--data '{
  "name": "Смартфон Apple iPhone 14 Pro 128 ГБ",
  "code": "IP14PRO",
  "price": 100000,
  "description": "Описание для данного продуктка"
}'
```
### Response
```rb
{
    "id": "430b285e-0242-4f19-b59b-ff1e144d0027",
    "name": "Смартфон Apple iPhone 14 Pro 128 ГБ",
    "code": "IP14PRO",
    "price": 100000,
    "description": "Описание для данного продуктка"
}
```
# `Добавление заказа` #
### Request
```rb
curl -X 'POST' \
  'http://localhost:8081/api/Order' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "status": "New",
  "lines": [
    {
      "id": "430b285e-0242-4f19-b59b-ff1e144d0027",
      "qty": 3
    }
  ]
}'

```
### Response
```rb
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "status": "New",
  "created": "2023-04-30 20:07:18",
  "lines": [
    {
      "id": "430b285e-0242-4f19-b59b-ff1e144d0027",
      "qty": 3
    }
  ]
}
```

# `Редактирование заказа` #
### Request
```rb
curl -X 'PUT' \
  'http://localhost:8081/api/Order/3fa85f64-5717-4562-b3fc-2c963f66afa6' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "status": "Paid",
  "lines": [
    {
      "id": "430b285e-0242-4f19-b59b-ff1e144d0027",
      "qty": 12
    },
    {
      "id": "e5899c21-2146-421d-8cb2-2d2e8995046d",
      "qty": 1
    }
  ]
}'

```
### Response
```rb
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "status": "Paid",
  "created": "2023-05-01T16:33:09.494964",
  "lines": [
    {
      "id": "430b285e-0242-4f19-b59b-ff1e144d0027",
      "qty": 12
    },
    {
      "id": "e5899c21-2146-421d-8cb2-2d2e8995046d",
      "qty": 1
    }
  ]
}
```

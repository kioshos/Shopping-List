# Аналіз предметної області 

## Опис функцій 

1. Створити список покупок 

Користувач створює новий список покупок 

2. Додати товар до списку 

Користувач додає товар до списку, вказує його кількість та ціну 

3. Позначити товари як куплені 

Коли користувач придбав товар, він може позначати товари як куплені 

4. Видалення товару або зміна їх кількості 

Користувач редагує список товару: видаляє або оновлює інформацію  

5. Історія покупок 

Додаток зберігає історію попередніх покупок користувача 

6. Аналітика купівлі 

Додаток показує які категорії предметів користувач найчастіше купував 

## Структура бази даних 

Сутності: товар, список покупок, категорія, історія покупок. 

### Таблиці бази даних 

1. Товар у списку 

* Id: первинний ключ 

* Name: назва товару 

* Quantity: кількість товару 

* Unit: одиниця виміру 

* IsPurchased: чи був товар куплений 

* Price: ціна товару 

* CategoryId: зовнішній ключ до таблиці “Категорія товару” 

* ShoppingListId: зовнішній ключ до таблиці "Список покупок" 

2. Список покупок 

* Id: первинний ключ 

* Name: назва списку  

* CreateDate: дата коли був створений список 

3. Категорія товару 

* Id: первинний ключ 

* Name: назва категорії товару 

4. Історія покупок 

* Id: primary key 

* ItemName: назва предмета 

* Quantity: кількість предметів 

* Unit: одиниця вимірювання

* Price: вартість предмету 

* PurchasedDate: дата коли було куплено товар 

* ShoppingListId: зовнішній ключ до таблиці “Список покупок” 

* CategoryId: зовнішній клюй до таблиці “Категорія товару” 

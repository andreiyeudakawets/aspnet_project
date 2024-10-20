# MADP
Магазин одежды
## Евдоковец Андрей, 253505
ФКСиС ИиТП, 2024г. СППР

# Функциональные возможности проекта

Проект представляет собой сайт магазина одежды. Основные функциональные возможности включают(soon...):

## 1. Регистрация и авторизация пользователей
- Пользователи могут создавать учетные записи, вводя уникальные логин и email.
- Авторизация осуществляется по email и паролю.

## Сущности и описание их полей

### 1. **User (Пользователь)**
- **Attributes**:
   - `user_id` (PK): Уникальный идентификатор пользователя.
  - `username` (VARCHAR, уникальный): Имя пользователя.
  - `email` (VARCHAR, уникальный): Адрес электронной почты пользователя.
  - `password_hash` (VARCHAR): Хэш пароля.
  - `is_author` (BOOLEAN): Флаг, указывающий, является ли пользователь автором.
  - `registration_date` (DATE): Дата регистрации пользователя.
- **Relationships**:
  - One-to-Many with `Article`: One user can write many articles.
  - One-to-Many with `Comment`: One user can post many comments.
  - One-to-Many with `Like`: One user can like many articles.
  - One-to-Many with `Subscription`: One user can subscribe to many authors.
  - One-to-Many with `Bookmark`: One user can bookmark many articles.
  - One-to-Many with `Notification`: One user can receive many notifications.
  - One-to-One with `Moderator`: One user can be assigned as a moderator.
  - One-to-Many with `Comment_Like`: One user can like many comments.
  - One-to-Many with `Category_Subscription`: One user can subscribe to many categories.

### 5. **Category (Категория)**
- **Attributes**:
  - `category_id` (PK): Уникальный идентификатор категории.
  - `name` (VARCHAR): Название категории.
  - `description` (TEXT): Описание категории.
- **Relationships**:
  - One-to-Many with `Article`: One category can include many articles.
  - One-to-Many with `Category_Subscription`: One category can have many subscribers.

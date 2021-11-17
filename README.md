# TestWork.Mytona

# Техническое задание
## Общее
Игрок управляет несколькими капсулами от третьего лица, его задача очистить
территорию от вторгшихся варваров.
Условия:
1. Использовать любые примитивы, стандартные объекты Unity3d
2. Учесть что клики могут быть мышкой с ПК или нажатиями на телефоне.
3. Объекты не должны спавниться в местах препятствий.
Этапы:
1. Добавить terrain, поле 500х500 игровых единиц
2. Настроить камеру (формат RPG вид сверху с небольшим наклоном)
3. Создать препятствия (горы или объекты, на которые нельзя взобраться)
4. Добавить примитивы капсул синего цвета - ботов (могут двигаться рядом с точкой
спавна не более 3 ед от неё)
5. Добавить белый Куб (3х2ед) в случайном месте (центральное здание игрока)
6. По нажатию на куб открывается меню производства капсул (с выбором от1 до5 шт)
7. Выбрав количество запускается таймер производства (10 сек на каждую капсулу)
8. Зеленые капсулы игрока создаются внутри куба, выходят из него становясь рядом.
9. Однократным кликом (mobile touch или правой кнопкой мыши) можно выбрать
капсулу, кликнув по ней.
10. Кликнув в некоторое место на карте капсула должна передвигаться в место клика
(обходя препятствия)
11. У капсул 2ед жизни, у ботов 1 ед, направив капсулу игрока на капсулу бота
происходит некоторое сражение.
12. Добавить любую анимацию сражения и смерти капсул. (например бой может быть
двигающимися вверх-вниз “руками” которые возникают у капсул когда начинается
бой, а смерть взрывом, но этот пункт на ваше усмотрение, для проверки
креативности)

## Дополнительно (опционально):
1. Двукратный клик мышки или двойной клик mobile touch позволяет выбрать все
капсулы в зоне видимости камеры.
2. Видны жизни ботов и игроков
3. Возможность игроком самостоятельно расположить куб по сетке.

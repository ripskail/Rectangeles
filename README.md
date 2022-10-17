# Rectangeles
Дано: Программа создаёт прямоугольники произвольных цветов и размеров в произвольных местах окна с заданной периодичностью (скажем, 1 с). 
Существующие прямоугольники, пересекающиеся с добавленным, «помечаются» к удалению и исчезают через N циклов (N — константа). 
Программа работает до тех пор, пока не будет прервана.

     Graphics gr   - Класс Graphics предоставляет методы для рисования объектов на устройстве отображения. 
     rectangles    - Список прямоугольников
     t             - Счетчик тиков
     deletefig     - Константа N (равна 3)
     penColors     - Массив цветов
     RectangleF rf - Содержит набор из четырех чисел с плавающей запятой, определяющих расположение и размер прямоугольника
     
     Методы:
     AddFigure()                                    - Добавление прямоугольника
     checkRectangel()                               - Проверка пересечения прямоугольников
     removeRectangel()                              - Удаление прямоугольника через N циклов
     compareRectangle(RectangleF r1, RectangleF r2) - Проверка условия пересичения


     class Figure - Класс прямоугольника
   
     Pen1                               - Кисть для border прямоугольника
     RectangleF Rectangle { get; set; } - Координаты прямоугольника, ширина и высота
     SolidBrush Fill { get; set; }      - Цвет заливки
     delete { get; set; }               - Число для определения когда нужно удалить прямоугольник
     
     Методы:
     Draw(Graphics g)                   - Метод отрисовки прямоугольника


      Решение: 
      При добавлении прямоугольника циклом for идет обход по списку
      Если прямоугольник пересекает другой, то он помечается на удаление(кол-во прямоугольников + константа):
      
      rectangles[i].delete = rectangles.Count + deletefig
      
      Каждую 1 сек проверяется у каждого элемента списка прямоугольников(число для удаления с счетчиком):
      
      rectangles[i].delete == t 
      
      Если условие проходит то удаляется из списка
      
      rectangles.Remove(rectangles[i]);


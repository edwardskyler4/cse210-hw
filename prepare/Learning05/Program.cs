using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new();
        Square square = new("blue", 5);
        Rectangle rectangle = new("yellow", 3, 4);
        Circle circle = new("pink", 1);

        shapes.AddRange(square, rectangle, circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} - {shape.GetArea()}");
        }

    }
}
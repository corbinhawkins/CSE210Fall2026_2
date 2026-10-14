class Circle
{
    private double radius;

public Circle()
    {
        _radius = 0.0;
    }

    public Circle(double radius)
    {
        _radius = radius;
    }
   public double GetArea()
    {
        return radius*radius * 3.14159;
    }
    public void SetRadius(double radius)
    {
        if (radius < 0.0)
        {
            _radius = 1.0;
            Console.WriteLine("Eror, you must have a radius");
        }
        else
        {
            _radius = radius;
        }
    }
}
using Calculator;

namespace Tests;

public class SimpleCalculatorTest
{
    [Test]
    public void Add()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 2;
        var b = 3;

        // Act
        var result = calc.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Subtract()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 5;
        var b = 3;

        // Act
        var result = calc.Subtract(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }

    [Test]
    public void Multiply()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 4;
        var b = 3;

        // Act
        var result = calc.Multiply(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(12));
    }

    [Test]
    public void Divide()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 10;
        var b = 2;

        // Act
        var result = calc.Divide(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Divide_ByZero()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var a = 10;
        var b = 0;

        // Act
        TestDelegate action = () => calc.Divide(a, b);

        // Assert
        Assert.That(action, Throws.TypeOf<DivideByZeroException>());
    }

    [Test]
    public void Factorial_Negative()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var n = -1;

        // Act
        TestDelegate action = () => calc.Factorial(n);

        // Assert
        Assert.That(action, Throws.TypeOf<ArgumentException>());
    }

    [Test]
    public void Factorial_Zero()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var n = 0;

        // Act
        var result = calc.Factorial(n);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Factorial_Positive()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var n = 5;

        // Act
        var result = calc.Factorial(n);

        // Assert
        Assert.That(result, Is.EqualTo(120));
    }

    [Test]
    public void IsPrime_LessThanTwo()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var candidate = 1;

        // Act
        var result = calc.IsPrime(candidate);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsPrime_Composite()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var candidate = 9;

        // Act
        var result = calc.IsPrime(candidate);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void IsPrime_Prime()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var candidate = 13;

        // Act
        var result = calc.IsPrime(candidate);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPrime_Two()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var candidate = 2;

        // Act
        var result = calc.IsPrime(candidate);

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void IsPrime_PerfectSquare()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var candidate = 49;

        // Act
        var result = calc.IsPrime(candidate);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Factorial_One()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var n = 1;

        // Act
        var result = calc.Factorial(n);

        // Assert
        Assert.That(result, Is.EqualTo(1));
    }

    [Test]
    public void Factorial_Two()
    {
        // Arrange
        var calc = new SimpleCalculator();
        var n = 2;

        // Act
        var result = calc.Factorial(n);

        // Assert
        Assert.That(result, Is.EqualTo(2));
    }

}

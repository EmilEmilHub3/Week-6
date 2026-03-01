using Calculator;

namespace Tests;

public class CachedCalculatorTest
{
    [Test]
    public void Add_FirstCall()
    {
        var calc = new CachedCalculator();
        var result = calc.Add(2, 3);
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Add_SecondCall_ReturnsSameResult()
    {
        var calc = new CachedCalculator();

        var first = calc.Add(2, 3);
        var second = calc.Add(2, 3);

        Assert.That(first, Is.EqualTo(5));
        Assert.That(second, Is.EqualTo(5));
        Assert.That(second, Is.EqualTo(first));
    }

    [Test]
    public void Factorial_SecondCall_ReturnsSameResult()
    {
        var calc = new CachedCalculator();

        var first = calc.Factorial(5);
        var second = calc.Factorial(5);

        Assert.That(first, Is.EqualTo(120));
        Assert.That(second, Is.EqualTo(120));
        Assert.That(second, Is.EqualTo(first));
    }

    [Test]
    public void IsPrime_SecondCall_ReturnsSameResult()
    {
        var calc = new CachedCalculator();

        var first = calc.IsPrime(13);
        var second = calc.IsPrime(13);

        Assert.That(first, Is.True);
        Assert.That(second, Is.True);
        Assert.That(second, Is.EqualTo(first));
    }

    [Test]
    public void Multiply_SecondCall_ReturnsSameResult()
    {
        var calc = new CachedCalculator();

        var first = calc.Multiply(4, 3);
        var second = calc.Multiply(4, 3);

        Assert.That(first, Is.EqualTo(12));
        Assert.That(second, Is.EqualTo(12));
        Assert.That(second, Is.EqualTo(first));
    }
}
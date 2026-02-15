using Calculator;

namespace Tests;

public class CachedCalculatorTest
{
    [Test]
    public void Add_FirstCall()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // Act
        var result = calc.Add(a, b);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void Add_SecondCall_UsesCache()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 2;
        var b = 3;

        // Act
        calc.Add(a, b); // first call (cache miss)
        var result = calc.Add(a, b); // second call (cache hit)

        // Assert
        Assert.That(result, Is.EqualTo(5));
        Assert.That(calc._cache.ContainsKey("2Add3"), Is.True);
    }

    [Test]
    public void Factorial_CachesResult()
    {
        // Arrange
        var calc = new CachedCalculator();
        var n = 5;

        // Act
        calc.Factorial(n); // first call
        var result = calc.Factorial(n); // second call (cached)

        // Assert
        Assert.That(result, Is.EqualTo(120));
        Assert.That(calc._cache.ContainsKey("5Factorial"), Is.True);
    }

    [Test]
    public void IsPrime_CachesResult()
    {
        // Arrange
        var calc = new CachedCalculator();
        var candidate = 13;

        // Act
        calc.IsPrime(candidate); // first call
        var result = calc.IsPrime(candidate); // second call (cached)

        // Assert
        Assert.That(result, Is.True);
        Assert.That(calc._cache.ContainsKey("13IsPrime"), Is.True);
    }

    [Test]
    public void Multiply_SecondCall_DoesNotAddNewCacheEntry()
    {
        // Arrange
        var calc = new CachedCalculator();
        var a = 4;
        var b = 3;

        // Act
        calc.Multiply(a, b);
        var countAfterFirst = calc._cache.Count;

        calc.Multiply(a, b);
        var countAfterSecond = calc._cache.Count;

        // Assert
        Assert.That(countAfterSecond, Is.EqualTo(countAfterFirst));
        Assert.That(calc._cache.ContainsKey("4Multiply3"), Is.True);
    }

}

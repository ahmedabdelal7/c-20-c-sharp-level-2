using System;

class Money
{
    public decimal Amount { get; }

    public Money(decimal amount)
    {
        Amount = amount;
    }

    // =========================
    // 1. Binary + and -
    // =========================

    public static Money operator +(Money m1, Money m2)
    {
        return new Money(m1.Amount + m2.Amount);
    }

    public static Money operator -(Money m1, Money m2)
    {
        return new Money(m1.Amount - m2.Amount);
    }


    // =========================
    // 2. Unary + and -
    // =========================

    public static Money operator -(Money m)
    {
        return new Money(-m.Amount);
    }

    public static Money operator +(Money m)
    {
        return new Money(+m.Amount);
    }


    // =========================
    // 3. == and !=
    // =========================

    public static bool operator ==(Money m1, Money m2)
    {
        if (ReferenceEquals(m1, m2))
            return true;

        if (m1 is null || m2 is null)
            return false;

        return m1.Amount == m2.Amount;
    }

    public static bool operator !=(Money m1, Money m2)
    {
        return !(m1 == m2);
    }


    // =========================
    // 4. > < >= <=
    // =========================

    public static bool operator >(Money m1, Money m2)
    {
        return m1.Amount > m2.Amount;
    }

    public static bool operator <(Money m1, Money m2)
    {
        return m1.Amount < m2.Amount;
    }

    public static bool operator >=(Money m1, Money m2)
    {
        return m1.Amount >= m2.Amount;
    }

    public static bool operator <=(Money m1, Money m2)
    {
        return m1.Amount <= m2.Amount;
    }


    // =========================
    // 5. implicit conversion
    // Money → decimal
    // =========================

    public static implicit operator decimal(Money money)
    {
        return money.Amount;
    }


    // =========================
    // 6. explicit conversion
    // decimal → Money
    // =========================

    public static explicit operator Money(decimal amount)
    {
        return new Money(amount);
    }


    // =========================
    // ToString
    // =========================

    public override string ToString()
    {
        return $"{Amount:C}";
    }
}


class Program
{
    static void Main()
    {
        Money m1 = new Money(100);
        Money m2 = new Money(50);


        // =========================
        // + 
        // =========================

        Money result = m1 + m2;

        Console.WriteLine(result);
        // 150


        // =========================
        // -
        // =========================

        result = m1 - m2;

        Console.WriteLine(result);
        // 50


        // =========================
        // Unary -
        // =========================

        result = -m1;

        Console.WriteLine(result);
        // -100


        // =========================
        // ==
        // =========================

        Money m3 = new Money(100);

        Console.WriteLine(m1 == m3);
        // True


        // =========================
        // !=
        // =========================

        Console.WriteLine(m1 != m2);
        // True


        // =========================
        // >
        // =========================

        Console.WriteLine(m1 > m2);
        // True


        // =========================
        // <
        // =========================

        Console.WriteLine(m1 < m2);
        // False


        // =========================
        // >=
        // =========================

        Console.WriteLine(m1 >= m3);
        // True


        // =========================
        // <=
        // =========================

        Console.WriteLine(m2 <= m1);
        // True


        // =========================
        // implicit conversion
        // Money → decimal
        // =========================

        decimal amount = m1;

        Console.WriteLine(amount);
        // 100


        // =========================
        // explicit conversion
        // decimal → Money
        // =========================

        Money m4 = (Money)200m;

        Console.WriteLine(m4);
        // 200

    Console.ReadKey();
    }
}
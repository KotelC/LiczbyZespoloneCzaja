using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        Console.WriteLine("Podaj pierwszą liczbę zespoloną:");
        ComplexNumber liczba1 = WczytajLiczbe();

        Console.WriteLine("Podaj drugą liczbę zespoloną:");
        ComplexNumber liczba2 = WczytajLiczbe();

        Console.WriteLine($"Pierwsza liczba zespolona: {liczba1}");
        Console.WriteLine($"Druga liczba zespolona: {liczba2}");

        ComplexNumber suma = liczba1.Dodaj(liczba2);
        ComplexNumber roznica = liczba1.Odejmij(liczba2);
        ComplexNumber iloczyn = liczba1.Pomnoz(liczba2);
        ComplexNumber iloraz = liczba1.Podziel(liczba2);

        Console.WriteLine($"Suma: {suma}");
        Console.WriteLine($"Różnica: {roznica}");
        Console.WriteLine($"Iloczyn: {iloczyn}");
        Console.WriteLine($"Iloraz: {iloraz}");
    }

    static ComplexNumber WczytajLiczbe()
    {
        Console.Write("Część rzeczywista: ");
        double czescRzeczywista = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        Console.Write("Część urojona: ");
        double czescUrojona = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

        return new ComplexNumber(czescRzeczywista, czescUrojona);
    }
}

class ComplexNumber
{
    public double CzescRzeczywista { get; }
    public double CzescUrojona { get; }

    public ComplexNumber(double czescRzeczywista, double czescUrojona)
    {
        CzescRzeczywista = czescRzeczywista;
        CzescUrojona = czescUrojona;
    }

    public ComplexNumber Dodaj(ComplexNumber other)
    {
        return new ComplexNumber(CzescRzeczywista + other.CzescRzeczywista, CzescUrojona + other.CzescUrojona);
    }

    public ComplexNumber Odejmij(ComplexNumber other)
    {
        return new ComplexNumber(CzescRzeczywista - other.CzescRzeczywista, CzescUrojona - other.CzescUrojona);
    }

    public ComplexNumber Pomnoz(ComplexNumber other)
    {
        return new ComplexNumber(CzescRzeczywista * other.CzescRzeczywista - CzescUrojona * other.CzescUrojona, CzescRzeczywista * other.CzescUrojona + CzescUrojona * other.CzescRzeczywista);
    }

    public ComplexNumber Podziel(ComplexNumber other)
    {
        double mianownik = other.CzescRzeczywista * other.CzescRzeczywista + other.CzescUrojona * other.CzescUrojona;
        double czescRzeczywistaCzesci = (CzescRzeczywista * other.CzescRzeczywista + CzescUrojona * other.CzescUrojona) / mianownik;
        double czescUrojonaCzesci = (CzescUrojona * other.CzescRzeczywista - CzescRzeczywista * other.CzescUrojona) / mianownik;
        return new ComplexNumber(czescRzeczywistaCzesci, czescUrojonaCzesci);
    }

    public override string ToString()
    {
        return $"{CzescRzeczywista} + {CzescUrojona}i";
    }
}

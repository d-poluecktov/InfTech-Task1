using System;
namespace ComplexCalc.Models;

public class ComplexNumber
{
    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public double Real { get; }
    public double Imaginary { get; }

    public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
    }

    public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
    {
        return new ComplexNumber(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
    }

    public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
    {
        var real = c1.Real * c2.Real - c1.Imaginary * c2.Imaginary;
        var imaginary = c1.Real * c2.Imaginary + c1.Imaginary * c2.Real;
        return new ComplexNumber(real, imaginary);
    }

    public static ComplexNumber operator /(ComplexNumber c1, ComplexNumber c2)
    {
        var denominator = c2.Real * c2.Real + c2.Imaginary * c2.Imaginary;
        var real = (c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / denominator;
        var imaginary = (c1.Imaginary * c2.Real - c1.Real * c2.Imaginary) / denominator;
        return new ComplexNumber(real, imaginary);
    }
    
    public static bool operator ==(ComplexNumber c1, ComplexNumber c2)
    {
        if (ReferenceEquals(c1, null) && ReferenceEquals(c2, null))
        {
            return true; 
        }

        if (ReferenceEquals(c1, null) || ReferenceEquals(c2, null))
        {
            return false; 
        }

        return Math.Abs(c1.Real - c2.Real) < double.Epsilon &&
               Math.Abs(c1.Imaginary - c2.Imaginary) < double.Epsilon;
    }

    public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
    {
        return !(c1 == c2);
    } 
    

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}
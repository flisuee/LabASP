using System.ComponentModel.DataAnnotations;

namespace LabApp.Models;

public class IsbnAttribute : ValidationAttribute
{
    public bool RequireChecksum { get; set; } = false;

    public IsbnAttribute()
    {
        ErrorMessage = "Nieprawidłowy numer ISBN";
    }

    public override bool IsValid(object? value)
    {
        if (value == null)
            return true;

        if (value is not string text)
            return false;

        
        string isbn = text.Replace("-", "").Replace(" ", "");

    
        if (isbn.Length != 10 && isbn.Length != 13)
            return false;

      
        foreach (char c in isbn)
        {
            if (c < '0' || c > '9')
                return false;
        }

        if (RequireChecksum && isbn.Length == 13)
        {
            int suma = 0;

            for (int i = 0; i < 13; i++)
            {
                int cyfra = isbn[i] - '0';
                suma += cyfra * (i % 2 == 0 ? 1 : 3);
            }

            return suma % 10 == 0;
        }

        return true;
    }
}
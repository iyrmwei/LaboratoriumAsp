using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class IsbnAttribute: ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is not string)
        {
            ErrorMessage = "ISB nie jset łańcuchem";
            return false;
        }

        string isbn = value as string;

        if (isbn.Length != 10 && isbn.Length != 13)
        {
            ErrorMessage = "ISBN ma niepoprawną długość";
            return false;
        }

        return true;
    }
}
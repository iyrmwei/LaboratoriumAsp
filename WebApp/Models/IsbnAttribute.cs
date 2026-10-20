using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApp.Models;

public class IsbnAttribute: ValidationAttribute
{
    public bool RequireChecksum { get; set; } = false;
    public override bool IsValid(object? value)
    {
        
        
        if (value is not string)
        {
            ErrorMessage = "ISB nie jset łańcuchem";
            return false;
        }

        string isbn = value as string;
        var cleanIsbn = isbn.Replace("-", "").Replace(" ", "");

        if (cleanIsbn.Length != 10 && cleanIsbn.Length != 13)
        {
            ErrorMessage = "ISBN ma niepoprawną długość";
            return false;
        }

        if (!Regex.IsMatch(isbn,
                "^(?:ISBN(?:-1[03])?:?\\s*)?(?:(?=(?:\\D*\\d){13}$)97[89][- ]?\\d{1,5}[- ]?\\d{1,7}[- ]?\\d{1,7}[- ]?\\d|(?=(?:\\D*\\d){9}[\\dXx]$)\\d{1,5}[- ]?\\d{1,7}[- ]?\\d{1,7}[- ]?[\\dXx])$"))
        {
            ErrorMessage = "Nieprawidłowy format ISBN";
            return false;
        }

        return true;
    }
}
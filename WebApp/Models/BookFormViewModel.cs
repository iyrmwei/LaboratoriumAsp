using System.ComponentModel.DataAnnotations;

namespace WebApp.Models;

public class BookFormViewModel: IValidatableObject
{
    [Required(ErrorMessage = "Tytuł jest wymagany")]
    [StringLength(200, MinimumLength = 2, ErrorMessage = "Tytuł: 2–200 znaków")]
    [Display(Name = "Tytuł")]
    public string Title { get; set; } = "";

    [Required, Isbn]                          // własny atrybut – część E
    [RegularExpression("^(?:ISBN(?:-1[03])?:?\\s*)?(?:(?=(?:\\D*\\d){13}$)97[89][- ]?\\d{1,5}[- ]?\\d{1,7}[- ]?\\d{1,7}[- ]?\\d|(?=(?:\\D*\\d){9}[\\dXx]$)\\d{1,5}[- ]?\\d{1,7}[- ]?\\d{1,7}[- ]?[\\dXx])$",
        ErrorMessage = "Nieprawidłowy format ISBN")]
    public string Isbn { get; set; } = "";

    [DataType(DataType.Date)] [NotInFuture]   // własny atrybut – część E
    [Display(Name = "Data wydania")]
    public DateTime? PublicationDate { get; set; }

    [Range(1, 20000)] [Display(Name = "Liczba stron")]
    public int NumPages { get; set; } = 100;

    [Range(0.01, 10000, ErrorMessage = "Cena musi być dodatnia")] [Display(Name = "Cena")]
    public decimal Price { get; set; }

    [Required, Display(Name = "Autor")]
    public string Author { get; set; } = "";

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();
        if (PublicationDate?.Year < 1900 && Price > 100)
        {
            results.Add(new ValidationResult("Książka sprzed 1900 r. nie może kosztować więcej niż 100 zł"));
        }
        
        return results;
    }
}
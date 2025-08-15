using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TODOList.ORM.Models;

[Owned]
public class Address
{
    public string Street { get; set; }
    
    public string City { get; set; }
    
    public string State { get; set; }
    
    [RegularExpression("[0-9]{3,}", ErrorMessage = "Postal Code must contain only digits.")]
    public string PostalCode { get; set; }
    
    public string Country { get; set; }

    public override string? ToString()
    {
        return new Dictionary<string, string>()
        {
            { "Street", Street},
            { "City" , City},
            { "State", State },
            { "PostalCode", PostalCode },
            { "Country", Country},
        }.ToString();
    }
}
using Car_Rental.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Rental.Common.Classes;

public class Customer : IPerson
{
    public int SocialSecurityNumber { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public Customer(int socialSecurityNumber, string firstName, string lastName) =>
       (SocialSecurityNumber, FirstName, LastName) = (socialSecurityNumber, firstName, lastName);
}

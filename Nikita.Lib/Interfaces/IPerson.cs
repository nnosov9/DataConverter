using System;

namespace Nikita.Lib.Interfaces
{
    public interface IPerson
    {
         string LastName { get; set; }
         string FirstName { get; set; }
         string Gender { get; set; }
         string FavoriteColor { get; set; }
         DateTime? DateOfBirth { get; set; }
    }
}

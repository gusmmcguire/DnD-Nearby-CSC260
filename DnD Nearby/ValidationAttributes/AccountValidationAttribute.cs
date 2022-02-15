using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DnD_Nearby.ValidationAttributes
{
    public class AccountValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //grab the properties for first and last name, this does not get the values, only the property information about them
            var firstNameProp = validationContext.ObjectType.GetProperty("FirstName");
            var lastNameProp = validationContext.ObjectType.GetProperty("LastName");

            var idPossible = validationContext.ObjectType.GetProperty("Id").GetValue(validationContext.ObjectInstance);

            //isCreation will be true if this is a valid creation of the account, otherwise it will be false and we
            //need to check to be sure that we are logging in, not only being passed one part of the name
            bool isCreation = firstNameProp.GetValue(validationContext.ObjectInstance) != null && lastNameProp.GetValue(validationContext.ObjectInstance) != null;

            //checks to see if we only have one name using an or, but because this is paired with the above condition of both, the OR statement will be true if one of them is filled
            //and not the other because this check will not happen with both being filled
            if (!isCreation)
            {
                if(firstNameProp.GetValue(validationContext.ObjectInstance) != null || lastNameProp.GetValue(validationContext.ObjectInstance) != null)
                {
                    return new ValidationResult("You have only provided one part of your name and both are required.");
                }
            }

            return ValidationResult.Success;
        }
    }
}

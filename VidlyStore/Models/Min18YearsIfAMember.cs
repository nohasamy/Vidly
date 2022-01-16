﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyStore.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknowen ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Date of Birth is required.");
            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            return age >= 18
                ? ValidationResult.Success
                : new ValidationResult("Customer must be at least 18 years old to have a membership.");
        }
    }
}
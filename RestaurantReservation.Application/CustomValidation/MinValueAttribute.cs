using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using RestaurantReservation.Application.Resources;

namespace RestaurantReservation.Application.CustomValidation
{
    public class MinValueAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _minValue;

        public MinValueAttribute(int minValue)
        {
            _minValue = minValue;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-MinValue", ReservationResources.Min1);
        }

        public override bool IsValid(object value)
        {
            return (int)value >= _minValue;
        }
    }
}

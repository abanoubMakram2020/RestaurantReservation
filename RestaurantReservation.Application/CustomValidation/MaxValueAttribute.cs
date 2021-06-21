using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using RestaurantReservation.Application.Resources;


namespace RestaurantReservation.Application.CustomValidation
{
    public class MaxValueAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly int _maxValue;

        public MaxValueAttribute(int maxValue)
        {
            _maxValue = maxValue;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-MaxValue",ReservationResources.Max10);
        }

        public override bool IsValid(object value)
        {
            return (int)value <= _maxValue;
        }
    }
}

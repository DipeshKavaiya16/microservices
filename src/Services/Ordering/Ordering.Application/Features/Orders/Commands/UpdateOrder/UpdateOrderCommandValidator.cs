using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User name is required.").NotNull().MaximumLength(50).WithMessage("Username must not exceed 50 characters.");
            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage("Email address is required.").EmailAddress().WithMessage("please enter valid email address.");
            RuleFor(x => x.TotalPrice).NotEmpty().WithMessage("Total price is required.").GreaterThan(0).WithMessage("Total price should be greater than zero.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.").NotNull().MaximumLength(25).WithMessage("Last name must not exceed 25 characters.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.").NotNull().MaximumLength(25).WithMessage("Last name must not exceed 25 characters.");
            RuleFor(x => x.AddressLine).NotEmpty().WithMessage("Address is required.").NotNull().MaximumLength(200).WithMessage("Address must not exceed 200 characters.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("Country is required.").NotNull().MaximumLength(60).WithMessage("Country must not exceed 60 characters.");
            RuleFor(x => x.State).NotEmpty().WithMessage("State is required.").NotNull().MaximumLength(60).WithMessage("State must not exceed 60 characters.");
            RuleFor(x => x.ZipCode).NotEmpty().WithMessage("Zip code is required.").NotNull().MaximumLength(10).WithMessage("Zipcode must not exceed 10 characters/digits");
        }
    }
}

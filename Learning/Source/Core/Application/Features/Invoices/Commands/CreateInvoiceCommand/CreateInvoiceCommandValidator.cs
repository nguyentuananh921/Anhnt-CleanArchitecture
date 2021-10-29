using Application.Features.Invoices.ViewModels;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Invoices.Commands.CreateInvoiceCommand
{
    public class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
    {
        public CreateInvoiceCommandValidator()
        {
            RuleFor(v => v.AmountPaid).NotNull();
            RuleFor(v => v.Date).NotNull();
            RuleFor(v => v.From).NotEmpty().MinimumLength(3);
            RuleFor(v => v.To).NotEmpty().MinimumLength(3);
            //RuleFor(v => v.InvoiceItems).SetValidator(new MustHaveInvoiceItemPropertyValidator());
            //Remove this rule for later study.
        }
    }
    //public class MustHaveInvoiceItemPropertyValidator : PropertyValidator
    //{
    //    public MustHaveInvoiceItemPropertyValidator()
    //        : base("Property {PropertyName} should not be an empty list.")
    //    {

    //    }
    //    protected override bool IsValid(PropertyValidatorContext context)
    //    {
    //        var list = context.PropertyValue as IList<InvoiceItemVm>;
    //        return list != null && list.Any();
    //    }
    //}
}

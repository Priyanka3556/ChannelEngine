using ChannelEngineShared.Models;
using FluentValidation;

namespace ChannelEngineWebApplication.Validators
{
    public class OrderRequestValidator :  AbstractValidator<OrderRequest>
    {
        public OrderRequestValidator()
        {
            RuleFor(r => r.Status).NotNull().NotEmpty();
            RuleFor(r => r.TopCount).GreaterThan(0);
        }
    }
}

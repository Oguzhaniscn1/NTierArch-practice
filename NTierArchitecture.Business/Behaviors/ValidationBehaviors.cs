using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace NTierArchitecture.Business.Behaviors
{
    public sealed class ValidationBehaviors<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class, IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validator;

        public ValidationBehaviors(IEnumerable<IValidator<TRequest>> validator)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(!_validator.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errorDicrionary = _validator
                .Select(s => s.Validate(context))
                .SelectMany(s => s.Errors)
                .Where(s => s.Equals != null)
                .GroupBy(
                s => s.PropertyName,
                s => s.ErrorMessage, (propertyName, errorMessage) => new
                {
                    Key = propertyName,
                    Values = errorMessage.Distinct().ToArray()
                })
                .ToDictionary(s => s.Key, s => s.Values[0]);

            if(errorDicrionary.Any())
            {
                var errors = errorDicrionary.Select(s => new ValidationFailure
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });

                throw new ValidationException(errors);
            }

            return await next();


        }
    }
}

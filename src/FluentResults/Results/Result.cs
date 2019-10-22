using FluentValidation.Results;
using System.Linq;

namespace FluentResults
{
    public class Result : ResultBase<Result>
    {
        public static implicit operator Result(ValidationResult validation)
        {
            var result = new Result();
            result.WithReason(validation.Errors.Select(x => new Error(x.ErrorMessage)).ToList());
            return result;
        }
    }

    public class Result<TValue> : ValueResultBase<Result<TValue>, TValue>
    {
        public static implicit operator Result<TValue>(Result result)
        {
            return result.ToResult<TValue>();
        }

        public static implicit operator Result(Result<TValue> result)
        {
            return result.ToResult();
        }

        public static implicit operator Result<TValue>(ValidationResult validation)
        {
            var result = new Result<TValue>();
            result.WithReason(validation.Errors.Select(x => new Error(x.ErrorMessage)).ToList());
            return result;
        }
    }
}
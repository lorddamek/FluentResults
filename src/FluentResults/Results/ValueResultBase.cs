﻿namespace FluentResults
{
    public abstract class ValueResultBase<TResult, TValue> : ResultBase<TResult>
        where TResult : ValueResultBase<TResult, TValue>
    {
        public TValue Value { get; private set; }

        public TResult WithValue(TValue value)
        {
            Value = value;
            return (TResult)this;
        }

        public TResult Merge(params ResultBase[] results)
        {
            foreach (var result in results)
            {
                foreach (var reason in result.Reasons)
                {
                    WithReason(reason);
                }
            }

            return (TResult)this;
        }

        public Result ToResult()
        {
            return ResultHelper.Merge<Result>(this);
        }

        public override string ToString()
        {
            var baseString = base.ToString();
            var valueString = Value.ToLabelValueStringOrEmpty(nameof(Value));
            return $"{baseString}, {valueString}";
        }
    }
}

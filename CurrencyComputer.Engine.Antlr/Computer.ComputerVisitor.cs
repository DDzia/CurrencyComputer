using CurrencyComputer.Core;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CurrencyComputer.Engine.Antlr
{


    public sealed partial class Computer : IConversionComputer
    {
        private sealed class ComputerVisitor : CurrencyComputerBaseVisitor<object>
        {
            private static readonly IReadOnlyDictionary<string, Func<decimal, decimal, decimal>> Operations = new ReadOnlyDictionary<string, Func<decimal, decimal, decimal>>(new Dictionary<string, Func<decimal, decimal, decimal>>()
            {
                { "+", (l, r) => l + r },
                { "-", (l, r) => l - r }
            });

            private readonly IDictionary<string, Dictionary<string, decimal>> _conversionsCost;
            private readonly IDictionary<string, string> _conversionToCurrencyConventions;

            private readonly ILogger _logger;

            private string _targetCurrency;

            public ComputerVisitor(
                IDictionary<string, Dictionary<string, decimal>> conversionsCost,
                IDictionary<string, string> conversionToCurrencyConventions,
                ILogger logger)
            {
                _conversionsCost = conversionsCost;
                _conversionToCurrencyConventions = conversionToCurrencyConventions;
                _logger = logger;
            }

            //public override object VisitOperatorRight(CurrencyComputerParser.OperatorRightContext context)
            //{
            //    //var @operator = (string)VisitOperator(context.@operator());
            //    //var amount = (decimal)VisitAmount(context.amount());

            //    //return new Tuple<string, decimal>(@operator, amount);

            //    return null;
            //}

            public override object VisitConversion(CurrencyComputerParser.ConversionContext context)
            {
                var conversion = context?.GetText();
                return conversion;
            }

            public override object VisitCurrency(CurrencyComputerParser.CurrencyContext context)
            {
                var currency = context.GetText();
                return currency;
            }

            public override object VisitNumber(CurrencyComputerParser.NumberContext context)
            {
                try
                {
                    var str = context.GetText();
                    return decimal.Parse(str);
                }
                catch (Exception e)
                {
                    throw new Exception("TODO: some messages");
                }
            }

            public override object VisitAmount(CurrencyComputerParser.AmountContext context)
            {
                var value = (decimal)VisitNumber(context.number());
                var currency = (string)VisitCurrency(context.currency());

                // Контроль типов: нельзя конвертировать валюту в саму себя
                if (currency == _targetCurrency)
                {
                    return value;
                }

                var cost = _conversionsCost[currency][_targetCurrency];

                var result = value * cost;
                return result;
            }

            //public override object VisitOperation(CurrencyComputerParser.OperationContext context)
            //{
            //    var left = (decimal)VisitAmount(context.amount());

            //    decimal result = left;
            //    //foreach (var ctx in context.operatorRight())
            //    //{
            //    //    var pair = (Tuple<string, decimal>)VisitOperatorRight(ctx);
            //    //    result = Operations[pair.Item1](result, pair.Item2);
            //    //}
                

            //    //var operandLeft = (decimal)VisitAmount(context.amount(0));
            //    //var @operator = (string)VisitOperator(context.@operator());
            //    //var operandRight = (decimal)VisitAmount(context.amount(1));

            //    return result;
            //}

            //public override object VisitOperationComposite(CurrencyComputerParser.OperationCompositeContext context)
            //{
            //    //decimal left;
            //    //{
            //    //    try
            //    //    {
            //    //        var compositeContext = context.
            //    //        left = (decimal)VisitOperationComposite(compositeContext);
            //    //    }
            //    //    catch
            //    //    {
            //    //        var operationContext = context.operation();
            //    //        left = (decimal)VisitOperation(operationContext);
            //    //    }
            //    //}

            //    var left = (decimal)VisitOperation(context.operation());
            //    var @operator = (string)VisitOperator(context.@operator());
            //    var right = (decimal)VisitAmount(context.amount());

            //    return Operations[@operator](left, right);
            //}

            public override object VisitOperator(CurrencyComputerParser.OperatorContext context)
            {
                var value = context.GetText();
                return value;
            }

            public override object VisitExpression(CurrencyComputerParser.ExpressionContext context)
            {
                var amounts = context.amount();
                var left = (decimal)VisitAmount(amounts[0]);
                var @operator = (string)VisitOperator(context.@operator());

                var right = amounts.Length == 2
                    ? (decimal) VisitAmount(amounts[1])
                    : (decimal) VisitExpression(context.expression());

                return Operations[@operator](left, right);
            }

            public override object VisitInput(CurrencyComputerParser.InputContext context)
            {
                var conversion = (string)VisitConversion(context.conversion());
                _targetCurrency = _conversionToCurrencyConventions[conversion];

                return VisitExpression(context.expression());
            }
        }
    }
}

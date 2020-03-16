//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from CurrencyComputer.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="CurrencyComputerParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface ICurrencyComputerVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.input"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInput([NotNull] CurrencyComputerParser.InputContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.expression"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpression([NotNull] CurrencyComputerParser.ExpressionContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.amountComposite"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAmountComposite([NotNull] CurrencyComputerParser.AmountCompositeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.amountSignedConvertible"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAmountSignedConvertible([NotNull] CurrencyComputerParser.AmountSignedConvertibleContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.amountSigned"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAmountSigned([NotNull] CurrencyComputerParser.AmountSignedContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.operatorAndSpaces"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperatorAndSpaces([NotNull] CurrencyComputerParser.OperatorAndSpacesContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.operator"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitOperator([NotNull] CurrencyComputerParser.OperatorContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.amount"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitAmount([NotNull] CurrencyComputerParser.AmountContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.currency"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCurrency([NotNull] CurrencyComputerParser.CurrencyContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.number"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNumber([NotNull] CurrencyComputerParser.NumberContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="CurrencyComputerParser.conversion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConversion([NotNull] CurrencyComputerParser.ConversionContext context);
}

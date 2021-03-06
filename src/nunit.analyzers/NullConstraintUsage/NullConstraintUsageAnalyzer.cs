using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using NUnit.Analyzers.Constants;
using NUnit.Analyzers.Helpers;

namespace NUnit.Analyzers.NullConstraintUsage
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class NullConstraintUsageAnalyzer : BaseAssertionAnalyzer
    {
        private static readonly DiagnosticDescriptor descriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.NullConstraintUsage,
            title: NullConstraintUsageAnalyzerConstants.Title,
            messageFormat: NullConstraintUsageAnalyzerConstants.Message,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Warning,
            description: NullConstraintUsageAnalyzerConstants.Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(descriptor);

        protected override void AnalyzeAssertInvocation(SyntaxNodeAnalysisContext context,
            InvocationExpressionSyntax assertExpression, IMethodSymbol methodSymbol)
        {
            if (!AssertHelper.TryGetActualAndConstraintExpressions(assertExpression, context.SemanticModel,
                out var actualExpression, out var constraintExpression))
            {
                return;
            }

            foreach (var constraintPart in constraintExpression.ConstraintParts)
            {
                var prefixes = constraintPart.GetPrefixesNames();

                // Only Not prefix supported
                var prefixesSupported = prefixes.Length == 0
                    || (prefixes.Length == 1 && prefixes[0] == NunitFrameworkConstants.NameOfIsNot);

                if (prefixesSupported
                    && constraintPart.GetHelperClassName() == NunitFrameworkConstants.NameOfIs
                    && constraintPart.GetConstraintName() == NunitFrameworkConstants.NameOfNull)
                {
                    var actualType = AssertHelper.GetUnwrappedActualType(actualExpression, context.SemanticModel, context.CancellationToken);

                    if (actualType == null)
                        return;

                    if (actualType.IsValueType && actualType.OriginalDefinition.SpecialType != SpecialType.System_Nullable_T)
                    {
                        var typeDisplay = actualType.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat);

                        context.ReportDiagnostic(Diagnostic.Create(
                            descriptor,
                            constraintPart.RootExpression.GetLocation(),
                            typeDisplay));
                    }
                }
            }
        }
    }
}

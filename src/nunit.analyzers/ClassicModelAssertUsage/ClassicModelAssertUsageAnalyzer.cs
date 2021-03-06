using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using NUnit.Analyzers.Constants;
using static NUnit.Analyzers.Constants.NunitFrameworkConstants;

namespace NUnit.Analyzers.ClassicModelAssertUsage
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class ClassicModelAssertUsageAnalyzer : BaseAssertionAnalyzer
    {
        private static readonly DiagnosticDescriptor isTrueDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.IsTrueUsage,
            title: ClassicModelUsageAnalyzerConstants.IsTrueTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.IsTrueMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Info,
            description: ClassicModelUsageAnalyzerConstants.IsTrueDescription);

        private static readonly DiagnosticDescriptor trueDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.TrueUsage,
            title: ClassicModelUsageAnalyzerConstants.TrueTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.TrueMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Info,
            description: ClassicModelUsageAnalyzerConstants.TrueDescription);

        private static readonly DiagnosticDescriptor isFalseDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.IsFalseUsage,
            title: ClassicModelUsageAnalyzerConstants.IsFalseTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.IsFalseMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Info,
            description: ClassicModelUsageAnalyzerConstants.IsFalseDescription);

        private static readonly DiagnosticDescriptor falseDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.FalseUsage,
            title: ClassicModelUsageAnalyzerConstants.FalseTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.FalseMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Info,
            description: ClassicModelUsageAnalyzerConstants.FalseDescription);

        private static readonly DiagnosticDescriptor areEqualDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.AreEqualUsage,
            title: ClassicModelUsageAnalyzerConstants.AreEqualTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.AreEqualMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Warning,
            description: ClassicModelUsageAnalyzerConstants.AreEqualDescription);

        private static readonly DiagnosticDescriptor areNotEqualDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.AreNotEqualUsage,
            title: ClassicModelUsageAnalyzerConstants.AreNotEqualTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.AreNotEqualMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Warning,
            description: ClassicModelUsageAnalyzerConstants.AreNotEqualDescription);

        private static readonly DiagnosticDescriptor areSameDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.AreSameUsage,
            title: ClassicModelUsageAnalyzerConstants.AreSameTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.AreSameMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Warning,
            description: ClassicModelUsageAnalyzerConstants.AreSameDescription);

        private static readonly DiagnosticDescriptor isNullDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.IsNullUsage,
            title: ClassicModelUsageAnalyzerConstants.IsNullTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.IsNullMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Info,
            description: ClassicModelUsageAnalyzerConstants.IsNullDescription);

        private static readonly DiagnosticDescriptor nullDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.NullUsage,
            title: ClassicModelUsageAnalyzerConstants.NullTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.NullMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Info,
            description: ClassicModelUsageAnalyzerConstants.NullDescription);

        private static readonly DiagnosticDescriptor isNotNullDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.IsNotNullUsage,
            title: ClassicModelUsageAnalyzerConstants.IsNotNullTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.IsNotNullMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Info,
            description: ClassicModelUsageAnalyzerConstants.IsNotNullDescription);

        private static readonly DiagnosticDescriptor notNullDescriptor = DiagnosticDescriptorCreator.Create(
            id: AnalyzerIdentifiers.NotNullUsage,
            title: ClassicModelUsageAnalyzerConstants.NotNullTitle,
            messageFormat: ClassicModelUsageAnalyzerConstants.NotNullMessage,
            category: Categories.Assertion,
            defaultSeverity: DiagnosticSeverity.Info,
            description: ClassicModelUsageAnalyzerConstants.NotNullDescription);

        private static readonly ImmutableDictionary<string, DiagnosticDescriptor> name =
          new Dictionary<string, DiagnosticDescriptor>
          {
              { NameOfAssertIsTrue, isTrueDescriptor },
              { NameOfAssertTrue, trueDescriptor },
              { NameOfAssertIsFalse, isFalseDescriptor },
              { NameOfAssertFalse, falseDescriptor },
              { NameOfAssertAreEqual, areEqualDescriptor },
              { NameOfAssertAreNotEqual, areNotEqualDescriptor },
              { NameOfAssertAreSame, areSameDescriptor },
              { NameOfAssertIsNull, isNullDescriptor },
              { NameOfAssertNull, nullDescriptor },
              { NameOfAssertIsNotNull, isNotNullDescriptor },
              { NameOfAssertNotNull, notNullDescriptor }
          }.ToImmutableDictionary();

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ClassicModelAssertUsageAnalyzer.name.Values.ToImmutableArray();

        protected override void AnalyzeAssertInvocation(SyntaxNodeAnalysisContext context,
            InvocationExpressionSyntax assertExpression, IMethodSymbol methodSymbol)
        {
            if (ClassicModelAssertUsageAnalyzer.name.ContainsKey(methodSymbol.Name))
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    ClassicModelAssertUsageAnalyzer.name[methodSymbol.Name],
                    assertExpression.GetLocation(),
                    ClassicModelAssertUsageAnalyzer.GetProperties(methodSymbol)));
            }
        }

        private static ImmutableDictionary<string, string> GetProperties(IMethodSymbol invocationSymbol)
        {
            return new Dictionary<string, string>
            {
                { AnalyzerPropertyKeys.ModelName, invocationSymbol.Name },
                { AnalyzerPropertyKeys.HasToleranceValue,
                    (invocationSymbol.Name == NameOfAssertAreEqual &&
                        invocationSymbol.Parameters.Length >= 3 &&
                        invocationSymbol.Parameters[2].Type.SpecialType == SpecialType.System_Double).ToString() }
            }.ToImmutableDictionary();
        }
    }
}

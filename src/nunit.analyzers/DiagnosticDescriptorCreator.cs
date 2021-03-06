using Microsoft.CodeAnalysis;

namespace NUnit.Analyzers
{
    internal static class DiagnosticDescriptorCreator
    {
        internal static DiagnosticDescriptor Create(
            string id,
            string title,
            string messageFormat,
            string category,
            DiagnosticSeverity defaultSeverity,
            string description) =>
            new DiagnosticDescriptor(
                id: id,
                title: title,
                messageFormat: messageFormat,
                category: category,
                defaultSeverity: defaultSeverity,
                isEnabledByDefault: true,
                description: description,
                helpLinkUri: CreateLink(id),
                customTags: new string[0]);

        private static string CreateLink(string id) =>
            $"https://github.com/nunit/nunit.analyzers/tree/master/documentation/{id}.md";
    }
}

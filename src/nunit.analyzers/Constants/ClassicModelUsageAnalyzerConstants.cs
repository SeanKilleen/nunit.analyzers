namespace NUnit.Analyzers.Constants
{
    internal static class ClassicModelUsageAnalyzerConstants
    {
        internal const string IsTrueTitle = "Consider using Assert.That(expr, Is.True) instead of Assert.IsTrue(expr).";
        internal const string IsTrueMessage = "Consider using the constraint model, Assert.That(expr, Is.True), instead of the classic model, Assert.IsTrue(expr).";
        internal const string IsTrueDescription = "Consider using the constraint model, Assert.That(expr, Is.True), instead of the classic model, Assert.IsTrue(expr).";

        internal const string TrueTitle = "Consider using Assert.That(expr, Is.True) instead of Assert.True(expr).";
        internal const string TrueMessage = "Consider using the constraint model, Assert.That(expr, Is.True), instead of the classic model, Assert.True(expr).";
        internal const string TrueDescription = "Consider using the constraint model, Assert.That(expr, Is.True), instead of the classic model, Assert.True(expr).";

        internal const string IsFalseTitle = "Consider using Assert.That(expr, Is.False) instead of Assert.IsFalse(expr).";
        internal const string IsFalseMessage = "Consider using the constraint model, Assert.That(expr, Is.False), instead of the classic model, Assert.IsFalse(expr).";
        internal const string IsFalseDescription = "Consider using the constraint model, Assert.That(expr, Is.False), instead of the classic model, Assert.IsFalse(expr).";

        internal const string FalseTitle = "Consider using Assert.That(expr, Is.False) instead of Assert.False(expr).";
        internal const string FalseMessage = "Consider using the constraint model, Assert.That(expr, Is.False), instead of the classic model, Assert.False(expr).";
        internal const string FalseDescription = "Consider using the constraint model, Assert.That(expr, Is.False), instead of the classic model, Assert.False(expr).";

        internal const string AreEqualTitle = "Consider using Assert.That(expr2, Is.EqualTo(expr1)) instead of Assert.AreEqual(expr1, expr2).";
        internal const string AreEqualMessage = "Consider using the constraint model, Assert.That(expr2, Is.EqualTo(expr1)), instead of the classic model, Assert.AreEqual(expr1, expr2).";
        internal const string AreEqualDescription = "Consider using the constraint model, Assert.That(expr2, Is.EqualTo(expr1)), instead of the classic model, Assert.AreEqual(expr1, expr2).";

        internal const string AreNotEqualTitle = "Consider using Assert.That(expr2, Is.Not.EqualTo(expr1)) instead of Assert.AreNotEqual(expr1, expr2).";
        internal const string AreNotEqualMessage = "Consider using the constraint model, Assert.That(expr2, Is.Not.EqualTo(expr1)), instead of the classic model, Assert.AreNotEqual(expr1, expr2).";
        internal const string AreNotEqualDescription = "Consider using the constraint model, Assert.That(expr2, Is.Not.EqualTo(expr1)), instead of the classic model, Assert.AreNotEqual(expr1, expr2).";

        internal const string AreSameTitle = "Consider using Assert.That(expr2, Is.SameAs(expr1)) instead of Assert.AreSame(expr1, expr2).";
        internal const string AreSameMessage = "Consider using the constraint model, Assert.That(expr2, Is.SameAs(expr1)), instead of the classic model, Assert.AreSame(expr1, expr2).";
        internal const string AreSameDescription = "Consider using the constraint model, Assert.That(expr2, Is.SameAs(expr1)), instead of the classic model, Assert.AreSame(expr1, expr2).";

        internal const string IsNullTitle = "Consider using Assert.That(expr, Is.Null) instead of Assert.IsNull(expr).";
        internal const string IsNullMessage = "Consider using the constraint model, Assert.That(expr, Is.Null), instead of the classic model, Assert.IsNull(expr).";
        internal const string IsNullDescription = "Consider using the constraint model, Assert.That(expr, Is.Null), instead of the classic model, Assert.IsNull(expr).";

        internal const string NullTitle = "Consider using Assert.That(expr, Is.Null) instead of Assert.Null(expr).";
        internal const string NullMessage = "Consider using the constraint model, Assert.That(expr, Is.Null), instead of the classic model, Assert.Null(expr).";
        internal const string NullDescription = "Consider using the constraint model, Assert.That(expr, Is.Null), instead of the classic model, Assert.Null(expr).";

        internal const string IsNotNullTitle = "Consider using Assert.That(expr, Is.Not.Null) instead of Assert.IsNotNull(expr).";
        internal const string IsNotNullMessage = "Consider using the constraint model, Assert.That(expr, Is.Not.Null), instead of the classic model, Assert.IsNotNull(expr).";
        internal const string IsNotNullDescription = "Consider using the constraint model, Assert.That(expr, Is.Not.Null), instead of the classic model, Assert.IsNotNull(expr).";

        internal const string NotNullTitle = "Consider using Assert.That(expr, Is.Not.Null) instead of Assert.NotNull(expr).";
        internal const string NotNullMessage = "Consider using the constraint model, Assert.That(expr, Is.Not.Null), instead of the classic model, Assert.NotNull(expr).";
        internal const string NotNullDescription = "Consider using the constraint model, Assert.That(expr, Is.Not.Null), instead of the classic model, Assert.NotNull(expr).";
    }
}

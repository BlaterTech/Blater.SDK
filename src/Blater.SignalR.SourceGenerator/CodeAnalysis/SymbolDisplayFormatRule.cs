using Microsoft.CodeAnalysis;

namespace Blater.SignalR.SourceGenerator.CodeAnalysis;

internal static class SymbolDisplayFormatRule
{
    public static SymbolDisplayFormat FullyQualifiedFormat { get; } = SymbolDisplayFormat.FullyQualifiedFormat;

    public static SymbolDisplayFormat FullyQualifiedNullableReferenceTypeFormat { get; } = SymbolDisplayFormat.FullyQualifiedFormat
        .AddMiscellaneousOptions(SymbolDisplayMiscellaneousOptions.IncludeNullableReferenceTypeModifier);
}

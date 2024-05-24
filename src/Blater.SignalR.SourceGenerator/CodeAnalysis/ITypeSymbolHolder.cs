using Microsoft.CodeAnalysis;

namespace Blater.SignalR.SourceGenerator.CodeAnalysis;

public interface ITypeSymbolHolder
{
    ITypeSymbol TypeSymbol { get; }
}

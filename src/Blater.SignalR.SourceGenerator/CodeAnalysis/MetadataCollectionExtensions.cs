using System.Collections.Generic;
using Microsoft.CodeAnalysis;

namespace Blater.SignalR.SourceGenerator.CodeAnalysis;

public static class MetadataCollectionExtensions
{
    public static bool Contains(this IEnumerable<ITypeSymbolHolder> source, ITypeSymbol typeSymbol)
    {
        foreach (var item in source)
        {
            if (SymbolEqualityComparer.Default.Equals(item.TypeSymbol, typeSymbol))
            {
                return true;
            }
        }

        return false;
    }
}

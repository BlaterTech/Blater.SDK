using Blater.Interfaces;
using Blater.Models.Bases;

namespace Blater.SDK.Interfaces;

public interface IBlaterDatabaseStoreTEndpoints<T> : IBlaterDatabaseStoreT<T> where T : BaseDataModel
{
}
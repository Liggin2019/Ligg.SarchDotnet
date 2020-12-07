using Ligg.Base.DataModel.Paged;

namespace Ligg.Base.DataModel.Paged
{
    public interface IPagedList<T> : IListResult<T>, IHasTotalCount
    {
    }
}
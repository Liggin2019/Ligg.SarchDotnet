using Ligg.Abp.Application.Contracts;
using Ligg.Base.DataModel.ServiceResult;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Ligg.Base.DataModel.Paged;

namespace Ligg.Abp.Application
{
    public interface ITransactionService
    {

        //#list
        Task<ServiceResultT<IEnumerable<TransactionListTreeDto>>> GetAllTransactions();
        Task<ServiceResultT<IEnumerable<TransactionListTreeDto>>> GetLeftMenuItems(string parentId);
        Task<ServiceResultT<PagedList<TransactionMtnListDto>>> GetChildsForMtn(string parentId, int pageIndex, int pageSize);

        //#add
        Task<ServiceResult> AddTransaction(TransactionAddDto input);

        //#del
        Task<ServiceResult> DeleteTransactions(String[] Ids);

        //#mod
        Task<ServiceResult> ModifyTransaction(TransactionModDto input);
        Task<ServiceResult> ChangeParent(Guid parentId, String[] transactionIds);

        //#get
        Task<ServiceResultT<TransactionModDto>> GetTransaction(Guid Id);


    }
}

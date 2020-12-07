using Ligg.Abp.Application.Contracts;
using Ligg.Abp.Domain;
using Ligg.Abp.Domain.IRepositories;
using Ligg.Abp.Domain.Shared.Enums;
using Ligg.Base.DataModel.Paged;
using Ligg.Base.DataModel.ServiceResult;
using Ligg.Base.Extensions;
using Ligg.Base.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using static Ligg.Abp.Domain.Shared.Consts;

namespace Ligg.Abp.Application.Impl
{
    public class TransactionService : ServiceBase, ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        //#list
        public async Task<ServiceResultT<IEnumerable<TransactionListTreeDto>>> GetAllTransactions()
        {
            var result = new ServiceResultT<IEnumerable<TransactionListTreeDto>>();

            var transactions = await _transactionRepository.GetListAsync();

            var list = ObjectMapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionListTreeDto>>(transactions);
            list = list.OrderBy(x => x.OrderTag);
            result.IsSuccess(list);
            return result;
        }

        public async Task<ServiceResultT<IEnumerable<TransactionListTreeDto>>> GetLeftMenuItems(string parentId)
        {
            var result = new ServiceResultT<IEnumerable<TransactionListTreeDto>>();
            var transactions = await _transactionRepository.GetListAsync();
            var list = ObjectMapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionListTreeDto>>(transactions);
            list = list.Where(x => (x.Type == (int)TransactionType.Virtual | x.Type == (int)TransactionType.View));
            var list1 = new List<TransactionListTreeDto>();
            foreach (var item in list.Where(x => x.ParentId.ToString() == parentId.ToLower()))
            {
                list1.Add(item);
                GetLeftMenuItems(item.Id.ToString(), list1, list);
            }

            var list2 = list1.OrderBy(x => x.OrderTag);

            result.IsSuccess(list2);
            return result;

        }

        public async Task<ServiceResultT<PagedList<TransactionMtnListDto>>> GetChildsForMtn(string parentId, int pageIndex, int pageSize)
        {
            var result = new ServiceResultT<PagedList<TransactionMtnListDto>>();
            var list = await _transactionRepository.GetListAsync();
            var list1 = list.FindAll(x => x.ParentId.ToString() == parentId);
            var list2 = ObjectMapper.Map<IEnumerable<Transaction>, IEnumerable<TransactionMtnListDto>>(list1);
            list2 = list2.OrderByDescending(x => x.ModificationTime);
            var count = list2.ToList().Count;
            var list3 = list2.AsQueryable().PageByIndex(pageIndex, pageSize);
            foreach (var obj in list3)
            {
                obj.TypeName = EnumHelper.GetNameById<TransactionType>(obj.Type);
            }
            result.IsSuccess(new PagedList<TransactionMtnListDto>(count, list3.ToList()));
            return result;
        }

        //#get
        public async Task<ServiceResultT<TransactionModDto>> GetTransaction(Guid Id)
        {
            var result = new ServiceResultT<TransactionModDto>();
            var item = await _transactionRepository.GetAsync(Id);

            var obj = ObjectMapper.Map<Transaction, TransactionModDto>(item);
            result.IsSuccess(obj);
            return result;
        }

        //#add
        public async Task<ServiceResult> AddTransaction(TransactionAddDto input)
        {
            var result = new ServiceResult();
            var sameCodeTrs = _transactionRepository.Where(x => x.Code == input.Code).FirstOrDefault();
            if (sameCodeTrs != null)
            {
                result.IsFailed("Transaction codes can not repeat!");
                return result;
            }

            var parentTrs = await _transactionRepository.GetAsync(input.ParentId);
            if (parentTrs.Type == (int)TransactionType.Action)
            {
                result.IsFailed("Action transaction can not have Child!");
                return result;
            }
            if (parentTrs.Type == (int)TransactionType.Virtual)
            {
                if (input.Type == (int)TransactionType.Action)
                {
                    result.IsFailed("Virtual transaction can not have Action Child!");
                    return result;
                }
            }
            if (parentTrs.Type == (int)TransactionType.View)
            {
                if (input.Type != (int)TransactionType.Action)
                {
                    result.IsFailed("View transaction can not have Child beyond Action!");
                    return result;
                }
            }


            var transaction = new Transaction();
            transaction.ParentId = input.ParentId;
            transaction.Code = input.Code;
            transaction.Type = input.Type;
            transaction.DisplayName = input.DisplayName;
            transaction.Description = input.Description;
            transaction.OrderTag = input.OrderTag;

            transaction.CreatorId = new Guid(CurrentUser.FindClaim("Id").Value);
            transaction.CreationTime = DateTime.Now;
            transaction.LastModifierId = new Guid(CurrentUser.FindClaim("Id").Value);
            transaction.ModificationTime = DateTime.Now;

            await _transactionRepository.InsertAsync(transaction);

            result.IsSuccess(ResponseText.INSERT_SUCCESS);
            return result;
        }



        //#mod
        public async Task<ServiceResult> ModifyTransaction(TransactionModDto input)
        {
            var result = new ServiceResult();
            var transaction = await _transactionRepository.GetAsync(input.Id);
            if (transaction == null)
            {
                result.IsFailed("Transaction does not exsit!");
                return result;
            }

            var parentTrs = await _transactionRepository.GetAsync(input.ParentId);
            if (parentTrs.Type == (int)TransactionType.Action)
            {
                result.IsFailed("Action transaction can not have Child!");
                return result;
            }
            if (parentTrs.Type == (int)TransactionType.Virtual)
            {
                if (input.Type == (int)TransactionType.Action)
                {
                    result.IsFailed("Virtual transaction can not have Action Child!");
                    return result;
                }
            }
            if (parentTrs.Type == (int)TransactionType.View)
            {
                if (input.Type != (int)TransactionType.Action)
                {
                    result.IsFailed("View transaction can not have Child beyond Action!");
                    return result;
                }
            }

            transaction.Code = input.Code;
            transaction.Type = input.Type;
            transaction.DisplayName = input.DisplayName;
            transaction.Description = input.Description;
            transaction.OrderTag = input.OrderTag;

            transaction.LastModifierId = new Guid(CurrentUser.FindClaim("Id").Value);
            transaction.ModificationTime = DateTime.Now;

            await _transactionRepository.UpdateAsync(transaction);

            result.IsSuccess(ResponseText.UPDATE_SUCCESS);
            return result;
        }

        public async Task<ServiceResult> ChangeParent(Guid parentId, String[] transactionIds)
        {
            var result = new ServiceResult();

            var parentTrs = await _transactionRepository.GetAsync(parentId);
            foreach (var trsId in transactionIds)
            {
                var trs = await _transactionRepository.GetAsync(new Guid(trsId));
                if (trs == null)
                {
                    result.IsFailed("Transaction does not exsit!");
                    return result;
                }

                if (parentTrs.Type == (int)TransactionType.Action)
                {
                    result.IsFailed("Action transaction can not have Child!");
                    return result;
                }
                if (parentTrs.Type == (int)TransactionType.Virtual)
                {
                    if (trs.Type == (int)TransactionType.Action)
                    {
                        result.IsFailed("Virtual transaction can not have Action Child!");
                        return result;
                    }
                }
                if (parentTrs.Type == (int)TransactionType.View)
                {
                    if (trs.Type != (int)TransactionType.Action)
                    {
                        result.IsFailed("View transaction can not have Child beyond Action!");
                        return result;
                    }
                }


                trs.ParentId = parentId;
                trs.LastModifierId = new Guid(CurrentUser.FindClaim("Id").Value);
                trs.ModificationTime = DateTime.Now;
            }

            result.IsSuccess(ResponseText.UPDATE_SUCCESS);
            return result;
        }

        //#del
        public async Task<ServiceResult> DeleteTransactions(String[] Ids)
        {
            var result = new ServiceResult();
            if (Ids == null | Ids.Length == 0)
            {
                result.IsFailed("Ids can't be null or empty!");
                return result;
            }

            var items = await _transactionRepository.GetListAsync();
            var objs = items.Where(x => Ids.Contains(x.Id.ToString()));
            await _transactionRepository.BulkRemoveAsync(objs);
            result.IsSuccess(ResponseText.DELETE_SUCCESS);
            return result;
        }



        //#common
        private void GetLeftMenuItems(string parentId, List<TransactionListTreeDto> list, IEnumerable<TransactionListTreeDto> all)
        {
            foreach (var item in all.Where(x => x.ParentId.ToString() == parentId.ToLower()))
            {
                list.Add(item);
                GetLeftMenuItems(item.Id.ToString(), list, all);
            }
        }


    }
}

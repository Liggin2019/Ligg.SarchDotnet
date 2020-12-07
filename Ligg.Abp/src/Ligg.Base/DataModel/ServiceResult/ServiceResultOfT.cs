namespace Ligg.Base.DataModel.ServiceResult
{

    /// 服务层响应实体(泛型)
    public class ServiceResultT<T> : ServiceResult where T : class
    {

        public T Result { get; set; }

        public void IsSuccess(T result = null, string message = "")
        {
            Message = message;
            Code = ServiceResultCode.Succeed;
            Result = result;
        }
    }
}
using System;

namespace EnioWine.Core.ServiceProxy
{
    public interface IServiceInvoker
    {
        R InvokeService<T, R>(Func<T, R> invokeHandler) where T : class;
    }
}

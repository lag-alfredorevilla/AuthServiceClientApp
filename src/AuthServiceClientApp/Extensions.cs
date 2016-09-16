using System;
using System.Threading.Tasks;

namespace AuthService
{
    /// <summary>
    /// 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Gets the task result which is equivalent to calling the Wait() method. In case of AggregateException it gets and throws the inner exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <returns></returns>
        public static T RunAsyncTask<T>(this Task<T> task)
        {
            try
            {
                return task.Result;
            }
            catch (AggregateException ex)
            {
                Exception innerException = ex.InnerExceptions[0];
                if (innerException is AggregateException)
                    innerException = ((AggregateException)innerException).InnerExceptions[0];
                throw innerException;
            }
        }
    }
}
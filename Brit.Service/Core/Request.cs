using System.Collections.Generic;

namespace Brit.Service.Core
{
    public class Request<T>
    {
        //public string Context { get; }

        public List<string> CalcFunctions { get;  set; }

        public bool HasException => !Exception.Equals(string.Empty);

        public string Exception { get; set; }

        public T Results { get; private set; }

        public void SetResult(T results)
        {
            Results = results;
        }

        public Request()
        {
            Exception = string.Empty;
        }

        //public Request(string requestContext):this()
        //{
        //    Context = requestContext;
        //}
    }
}

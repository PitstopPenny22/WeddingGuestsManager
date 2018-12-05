using System;
using System.ServiceModel;

namespace GuestsManagerService
{
    public class WcfClientBase<T> where T : IClientChannel
    {
        protected ChannelFactory<T> WcfChannelFactory { get; set; }

        protected WcfClientBase()
        {
        }

        protected T GetServiceClient()
        {
            return WcfChannelFactory.CreateChannel();
        }

        protected TRes CallServiceClientSafely<TRes>(Func<T, TRes> actionToDo, string errorMessage)
        {
            TRes result;
            T client = GetServiceClient();
            try
            {
                result = actionToDo(client);
                client.Close();
            }
            catch (Exception ex)
            {
                client.Abort();
                // TODO DS log
                throw new ApplicationException(errorMessage, ex);
            }
            return result;
        }
        protected void CallServiceClientSafely(Action<T> actionToDo, string errorMessage)
        {
            T client = GetServiceClient();
            try
            {
                actionToDo(client);
                client.Close();
            }
            catch (Exception ex)
            {
                client.Abort();
                // TODO DS log
                throw new ApplicationException(errorMessage, ex);
            }
        }
    }
}

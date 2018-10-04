using System.ServiceModel;
using System.ServiceModel.Description;

namespace App.Interfaces
{
    public interface ICustomerCreditServiceClient
    {
        int GetCreditLimit(string firstname, string surname, System.DateTime dateOfBirth);
        ChannelFactory<ICustomerCreditService> ChannelFactory { get; }
        ClientCredentials ClientCredentials { get; }
        CommunicationState State { get; }
        IClientChannel InnerChannel { get; }
        ServiceEndpoint Endpoint { get; }
    }
}
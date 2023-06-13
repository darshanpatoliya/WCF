using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFInsertInventoryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFInsertService" in both code and config file together.
    [ServiceContract]
    public interface IWCFInsertService
    {
        [OperationContract]
        int InsertNewSalesman(SalesmanBO salesman);

        [OperationContract]
        int InsertNewOrder(OrderBO order);

        [OperationContract]
        int InsertNewCustomer(CustomerBO customer);
    }
}

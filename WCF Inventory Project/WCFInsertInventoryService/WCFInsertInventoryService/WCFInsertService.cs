using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFInsertInventoryService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFInsertService" in both code and config file together.
    public class WCFInsertService : IWCFInsertService
    {
        public int InsertNewCustomer(CustomerBO customer)
        {
            int result = 0;
            CustomerDA dataAccessOfCustomer = new CustomerDA();
            result = dataAccessOfCustomer.InsertCustomer(customer);

            return result;
        }

        public int InsertNewOrder(OrderBO order)
        {
            int result = 0;
            OrderDA dataAccessOfOrder = new OrderDA();
            result = dataAccessOfOrder.InsertOrder(order);

            return result;
        }

        public int InsertNewSalesman(SalesmanBO salesman)
        {
            int result = 0;
            SalesmanDA dataAccessOfSalesman = new SalesmanDA();
            result = dataAccessOfSalesman.InsertSalesman(salesman);

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Assignment6.Repository;

namespace Assignment6.BLL
{
    public class OrderManager
    {
        private OrderRepository _orderRepository = new OrderRepository();

        public bool Add(string customername, string itemname, double price, double quantity)
        {
            return _orderRepository.Add(customername,itemname, price,quantity);
        }

        public bool Update(string customername, string itemname, double price, double quantity, int id)
        {
            return _orderRepository.Update(customername,itemname, price,quantity, id);
        }

        public bool Delete(int id)
        {
            return _orderRepository.Delete(id);
        }

        public DataTable Display()
        {
            return _orderRepository.Display();
        }

        public DataTable Search(string itemname)
        {
            return _orderRepository.Search(itemname);
        }
    }
}

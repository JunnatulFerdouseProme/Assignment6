using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Assignment6.Repository;

namespace Assignment6.BLL
{
    public class CustomerManager
    {
        private CustomerRepository _customerRepository = new CustomerRepository();

        public bool Add(string name, string contact, string address)
        {
            return _customerRepository.Add(name,contact,address);
        }

        public bool IsNameExist(string name)
        {
            return _customerRepository.IsNameExist(name);
        }
        public bool IsContactExist(string contact)
        {
            return _customerRepository.IsNameExist(contact);
        }

        public bool Update(string name, string contact,string address, int id)
        {
            return _customerRepository.Update(name, contact,address, id);
        }

        public bool Delete(int id)
        {
            return _customerRepository.Delete(id);
        }

        public DataTable Display()
        {
            return _customerRepository.Display();
        }

        public DataTable Search(string name)
        {
            return _customerRepository.Search(name);
        }
    }
}

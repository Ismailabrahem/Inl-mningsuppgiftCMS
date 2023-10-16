using Assignment.Models;

namespace Assignment.Interfaces
{
    public interface ICustomerService                   // denna interface specificerar funktioner som CustomerService kommer behöva senare.
                                                        // Det skapar en tydlig struktur som underlättar för kondningen i Service delen.
    {
        Task CreateCustomerAsync(Customer customer);



        Task DeleteOneCustomerAsync(string email);




        IEnumerable<Customer> GetAllCustomers();





        Customer GetOneCustomer(string email);
    }
}
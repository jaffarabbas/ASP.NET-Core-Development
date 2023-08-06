using DbLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.Repositories
{
    public class CustomerDb
    {
        private readonly DbMvcContext context;

        public CustomerDb(DbMvcContext dbMvcContext)
        {
            context = dbMvcContext;
        }

        public List<Customer> GetAll()
        {
            return context.Customers.Include("CidNavigation").ToList();
        }

        public Customer? GetAllById(int id)
        {
            return context.Customers.FirstOrDefault(m => m.Id == id);
        }
        public List<Country> GetCountries()
        {
            return context.Countries.ToList();
        }

        public bool Remove(int id)
        {
            var user = context.Customers.FirstOrDefault(m =>m.Id == id);
            if (user != null)
            {
                context.Customers.Remove(user);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public int Add(Customer customer)
        {
            try
            {
                //update
                var user = context.Customers.FirstOrDefault(m => m.Id == customer.Id);
                if (user != null)
                {
                    user.Name = customer.Name;
                    user.Email = customer.Email;
                    user.Password = customer.Password;
                    user.Address = customer.Address;
                    user.Cid = customer.Cid;
                    context.SaveChanges();
                    return 2;
                }
                else
                {
                    //add
                    var data = new Customer()
                    {
                        Name = customer.Name,
                        Email = customer.Email,
                        Password = customer.Password,
                        Address = customer.Address,
                        Cid = customer.Cid,
                     };
                    context.Customers.Add(data);
                    context.SaveChanges();
                    return 1;
                }
            }catch (Exception ex)
            {
                return -1;
            }
        }
    }
}

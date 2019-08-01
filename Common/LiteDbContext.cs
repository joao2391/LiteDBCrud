using Exemplo_LiteDB.Models;
using LiteDB;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace Exemplo_LiteDB.Common
{
    public class LiteDbContext
    { 
        private readonly LiteDatabase _context;
        private static LiteCollection<Customer> collection;
        private const string nameOfCollection = "customers";

        public LiteDbContext(IOptions<MyConfig> configs)
        {
            try
            {
                if (_context == null)
                {
                    _context = new LiteDatabase(configs.Value.PathToDB);
                    collection = _context.GetCollection<Customer>(nameOfCollection);
                }
               
                    
            }
            catch (Exception ex)
            {
                throw new Exception("Can find or create LiteDb database.", ex);
            }
        }

        public void Insert(Customer obj)
        {
             collection = _context.GetCollection<Customer>(nameOfCollection);

            collection.Insert(obj);
        }

        public IEnumerable<Customer> GetAll()
        {
            var retorno = collection.FindAll();

            return retorno;
        }

        public void Update(Customer customer)
        {
            collection.Update(customer);
        }

        public void Delete(int id)
        {
            collection.Delete(x => x.Id == id);
        }
    }
}

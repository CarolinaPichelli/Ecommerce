using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Entities.Entities;

namespace ApplicationApp.OpenApp
{
    public class AppProduct : InterfaceProductApp
    {
        public Task AddProduct(Produto produto)
        {
            throw new NotImplementedException();
        }
        public Task UpdateProduct(Produto produto)
        {
            throw new NotImplementedException();
        }

        public Task Add(Produto Objeto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Produto Objeto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> GetEntityById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Produto>> List()
        {
            throw new NotImplementedException();
        }

        public Task Update(Produto Objeto)
        {
            throw new NotImplementedException();
        }

      
    }
}

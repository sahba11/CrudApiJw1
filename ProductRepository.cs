using CrudApiJw.Interface;
using CrudApiJw.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiJw.Repository
{
    public class ProductRepository:IProducts
    {
        readonly DatabaseContext _dbContext = new();

        public ProductRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Product> GetProductDetails()
        {
            try
            {
                return _dbContext.Products.ToList();

            }
            catch
            { 
                throw;
            }
        }

        public Product GetProductDetails(int id)
        {
            try
            {
                Product? product = _dbContext.Products.Find(id);
                if (product != null)
                {
                    return product;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }



        public void UpdateProduct(Product product)
        {
            try
            {
                _dbContext.Entry(product).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Product DeleteProduct(int id)
        {
            try
            {
                Product? product = _dbContext.Products.Find(id);

                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    _dbContext.SaveChanges();
                    return product;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }


        public bool CheckEmployee(int id)
        {
            return _dbContext.Products.Any(e => e.Id == id);
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool CheckProduct(int id)
        {
            throw new NotImplementedException();
        }

        public object Get_dbContext()
        {
            throw new NotImplementedException();
        }
    }
}

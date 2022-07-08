using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (Udemy_DBContext context = new Udemy_DBContext())
            {
                return context.Products.ToList();
            }
        }

        public void Add(Product product)
        {
            using (Udemy_DBContext context = new Udemy_DBContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (Udemy_DBContext context = new Udemy_DBContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (Udemy_DBContext context = new Udemy_DBContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }



    }
}

using DAL;
using DAL.Entities.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Repository
{
    public class GeneralRepository<T> : IRepository<T>, IDisposable where T : BaseEntity
    {
        private static NorthwindContext _northwindDbContext;
        private DbSet<T> _entities;
        public void Insert(T entity, bool isEncrypt = false)
        {
            using (_northwindDbContext = new())
            {
                _entities = _northwindDbContext.Set<T>();
                if (isEncrypt)
                {
                    entity = DetachedAttributeEntityFields(entity, _northwindDbContext);
                }
                entity.UsedTime = DateTime.Now; // CreatedDate                                                

                _entities.Add(entity);
                _northwindDbContext.SaveChanges();
            }
        }

        public void Insert(IEnumerable<T> entities, bool isEncrypt = false)
        {
            throw new NotImplementedException();
        }

        public virtual T DetachedAttributeEntityFields(T entity, NorthwindContext dbContext)
        {
            MetadataTypeAttribute[] metadataTypes = entity.GetType().GetCustomAttributes(true).OfType<MetadataTypeAttribute>().ToArray();
            foreach (MetadataTypeAttribute metadata in metadataTypes)
            {
                System.Reflection.PropertyInfo[] properties = metadata.MetadataClassType.GetProperties();
                //Metadata atanmış entity'nin tüm propertyleri tek tek alınır.
                foreach (System.Reflection.PropertyInfo pi in properties)
                {
                    //Eğer ilgili property ait CryptoData flag'i var ise ilgili deger encrypt edilir.
                    if (Attribute.IsDefined(pi, typeof(DAL.GenericEntityAttribute<AttributeType, int>)))
                    {
                        AttributeType type = ((GenericEntityAttribute<AttributeType, int>)pi.GetCustomAttributes(true)[0]).Key;
                        int prm = ((GenericEntityAttribute<AttributeType, int>)pi.GetCustomAttributes(true)[0]).Parameter;
                        if (type == AttributeType.CryptoData)
                            dbContext.Entry(entity).Property(pi.Name).CurrentValue = $"Encrypted[{prm}]_" + dbContext.Entry(entity).Property(pi.Name).CurrentValue.ToString();
                        //NumberValidateData
                        else if (type == AttributeType.NumberValidateData)
                        {
                            int len = dbContext.Entry(entity).Property(pi.Name).CurrentValue.ToString().Length;
                            if (len < prm)
                            {
                                string addZero = "".PadRight((prm - len), '0');
                                dbContext.Entry(entity).Property(pi.Name).CurrentValue = dbContext.Entry(entity).Property(pi.Name).CurrentValue.ToString() + addZero;
                            }
                        }
                    }
                    //HashData
                    else if (Attribute.IsDefined(pi, typeof(DAL.GenericEntityAttribute<AttributeType, string>)))
                    {
                        AttributeType type = ((GenericEntityAttribute<AttributeType, string>)pi.GetCustomAttributes(true)[0]).Key;
                        if (type == AttributeType.HashData)
                            dbContext.Entry(entity).Property(pi.Name).CurrentValue = $"HashData_" + dbContext.Entry(entity).Property(pi.Name).CurrentValue.ToString();
                    }
                }
            }
            return entity;
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {

            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
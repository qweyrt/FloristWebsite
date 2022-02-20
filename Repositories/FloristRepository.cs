using FloristWebsite.Models;
using FloristWebsite.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloristWebsite.Repositories
{
    public class FloristRepository : IFloristRepository
    {
        CoreDbContext db;
        
        public FloristRepository(CoreDbContext _db)
        {
            db = _db;
        }

        #region Bouquet
        //public async Task<List<Customer>> GetCustomers()
        //{
        //    if (db != null)
        //    {
        //        return await db.Customers.ToListAsync();
        //    }

        //    return null;
        //}

        //public async Task<List<Recipient>> GetRecipients()
        //{
        //    if (db != null)
        //    {
        //        return await db.Recipients.ToListAsync();
        //    }

        //    return null;
        //}

        //public async Task<List<BouquetsMessage>> GetBouquetsMessages()
        //{
        //    if (db != null)
        //    {
        //        return await db.BouquetsMessages.ToListAsync();
        //    }

        //    return null;
        //}

        public async Task<List<BouquetViewModel>> GetBouquets()
        {
            if (db != null)
            {
                return await (from b in db.Bouquets
                              from c in db.Customers
                              from r in db.Recipients
                              from bm in db.BouquetsMessages
                              where b.CustomerId == c.Id
                              where b.RecipientId == r.Id
                              where b.BouquetMessageId == bm.Id
                              select new BouquetViewModel
                              {
                                  Id = b.Id,
                                  Name = b.Name,
                                  Price = b.Price,
                                  CustomerId = b.CustomerId,
                                  CustomerFirstName = b.Customer.FirstName,
                                  CustomerLastName = b.Customer.LastName,
                                  RecipientId = b.RecipientId,
                                  RecipientName = b.Recipient.Name,
                                  BouquetMessageId = b.BouquetMessageId,
                                  BouquetMessageMessage = b.BouquetMessage.Message
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<BouquetViewModel> GetBouquet(int? bouquetId)
        {
            if (db != null)
            {
                return await (from b in db.Bouquets
                              from c in db.Customers
                              from r in db.Recipients
                              from bm in db.BouquetsMessages
                              where b.Id == bouquetId
                              select new BouquetViewModel
                              {
                                  Id = b.Id,
                                  Name = b.Name,
                                  Price = b.Price,
                                  CustomerId = b.CustomerId,
                                  CustomerFirstName = b.Customer.FirstName,
                                  CustomerLastName = b.Customer.LastName,
                                  RecipientId = b.RecipientId,
                                  RecipientName = b.Recipient.Name,
                                  BouquetMessageId = b.BouquetMessageId,
                                  BouquetMessageMessage = b.BouquetMessage.Message
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddBouquet(Bouquets bouquet)
        {
            if (db != null)
            {
                await db.Bouquets.AddAsync(bouquet);
                await db.SaveChangesAsync();

                return bouquet.Id;
            }

            return 0;
        }

        public async Task<int> DeleteBouquet(int? bouquetId)
        {
            int result = 0;

            if (db != null)
            {
                var bouquet = await db.Bouquets.FirstOrDefaultAsync(x => x.Id == bouquetId);

                if (bouquet != null)
                {
                    db.Bouquets.Remove(bouquet);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task UpdateBouquet(Bouquets bouquet)
        {
            if (db != null)
            {
                db.Bouquets.Update(bouquet);

                await db.SaveChangesAsync();
            }
        }
        #endregion

        #region Recipient

        public async Task<List<RecipientViewModel>> GetRecipients()
        {
            if (db != null)
            {
                return await (from r in db.Recipients
                              select new RecipientViewModel
                              {
                                  Id = r.Id,
                                  Name = r.Name,
                                  Address = r.Address,
                                  PhoneNumber = r.PhoneNumber,
                                  Date = r.Date,
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<RecipientViewModel> GetRecipient(int? recipientId)
        {
            if (db != null)
            {
                return await (from r in db.Recipients
                              where r.Id == recipientId
                              select new RecipientViewModel
                              {
                                  Id = r.Id,
                                  Name = r.Name,
                                  Address = r.Address,
                                  PhoneNumber = r.PhoneNumber,
                                  Date = r.Date,
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddRecipient(Recipients recipient)
        {
            if (db != null)
            {
                await db.Recipients.AddAsync(recipient);
                await db.SaveChangesAsync();

                return recipient.Id;
            }

            return 0;
        }

        public async Task<int> DeleteRecipient(int? recipientId)
        {
            int result = 0;

            if (db != null)
            {
                var recipient = await db.Recipients.FirstOrDefaultAsync(x => x.Id == recipientId);

                if (recipient != null)
                {
                    db.Recipients.Remove(recipient);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task UpdateRecipient(Recipients recipient)
        {
            if (db != null)
            {
                db.Recipients.Update(recipient);

                await db.SaveChangesAsync();
            }
        }
        #endregion

        #region Bouquet Message

        public async Task<List<BouquetMessageViewModel>> GetBouquetMessages()
        {
            if (db != null)
            {
                return await (
                              from bm in db.BouquetsMessages
                              select new BouquetMessageViewModel
                              {
                                  Id = bm.Id,
                                  Message = bm.Message                                 
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<BouquetMessageViewModel> GetBouquetMessage(int? bouquetMessageId)
        {
            if (db != null)
            {
                return await (from bm in db.BouquetsMessages
                              where bm.Id == bouquetMessageId
                              select new BouquetMessageViewModel
                              {
                                  Id = bm.Id,
                                  Message = bm.Message,
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddBouquetMessage(BouquetsMessages bouquetMessage)
        {
            if (db != null)
            {
                await db.BouquetsMessages.AddAsync(bouquetMessage);
                await db.SaveChangesAsync();

                return bouquetMessage.Id;
            }

            return 0;
        }

        public async Task<int> DeleteBouquetMessage(int? bouquetMessageId)
        {
            int result = 0;

            if (db != null)
            {
                var bouquetMessage = await db.BouquetsMessages.FirstOrDefaultAsync(x => x.Id == bouquetMessageId);

                if (bouquetMessage != null)
                {
                    db.BouquetsMessages.Remove(bouquetMessage);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task UpdateBouquetMessage(BouquetsMessages bouquetMessage)
        {
            if (db != null)
            {
                db.BouquetsMessages.Update(bouquetMessage);

                await db.SaveChangesAsync();
            }
        }
        #endregion

        #region Customer
        public async Task<List<CustomerViewModel>> GetCustomers()
        {
            if (db != null)
            {
                return await (from r in db.Customers
                              select new CustomerViewModel
                              {
                                  Id = r.Id,
                                  FirstName = r.FirstName,
                                  LastName = r.LastName,
                                  DateOfBirth = r.DateOfBirth,
                                  Gender = r.Gender,
                                  Address = r.Address,
                                  PhoneNumber = r.PhoneNumber
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<CustomerViewModel> GetCustomer(int? customerId)
        {
            if (db != null)
            {
                return await (from r in db.Customers
                              where r.Id == customerId
                              select new CustomerViewModel
                              {
                                  Id = r.Id,
                                  FirstName = r.FirstName,
                                  LastName = r.LastName,
                                  DateOfBirth = r.DateOfBirth,
                                  Gender = r.Gender,
                                  Address = r.Address,
                                  PhoneNumber = r.PhoneNumber
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> AddCustomer(Customers customer)
        {
            if (db != null)
            {
                await db.Customers.AddAsync(customer);
                await db.SaveChangesAsync();

                return customer.Id;
            }

            return 0;
        }

        public async Task<int> DeleteCustomer(int? customerId)
        {
            int result = 0;

            if (db != null)
            {
                var customer = await db.Customers.FirstOrDefaultAsync(x => x.Id == customerId);

                if (customer != null)
                {
                    db.Customers.Remove(customer);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task UpdateCustomer(Customers customer)
        {
            if (db != null)
            {
                db.Customers.Update(customer);

                await db.SaveChangesAsync();
            }
        }
        #endregion
    }
}

using FloristWebsite.Models;
using FloristWebsite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FloristWebsite.Repositories
{
    public interface IFloristRepository
    {
        #region Bouquet
        //Task<List<Customer>> GetCustomers();
        //Task<List<Recipient>> GetRecipients();
        //Task<List<BouquetsMessage>> GetBouquetsMessages();
        Task<List<BouquetViewModel>> GetBouquets();
        Task<BouquetViewModel> GetBouquet(int? bouquetId);
        Task<int> AddBouquet(Bouquets bouquet);
        Task<int> DeleteBouquet(int? bouquetId);
        Task UpdateBouquet(Bouquets bouquet);
        #endregion

        #region Recipient
        Task<List<RecipientViewModel>> GetRecipients();
        Task<RecipientViewModel> GetRecipient(int? recipientId);
        Task<int> AddRecipient(Recipients recipient);
        Task<int> DeleteRecipient(int? recipientId);
        Task UpdateRecipient(Recipients recipient);
        #endregion

        #region Bouquet Message
        Task<List<BouquetMessageViewModel>> GetBouquetMessages();
        Task<BouquetMessageViewModel> GetBouquetMessage(int? bouquetId);
        Task<int> AddBouquetMessage(BouquetsMessages bouquet);
        Task<int> DeleteBouquetMessage(int? bouquetId);
        Task UpdateBouquetMessage(BouquetsMessages bouquet);
        #endregion

        #region Customer
        Task<List<CustomerViewModel>> GetCustomers();
        Task<CustomerViewModel> GetCustomer(int? customerId);
        Task<int> AddCustomer(Customers customer);
        Task<int> DeleteCustomer(int? customerId);
        Task UpdateCustomer(Customers customer);
        #endregion
    }
}

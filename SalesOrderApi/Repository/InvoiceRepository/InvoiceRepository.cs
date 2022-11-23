using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesOrderApi.Models;

namespace SalesOrderApi.Repository{
    public class InvoiceRepository : IInvoiceRepository
    {
        public Task<List<InvoiceDetails>> GetAllInvoiceDetailsByCode(string invoiceCode)
        {
            throw new NotImplementedException();
        }

        public Task<List<InvoiceHeader>> GetAllInvoiceHeader()
        {
            throw new NotImplementedException();
        }

        public Task<InvoiceHeader> GetAllInvoiceHeaderByCode(string invoiceCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseType> Remove(string invoiceCode)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseType> Save(InvoiceEntity invoiceEntity)
        {
            throw new NotImplementedException();
        }
    }
}
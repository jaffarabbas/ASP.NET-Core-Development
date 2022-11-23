using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesOrderApi.Models;

namespace SalesOrderApi.Repository
{
    public interface IInvoiceRepository
    {
        Task<List<InvoiceHeader>> GetAllInvoiceHeader();
        Task<InvoiceHeader> GetAllInvoiceHeaderByCode(string invoiceCode);
        Task<List<InvoiceDetails>> GetAllInvoiceDetailsByCode(string invoiceCode);
        Task<ResponseType> Save(InvoiceEntity invoiceEntity);
        Task<ResponseType> Remove(string invoiceCode);
    }
}
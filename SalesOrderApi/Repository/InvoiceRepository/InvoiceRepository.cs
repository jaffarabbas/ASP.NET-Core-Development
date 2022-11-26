using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SalesOrderApi.Models;

namespace SalesOrderApi.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly Sales_DBContext _dBContext;
        private readonly IMapper mapper;
        public InvoiceRepository(Sales_DBContext context, IMapper mapper)
        {
            this._dBContext = context;
            this.mapper = mapper;
        }
        public async Task<List<InvoiceHeader>> GetAllInvoiceHeader()
        {
            var customerInvoiceHeaderData = await this._dBContext.TblSalesHeaders.ToListAsync();
            if (customerInvoiceHeaderData != null && customerInvoiceHeaderData.Count > 0)
            {
                return this.mapper.Map<List<TblSalesHeader>, List<InvoiceHeader>>(customerInvoiceHeaderData);
            }
            return new List<InvoiceHeader>();
        }

        public async Task<InvoiceHeader> GetAllInvoiceHeaderByCode(string invoiceCode)
        {
            var customerInvoiceHeaderData = await this._dBContext.TblSalesHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceCode);
            if (customerInvoiceHeaderData != null)
            {
                return this.mapper.Map<TblSalesHeader, InvoiceHeader>(customerInvoiceHeaderData);
            }
            return new InvoiceHeader();
        }
        public async Task<List<InvoiceDetails>> GetAllInvoiceDetailsByCode(string invoiceCode)
        {
            var customerInvoiceDetailsData = await this._dBContext.TblSalesProductInfos.Where(item => item.InvoiceNo == invoiceCode).ToListAsync();
            if (customerInvoiceDetailsData != null && customerInvoiceDetailsData.Count > 0)
            {
                return this.mapper.Map<List<TblSalesProductInfo>, List<InvoiceDetails>>(customerInvoiceDetailsData);
            }
            return new List<InvoiceDetails>();
        }


        public async Task<ResponseType> Remove(string invoiceCode)
        {
            return new ResponseType();
        }

        private async Task<string> SaveHeader(InvoiceHeader invoiceHeader){
            string Result = string.Empty;
            return Result;
        }

        private async Task<string> SaveDetails(InvoiceDetails invoiceDetails){
            string Result = string.Empty;
            return Result;
        }
        public async Task<ResponseType> Save(InvoiceEntity invoiceEntity)
        {
            return new ResponseType();
        }
    }
}
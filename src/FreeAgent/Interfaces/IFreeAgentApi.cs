using FreeAgent.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeAgent
{
    [Headers("Accept: application/json", "Accept-Encoding: gzip, deflate", "User-Agent: FreeSharp/1.0.0.0")]
    internal interface IFreeAgentApi
    {
        #region Security / Tokens

        [Post("/token_endpoint")]
        Task<AccessResponse> RefreshAccessToken([Body(BodySerializationMethod.UrlEncoded)] AccessRequest request);

        #endregion

        #region Company

        [Get("/company")]
        Task<CompanyWrapper> GetCompanyDetails([Header("Authorization")] string authorization);

        [Get("/company/tax_timeline")]
        Task<TaxTimelineWrapper> GetTaxTimelines([Header("Authorization")] string authorization);

        #endregion

        #region Bank Accounts

        [Get("/bank_accounts")]
        Task<BankAccountWrapper> BankAccountList([Header("Authorization")] string authorization, string view);

        [Get("/bank_accounts/{id}")]
        Task<BankAccountWrapper> BankAccount([Header("Authorization")] string authorization, int id);

        [Post("/bank_accounts")]
        Task<BankAccountWrapper> CreateBankAccount([Header("Authorization")] string authorization, [Body] BankAccountWrapper account);

        [Put("/bank_accounts/{id}")]
        Task<BankAccountWrapper> UpdateBankAccount([Header("Authorization")] string authorization, int id, [Body] BankAccountWrapper account);

        [Delete("/bank_accounts/{id}")]
        Task DeleteBankAccount([Header("Authorization")] string authorization, int id);

        #endregion

        [Get("/bills")]
        Task<BillWrapper> GetBillList([Header("Authorization")] string authorization, string view = "all");

        [Get("/bills/{id}")]
        Task<BillWrapper> GetBill([Header("Authorization")] string authorization, int id);

        [Get("/invoices")] 
        Task<InvoiceWrapper> GetInvoiceList([Header("Authorization")] string authorization, string view = "recent_open_or_overdue", string sort="created_at", bool nested_invoice_items = true);

        [Get("/invoice/{id}")]
        Task<InvoiceWrapper> GetInvoice([Header("Authorization")] string authorization, int id);

        [Post("/invoices")]
        Task<InvoiceWrapper> PostInvoice([Header("Authorization")] string authorization, Invoice invoice);

        [Put("/invoices/{id}/transitions/{transition}")]
        System.Threading.Tasks.Task PutInvoiceStatus([Header("Authorization")] string authorization, int id, string transition);

        [Get("/projects")]
        Task<ProjectWrapper> GetProjectList([Header("Authorization")] string authorization, string view);

        [Get("/projects/{id}")]
        Task<InvoiceWrapper> GetProject([Header("Authorization")] string authorization, int id);

        #region contacts

        [Get("/contacts")]
        Task<ContactWrapper> GetContactList([Header("Authorization")] string authorization, string view, string sort);

        [Post("/contacts")]
        Task<ContactWrapper> CreateContact([Header("Authorization")] string authorization, [Body] ContactWrapper contact);

        [Get("/contacts/{id}")]
        Task<ContactWrapper> GetContact([Header("Authorization")] string authorization, int id);

        [Delete("/contacts/{id}")]
        Task DeleteContact([Header("Authorization")] string authorization, int id);

        #endregion
    }
}

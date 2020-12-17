﻿using FreeAgent.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FreeAgent
{
    [Headers("Accept: application/json", "Accept-Encoding: gzip, deflate", "User-Agent: FreeAgent.Net/0.2.0.0")]
    internal interface IFreeAgentApi
    {
        #region Security / Tokens

        [Post("/token_endpoint")]
        Task<AccessResponse> RefreshAccessToken([Body(BodySerializationMethod.UrlEncoded)] AccessRequest request);
        
        [Post("/token_endpoint")]
        Task<HttpResponseMessage> RefreshAccessTokenRaw([Body(BodySerializationMethod.UrlEncoded)] AccessRequest request);

        #endregion

        #region accounting
        
        [Get("/accounting/trial_balance/summary")]
        Task<TrialBalanceWrapper> TrialBalanceList([Header("Authorization")] string authorization, DateTime? date);

        [Get("/accounting/trial_balance/summary/opening_balances")]
        Task<TrialBalanceWrapper> OpeningBalanceList([Header("Authorization")] string authorization);

        #endregion accounting 

        #region attachments

        [Get("/attachments/{id}")]
        Task<AttachmentWrapper> GetAttachment([Header("Authorization")] string authorization, int id);

        [Delete("/attachments/{id}")]
        Task DeleteAttachment([Header("Authorization")] string authorization, int id);

        #endregion attachments

        #region company

        [Get("/company")]
        Task<CompanyWrapper> CompanyDetails([Header("Authorization")] string authorization);

        [Get("/company/tax_timeline")]
        Task<TaxTimelineWrapper> TaxTimelines([Header("Authorization")] string authorization);

        #endregion company

        #region bank accounts

        [Get("/bank_accounts")]
        Task<BankAccountWrapper> BankAccountList([Header("Authorization")] string authorization, string view);

        [Get("/bank_accounts/{id}")]
        Task<BankAccountWrapper> GetBankAccount([Header("Authorization")] string authorization, int id);

        [Post("/bank_accounts")]
        Task<BankAccountWrapper> CreateBankAccount([Header("Authorization")] string authorization, [Body] BankAccountWrapper account);

        [Put("/bank_accounts/{id}")]
        Task<BankAccountWrapper> UpdateBankAccount([Header("Authorization")] string authorization, int id, [Body] BankAccountWrapper account);

        [Delete("/bank_accounts/{id}")]
        Task DeleteBankAccount([Header("Authorization")] string authorization, int id);

        #endregion bank accounts

        [Post("/bank_transaction_explanations")]
        Task<BankTransactionExplanationWrapper> CreateBankTransactionExplanation([Header("Authorization")] string authorization, [Body] BankTransactionExplanationWrapper explanation);

        #region bills

        [Get("/bills")]
        Task<BillWrapper> BillList([Header("Authorization")] string authorization, string view, string sort, DateTime? fromDate, DateTime? toDate);

        [Post("/bills")]
        Task<BillWrapper> CreateBill([Header("Authorization")] string authorization, [Body] BillWrapper bill);

        [Put("/bills/{id}")]
        Task UpdateBill([Header("Authorization")] string authorization, int id, [Body] BillWrapper bill);

        [Get("/bills/{id}")]
        Task<BillWrapper> GetBill([Header("Authorization")] string authorization, int id);

        [Delete("/bills/{id}")]
        Task DeleteBill([Header("Authorization")] string authorization, int id);

        #endregion bills

        #region contacts

        [Get("/contacts")]
        Task<ContactWrapper> ContactList([Header("Authorization")] string authorization, string view, string sort);

        [Get("/contacts?page={page}&per_page=100")]
        Task<ContactWrapper> ContactPageList([Header("Authorization")] string authorization, string view, string sort, int page = 1);
        
        [Post("/contacts")]
        Task<ContactWrapper> CreateContact([Header("Authorization")] string authorization, [Body] ContactWrapper contact);

        [Get("/contacts/{id}")]
        Task<ContactWrapper> GetContact([Header("Authorization")] string authorization, int id);
        
        [Put("/contacts/{id}")]
        Task UpdateContact([Header("Authorization")] string authorization, int id, [Body] ContactWrapper contact);

        [Delete("/contacts/{id}")]
        Task DeleteContact([Header("Authorization")] string authorization, int id);

        #endregion contacts 

        #region categories

        [Get("/categories")]
        Task<Categories> CategoryList([Header("Authorization")] string authorization);

        [Get("/categories/{nominalCode}")]
        Task<CategoryWrapper> GetCategory([Header("Authorization")] string authorization, string nominalCode);

        #endregion categories

        #region expenses

        [Get("/expenses")]
        Task<ExpenseWrapper> ExpenseList([Header("Authorization")] string authorization, string view, DateTime? fromDate, DateTime? toDate);

        [Post("/expenses")]
        Task<ExpenseWrapper> CreateExpense([Header("Authorization")] string authorization, [Body] ExpenseWrapper expense);

        [Put("/expenses/{id}")]
        Task UpdateExpense([Header("Authorization")] string authorization, int id, [Body] ExpenseWrapper expense);

        [Get("/expenses/{id}")]
        Task<ExpenseWrapper> GetExpense([Header("Authorization")] string authorization, int id);

        [Delete("/expenses/{id}")]
        Task DeleteExpense([Header("Authorization")] string authorization, int id);

        #endregion expenses

        #region invoices

        [Get("/invoices")] 
        Task<InvoiceWrapper> InvoiceList([Header("Authorization")] string authorization, string view, string sort, bool nested_invoice_items = true);

        [Get("/invoices?contact={contact}")]
        Task<InvoiceWrapper> ListInvoicesForContact([Header("Authorization")] string authorization, Uri contact);

        [Post("/invoices")]
        Task<InvoiceWrapper> CreateInvoice([Header("Authorization")] string authorization, [Body] InvoiceWrapper invoice);

        [Put("/invoices/{id}")]
        Task UpdateInvoice([Header("Authorization")] string authorization, int id, [Body] InvoiceWrapper invoice);

        [Get("/invoices/{id}")]
        Task<InvoiceWrapper> GetInvoice([Header("Authorization")] string authorization, int id);

        [Get("/invoices/{id}/pdf")]
        Task<InvoicePdfWrapper> GetInvoicePdf([Header("Authorization")] string authorization, int id);
        
        [Put("/invoices/{id}/transitions/{transition}")]
        Task ChangeInvoiceStatus([Header("Authorization")] string authorization, int id, string transition);

        [Post("/invoices/{id}/send_email")]
        Task EmailInvoice([Header("Authorization")] string authorization, int id, [Body] InvoiceEmailWrapper invoice);
                

        #endregion

        #region projects

        [Get("/projects")]
        Task<ProjectWrapper> ProjectList([Header("Authorization")] string authorization, string view, string sort, string contact);

        [Post("/projects")]
        Task<ProjectWrapper> CreateProject([Header("Authorization")] string authorization, [Body] ProjectWrapper project);

        [Put("/projects/{id}")]
        Task UpdateProject([Header("Authorization")] string authorization, int id, [Body] ProjectWrapper project);

        [Get("/projects/{id}")]
        Task<ProjectWrapper> GetProject([Header("Authorization")] string authorization, int id);

        [Delete("/projects/{id}")]
        Task DeleteProject([Header("Authorization")] string authorization, int id);

        #endregion

        #region recurring invoices

        [Get("/recurring_invoices")]
        Task<RecurringInvoiceWrapper> RecurringInvoiceList([Header("Authorization")] string authorization, string view, string sort, string contact);

        [Get("/recurring_invoice/{id}")]
        Task<RecurringInvoiceWrapper> GetRecurringInvoice([Header("Authorization")] string authorization, int id);

        #endregion recurring invoices 

        #region notes 

        [Get("/notes")]
        Task<NoteItemWrapper> NoteList([Header("Authorization")] string authorization, string contact, string project);

        [Post("/notes")]
        Task<NoteItemWrapper> CreateNote([Header("Authorization")] string authorization, [Body] NoteItemWrapper note, string contact, string project);

        [Put("/notes/{id}")]
        Task UpdateNote([Header("Authorization")] string authorization, int id, [Body] NoteItemWrapper contact);

        [Get("/notes/{id}")]
        Task<NoteItemWrapper> GetNote([Header("Authorization")] string authorization, int id);

        [Delete("/notes/{id}")]
        Task DeleteNote([Header("Authorization")] string authorization, int id);

        #endregion notes

        #region stockitems

        [Get("/stock_items")]
        Task<StockItemWrapper> StockItemList([Header("Authorization")] string authorization);

        [Get("/stock_items/{id}")]
        Task<StockItemWrapper> GetStockItem([Header("Authorization")] string authorization, int id);

        #endregion stockitems

        #region timeslips 

        [Get("/timeslips")]
        Task<TimeslipWrapper> TimeslipList([Header("Authorization")] string authorization, string user, string task, string project, DateTime? from_date, DateTime? to_date);

        [Post("/timeslips")]
        Task<TimeslipWrapper> CreateTimeslips([Header("Authorization")] string authorization, [Body] TimeslipWrapper timeslip);

        [Put("/timeslips/{id}")]
        Task UpdateTimeslip([Header("Authorization")] string authorization, int id, [Body] TimeslipWrapper contact);

        [Get("/timeslips/{id}")]
        Task<TimeslipWrapper> GetTimeslip([Header("Authorization")] string authorization, int id);

        [Delete("/timeslips/{id}")]
        Task DeleteTimeslip([Header("Authorization")] string authorization, int id);

        #endregion timeslips

        #region users

        [Get("/users")]
        Task<UserWrapper> UserList([Header("Authorization")] string authorization);

        [Post("/users")]
        Task<UserWrapper> CreateUser([Header("Authorization")] string authorization, [Body] UserWrapper user);

        [Put("/users/{id}")]
        Task UpdateUser([Header("Authorization")] string authorization, int id, [Body] UserWrapper user);

        [Put("/users/me")]
        Task UpdateCurrentUser([Header("Authorization")] string authorization, [Body] UserWrapper user);

        [Get("/users/{id}")]
        Task<UserWrapper> GetUser([Header("Authorization")] string authorization, int id);

        [Get("/users/me")]
        Task<UserWrapper> GetCurrentUser([Header("Authorization")] string authorization);

        [Delete("/users/{id}")]
        Task DeleteUser([Header("Authorization")] string authorization, int id);

        #endregion users 

    }
}

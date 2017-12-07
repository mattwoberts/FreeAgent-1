using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeAgent.Helpers;
using NUnit.Framework;
using FreeAgent.Model;

namespace FreeAgent.Tests
{
    public class InvoiceTests : TestFixtureBase
    {
        [Test]
        public async Task GetInvoices()
        {
            var invoices = await this.Client.GetInvoicesAsync();
            var i = 0;
            //var filter = InvoiceViewFilter.RecentOpenOrOverdue();

            //var openInvoices = await this.Client.GetInvoicesAsync(filter);

            //var sortedFilter = InvoiceViewFilter.RecentOpenOrOverdue();

            //var sortedInvoices = await this.Client.GetInvoicesAsync(sortedFilter, InvoiceOrder.CreatedAt); 
        }

        [Test]
        public async Task GetSingleInvoice()
        {
            var invoice = await this.Client.GetInvoiceAsync(12121);
            var i = 0;
        }

        [Test]
        [Ignore("")]
        public async Task CreateInvoice()
        {

            var invoice = new Invoice()
            {


            };

            var result = await this.Client.CreateInvoice(invoice);
        }

        [Test]
        [Ignore("")]
        public async Task MarkInvoiceAsSent()
        {

            var invoice = new Invoice()
            {


            };

            await this.Client.ChangeInvoiceStatus(invoice, MarkInvoiceSetting.Sent);
            await this.Client.ChangeInvoiceStatus(invoice, MarkInvoiceSetting.Cancelled);
            await this.Client.ChangeInvoiceStatus(invoice, MarkInvoiceSetting.Scheduled);
        }


        [Test]
        [Ignore("")]
        public void UpdateInvoice()
        {


        }


        [Test]
        public async Task CanRaiseInvoiceAndBankExplanation()
        {
            // Create a rnadom contact:
            var source = Helper.NewContact();
            var contact = await this.Client.CreateContactAsync(source);
            Assert.NotNull(contact.Url);

            // Create an invoice for this contact
            var items = new List<InvoiceItem>
            {
                new InvoiceItem()
                {
                    ItemType = InvoiceItemType.NoUnit,
                    Price = 100,
                    Description = "Some things",
                    Quantity = 100,
                    SalesTaxRate = 20
                }
            };

            var invoice = new Invoice
            {
                Contact = contact.Url,
                DatedOn = DateTime.Now.AddDays(-1),
                DueOn = DateTime.Now.AddDays(1),
                PaymentTermsInDays = 25,
                InvoiceItems = items,
                Currency = "GBP",
                Comments = "Thanks, all done."
            };

            try
            {
                invoice = await this.Client.CreateInvoice(invoice);

            }
            catch (FreeAgentException e)
            {
                Console.WriteLine(e.InnerException.ToString());
            }
            Assert.NotNull(invoice.Url);

            // Now we need to create an email for the invoice
            var email = new InvoiceEmail
            {
                Email =
                    new InvoiceEmailDetail
                    {
                        Body = "Hello there, here you are.",
                        Subject = "Your invoice",
                        From = "garethterrace@gmail.com",
                        To = "garethterrace@gmail.com",
                    }
            };

            await this.Client.CreateInvoiceEmail(invoice.GetId(), email);

            var bankAccount = await Client.GetBankAccountsAsync();

            // Create a bank account explanation for the new invoice now.
            var explanation = new BankTransactionExplanation
            {
                BankAccount = bankAccount.First().Url,
                DatedOn = DateTime.Now,
                PaidInvoice = invoice.Url,
                GrossValue = invoice.TotalValue,
                ForeignCurrencyValue = 0
            };

            explanation = await this.Client.CreateBankTransactionExplanationAsync(explanation);

            Assert.NotNull(explanation.Url);

            // And for my final trick, I shall now get the PDF of that invoice.
            var pdf = await this.Client.GetInvoicePdfAsync(invoice.GetId());

            Assert.NotNull(pdf?.Content);


        }
    }
}

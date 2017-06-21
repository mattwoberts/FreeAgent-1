using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            await this.Client.ChangeInvoiceStatus(invoice, InvoiceStatus.Sent);
            await this.Client.ChangeInvoiceStatus(invoice, InvoiceStatus.Cancelled);
            await this.Client.ChangeInvoiceStatus(invoice, InvoiceStatus.Scheduled);
        }


        [Test]
        [Ignore("")]
        public void UpdateInvoice()
        {


        }
    }
}

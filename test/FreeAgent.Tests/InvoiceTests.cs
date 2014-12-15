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
        [Ignore]
        public async Task GetInvoices()
        {
            var invoices = await this.Client.GetInvoicesAsync();

            var filter = InvoiceViewFilter.RecentOpenOrOverdue();

            var openInvoices = await this.Client.GetInvoicesAsync(filter);

            var sortedFilter = InvoiceViewFilter
                                    .RecentOpenOrOverdue()
                                    .OrderByCreated();

            var sortedInvoices = await this.Client.GetInvoicesAsync(sortedFilter); 
        }

        [Test]
        [Ignore]
        public void GetSingleInvoice()
        {
            

        }

        [Test]
        [Ignore]
        public async Task CreateInvoice()
        {

            var invoice = new Invoice()
            {


            };

            var result = await this.Client.CreateInvoice(invoice);
        }

        [Test]
        [Ignore]
        public async Task MarkInvoiceAsSent()
        {

            var invoice = new Invoice()
            {


            };

            var result = await this.Client.SendInvoice(invoice);
            var result2 = await this.Client.CancelInvoice(invoice);
            var result3 = await this.Client.ScheduleInvoice(invoice);
        }




        [Test]
        [Ignore]
        public void UpdateInvoice()
        {


        }
    }
}

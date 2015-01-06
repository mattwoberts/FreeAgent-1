using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FreeAgent.Model;

namespace FreeAgent.Tests
{
    public class ProjectTests : TestFixtureBase
    {
        [Test]
        [Ignore]
        public async Task GetProjects()
        {
            var invoices = await this.Client.GetInvoicesAsync();

            var filter = InvoiceViewFilter.RecentOpenOrOverdue();

            var openInvoices = await this.Client.GetInvoicesAsync(filter);

            var sortedFilter = InvoiceViewFilter
                                    .RecentOpenOrOverdue();

            var sortedInvoices = await this.Client.GetInvoicesAsync(sortedFilter); 
        }

        [Test]
        [Ignore]
        public void GetSingleProject()
        {
            

        }

        [Test]
        [Ignore]
        public async Task CreateProject()
        {

            var invoice = new Invoice()
            {


            };

            var result = await this.Client.CreateInvoice(invoice);
        }

        //[Test]
        //[Ignore]
        //public async Task MarkInvoiceAsSent()
        //{

        //    var invoice = new Invoice()
        //    {


        //    };
        //}




        [Test]
        [Ignore]
        public void UpdateInvoice()
        {


        }
    }
}

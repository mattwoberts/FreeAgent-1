using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FreeAgent.Model;

namespace FreeAgent.Tests
{
    public class RecurringInvoiceTests : TestFixtureBase
    {
        [Test]
        public async Task RecurringInvoices_Get_Should_Return_Soemthing()
        {
            var invoices = await this.Client.GetRecurringInvoicesAsync();
            var i = 0;
        }
    }
}

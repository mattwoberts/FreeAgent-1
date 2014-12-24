using System;
using System.Collections.Generic;

namespace FreeAgent.Model
{
	public class InvoiceEmailDetail
	{
		public string To { get; set; }
		public string From { get; set; }
		public string Subject { get; set; }
		public string Body { get; set; }
	}

    //TODO - really?  need these??
    public class InvoiceEmailWrapper
    {
        public InvoiceEmail Invoice { get; set; }
    }

    public class InvoiceEmail
    {
        public InvoiceEmailDetail Email { get; set; }
    }

}







namespace PuroReportingEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    public partial class PurolatorReportingEntities : DbContext
    {
        public PurolatorReportingEntities(string connString) : base(connString)
        {
        }
    }
}

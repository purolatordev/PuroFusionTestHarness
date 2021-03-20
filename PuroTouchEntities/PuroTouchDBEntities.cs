

namespace PuroTouchEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    public partial class PuroTouchDBEntities : DbContext
    {
        public PuroTouchDBEntities(string connString) : base(connString)
        {
        }
    }
}

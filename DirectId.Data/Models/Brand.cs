using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DirectId.Data.Models
{
    public class Brand
    {
        public string BrandName { get; set; }

        public string DataSourceName { get; set; }

        public string DataSourceType { get; set; }

        public DateTime RequestDateTime { get; set; }

        public IList<Account> Accounts { get; set; }
    }
}

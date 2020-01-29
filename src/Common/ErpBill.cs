using System;
using System.Collections.Generic;

namespace Common
{
    public class ErpBill
    {
        public AccessControlUser User { get; set; }
        public float Total { get; set; }

        public List<Guid> Products { get; set; }
    }
}

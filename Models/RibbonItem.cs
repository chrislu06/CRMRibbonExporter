using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Crm.Sdk.RibbonExporter.Model
{
    public class RibbonItem
    {
        public string EntityName { get; set; }
        public bool IsSystemEntity { get; set; }
    }
}

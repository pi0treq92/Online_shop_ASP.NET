using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace twoja_manufaktura.ViewModels
{
    public class KoszykRemoveViewModel
    {
        public decimal KoszykTotalPrice{ get; set; }
        public int KoszykItemsCount { get; set; }
        public int RemovedItemCount { get; set; }
        public int RemovedItemId { get; set; }
    }
}
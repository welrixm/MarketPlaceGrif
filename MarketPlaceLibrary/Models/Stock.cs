//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarketPlaceLibrary.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public int Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> CountOfProducts { get; set; }
        public Nullable<System.DateTime> DateOfReceipt { get; set; }
        public Nullable<decimal> PriceOfPurchase { get; set; }
        public Nullable<decimal> CostForOne { get; set; }
    
        public virtual Product Product { get; set; }
    }
}

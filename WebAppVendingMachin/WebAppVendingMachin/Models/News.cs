//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAppVendingMachin.Models
{
    using System;
	using Newtonsoft.Json;
	using WebAppVendingMachin.Services;
    using System.Collections.Generic;
    
    public partial class News
    {
        public int Id { get; set; }
        public string ContentNews { get; set; }
        public System.DateTime Date { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace The_bank_system
{
    using System;
    using System.Collections.Generic;
    
    public partial class Credits
    {
        public int id_credit { get; set; }
        public int id_client { get; set; }
        public decimal sum_credit { get; set; }
        public int duration_credit { get; set; }
        public decimal procent_credit { get; set; }
        public int id_user { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Users Users { get; set; }
    }
}

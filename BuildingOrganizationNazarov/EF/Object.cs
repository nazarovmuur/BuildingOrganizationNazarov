//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BuildingOrganizationNazarov.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Object
    {
        public int ID { get; set; }
        public string NameObject { get; set; }
        public System.DateTime DateStart { get; set; }
        public Nullable<System.DateTime> DateEnd { get; set; }
        public int IDCity { get; set; }
        public string Street { get; set; }
        public int IDDeal { get; set; }
    
        public virtual City City { get; set; }
        public virtual Deal Deal { get; set; }
        public virtual Deal Deal1 { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ideas_Factory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class idea
    {
        public int idea_id { get; set; }
        public string idea_title { get; set; }
        public string idea_description { get; set; }
        public System.DateTime idea_creation_time { get; set; }
        public int userid { get; set; }
    
        public virtual loginuser loginuser { get; set; }
    }
}

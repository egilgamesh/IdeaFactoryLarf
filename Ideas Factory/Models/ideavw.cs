using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ideas_Factory.Models
{
    using System;
    using System.Collections.Generic;
    public partial class ideavw
    {
        public int idea_id { get; set; }
        public string idea_title { get; set; }
        public string idea_description { get; set; }
        public System.DateTime idea_creation_time { get; set; }
        public int userid { get; set; }
        public string username { get; set; }

    }
}
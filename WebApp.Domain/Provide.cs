using System.Collections.Generic;

namespace WebApp.Domain
{
    public class Provide : BaseEntity
    {        
        //- Name(nvarchar(max)) *используется для фильтрации        
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

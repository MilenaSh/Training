using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlurarsiteDemoCore2.Models
{
    public  interface IIceCreamRepository
    {
        IEnumerable<IceCream> GetAllIceCream();
        IceCream GetById(int iceCreamId);
    }
}

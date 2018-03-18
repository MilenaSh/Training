using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlurarsiteDemoCore2.Models
{
    public class MockIcereamRepository : IIceCreamRepository
    {

        public List<IceCream> _iceCream;

        public MockIcereamRepository()
        {
            if (_iceCream == null)
            {
                InitializeIceCream();
            }
        }

        public void InitializeIceCream()
        {
            _iceCream = new List<IceCream>
            {
            new IceCream {Id = 1, Name = "Vanilla Icecream",  Description = "Our famous apple pies!"},
            new IceCream {Id = 2, Name = "Blueberry Ice cream", Description = "You'll love it!"},
            new IceCream {Id = 3, Name = "Cheese Ice cream", Description = "Plain cheese cake. Plain pleasurheesecakesmall.jpg"},
            new IceCream {Id = 4, Name = "Cherry Ice cream", Description = "A summer classic!"}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  
            };
        }

        public IEnumerable<IceCream> GetAllIceCream()
        {
            return _iceCream;
        }

        public IceCream GetById(int iceCreamId)
        {
            return _iceCream.FirstOrDefault(i => i.Id == iceCreamId);
        }
    }
}

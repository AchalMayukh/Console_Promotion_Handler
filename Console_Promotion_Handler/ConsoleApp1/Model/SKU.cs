using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Model
{
    static class SKU
    {
        public static char[] IDs = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => ((char)i)).ToArray();
    }
}

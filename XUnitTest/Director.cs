using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest
{
    public class Director
    {
        public void MakeProductToSave(IBuilder builder)
        {
            builder.SetRepository();
            builder.SetApiService();
        }
    }
}

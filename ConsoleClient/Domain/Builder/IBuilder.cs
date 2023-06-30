using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest
{
    public interface IBuilder
    {
        void Reset();
        void SetRepository();
        void SetDateTimeProvider();
        void SetApiService();
    }
}

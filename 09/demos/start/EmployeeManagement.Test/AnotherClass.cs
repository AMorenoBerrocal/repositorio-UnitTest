using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeManagement.Test
{
    [Collection("No parallelism")]
    public class AnotherClass
    {
        [Fact]
        public void SlowTest2()
        {
            Thread.Sleep(5000);
            Assert.True(true);
        }
    }
}

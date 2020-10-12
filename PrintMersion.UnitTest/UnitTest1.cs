using System;
using Xunit;
using System.Reflection;
using PrintMersion.Infrastructure.Data;
namespace PrintMersion.UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

          var res = new  testClass<testPro>();

            res.GetType().GetProperty("propiedades").GetValue(res).
        }
    }

    public class testClass<t>where t : new()
    {
        t propiedad { get; set; }

      public  testClass()
        {
            propiedad = new t();
           
        }
    }

    public class testPro
    {
      
        PrintMersionDBContext Db { get; set; }

        public testPro()
        {
            Db = new PrintMersionDBContext();
        }
        
    }


}

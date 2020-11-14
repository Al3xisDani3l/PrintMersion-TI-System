using Microsoft.EntityFrameworkCore;
using PrintMersion.Infrastructure.Data;
using Xunit;
namespace PrintMersion.UnitTest
{
    public class DatabaseUnitTest
    {
        [Fact]
        public void Testconexion()
        {

          var  _dboption = new DbContextOptions<PrintMersionDBContext>();

            var _db = new PrintMersion.Infrastructure.Data.PrintMersionDBContext();
          
            
        }



    }

    
    


}

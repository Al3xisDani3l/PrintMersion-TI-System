using PrintMersion.Core.Entities;
using PrintMersion.Core.Enumerations;

namespace PrintMersion.Infrastructure.Validations
{
    public class NullValidation : BaseValidation<Administer>
    {
        public NullValidation()
        {
            Operation = Operation.All;
            Description = $"La identidad es Null";
            Validation = (o) => o != null;
        }


    }
}

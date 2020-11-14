using PrintMersion.Core.Entities;
using PrintMersion.Core.Enumerations;

namespace PrintMersion.Core.Validations
{
    public class NullValidation : BaseValidation<User>
    {
        public NullValidation()
        {
            Operation = Operation.All;
            Description = $"La identidad es Null";
            Validation = (o) => o != null;
        }


    }
}

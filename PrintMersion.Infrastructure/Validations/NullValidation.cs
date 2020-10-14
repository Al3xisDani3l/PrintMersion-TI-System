using System;
using System.Collections.Generic;
using System.Text;
using PrintMersion.Core.Interfaces;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Enumerations;

namespace PrintMersion.Infrastructure.Validations
{
    public class NullValidation : IValidator<Administer>
    {
        public NullValidation()
        {
            Operation = Operation.All;
            Description = $"La identidad es Null";
            Validation = (o) => o != null;
        }

        public Operation Operation { get; set; }
        public Func<Administer, bool> Validation { get; set; }
        public string Description { get; set; }
        public bool IsValid { get; set; }
    }
}

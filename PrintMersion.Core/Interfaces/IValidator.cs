using System;
using System.Collections.Generic;
using System.Text;
using PrintMersion.Core.Enumerations;
namespace PrintMersion.Core.Interfaces
{
    public interface IValidator<TEntity>
    {
        Operation Operation { get; set; }

        Func<TEntity, bool> Validation { get; set; }

        string Description { get; set; }

        bool IsValid { get; set; } 

    }
}

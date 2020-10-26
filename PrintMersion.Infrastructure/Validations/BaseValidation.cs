using Newtonsoft.Json;
using PrintMersion.Core.Enumerations;
using PrintMersion.Core.Interfaces;
using System;

namespace PrintMersion.Infrastructure.Validations
{
    public abstract class BaseValidation<TEntity> : IValidator<TEntity>
    {

        public Operation Operation { get; set; }
        [JsonIgnore]
        public Func<TEntity, bool> Validation { get; set; }
        public string Description { get; set; }
        public bool IsValid { get; set; }
    }
}

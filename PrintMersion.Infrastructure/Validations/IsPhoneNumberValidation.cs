using libphonenumber;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Enumerations;


namespace PrintMersion.Infrastructure.Validations
{
    public class IsPhoneNumberValidation : BaseValidation<Administer>
    {
        public IsPhoneNumberValidation()
        {
            Operation = Operation.Post;
            Description = "El numero debe estar compuesto de 10 digitos numericos";
            Validation = o => Validar(o.Phone);

        }




        public static bool Validar(string strNumber)
        {
            var rs = PhoneNumberUtil.Instance.IsPossibleNumber(strNumber, "MX") ||
                     PhoneNumberUtil.Instance.IsPossibleNumber(strNumber, "EU");
            return rs;

        }
    }
}

using System.ComponentModel.DataAnnotations;

namespace LabWork5
{
    class IndexAttribite : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!int.TryParse(value.ToString(), out int result))
            {
                return false;
            }

            if (result > 99999)
            {
                return true;
            }
            else
            {
                this.ErrorMessage = "Ошибка";
                return false;
            }
        }
    }
}

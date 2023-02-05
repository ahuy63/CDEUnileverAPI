using System.ComponentModel.DataAnnotations;

namespace CDEUnileverAPI.Models
{
    public class ValidateYearsAttribute : ValidationAttribute
    {
        private readonly DateTime _minValue = DateTime.UtcNow;
        //private readonly DateTime _maxValue = DateTime.UtcNow;

        public override bool IsValid(object value)
        {
            List<DateTime> values = (List<DateTime>)value;
            foreach (var item in values)
            {
                DateTime val = item;
                if (val < _minValue)
                {
                    return false;
                }
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("Date should be larger than now", _minValue);
        }
    }

    public class ValidateTimeAttribute : ValidationAttribute
    {
        private readonly DateTime _minValue = DateTime.UtcNow;

        public override bool IsValid(object value)
        {
            if (value == "AM")
            {

            }
            DateTime val = (DateTime)value;
            return val >= _minValue;
        }
    }
}

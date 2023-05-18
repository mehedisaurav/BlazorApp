using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSaleOrderApp.Shared.Dto.Common
{
    [TypeConverter(typeof(SelectModelTypeConverter))]
    public class SelectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SelectModelTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string stringValue)
            {
                // Implement logic to convert the string value to the SelectModel type
                // For example:
                var selectModel = new SelectModel { Name = stringValue };

                return selectModel;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorSaleOrderApp.Shared.Dto.Common
{
   
        public class SelectModelListTypeConverter : TypeConverter
        {
            public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
            {
                return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
            }

            public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
            {
                if (value is string stringValue)
                {
                    // Implement logic to convert the string value to List<SelectModel>
                    // For example, assuming the string is comma-separated values:
                    var selectModelList = new List<SelectModel>();
                    var values = stringValue.Split(',');
                    foreach (var item in values)
                    {
                        selectModelList.Add(new SelectModel { Name = item.Trim() });
                    }

                    return selectModelList;
                }

                return base.ConvertFrom(context, culture, value);
            }
        }
    
}

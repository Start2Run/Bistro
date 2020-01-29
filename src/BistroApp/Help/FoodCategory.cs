using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using SystemePAC.Help.Language;
using SystemePAC.Properties;
using Microsoft.EntityFrameworkCore;

namespace SystemePAC.Help
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum FoodCategory
    {
        [LocalizedDescription("Cooked", typeof(Resources))]
        Cooked,
        [LocalizedDescription("Beverage", typeof(Resources))]
        Beverage,
        [LocalizedDescription("Wrap", typeof(Resources))]
        Wrap,
        [LocalizedDescription("Snack", typeof(Resources))]
        Snack,
        [LocalizedDescription("Soup", typeof(Resources))]
        Soup,
    }

    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        readonly System.Resources.ResourceManager m_resourceManager;
        readonly string m_resourceKey;
        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            m_resourceManager = new ResourceManager("SystemePAC.Properties.Strings.Resources", Assembly.GetExecutingAssembly());
        m_resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                string description =TranslationSource.Instance[m_resourceKey];
                return string.IsNullOrWhiteSpace(description) ? $"[[{m_resourceKey}]]" : description;
            }
        }
    }
    public class EnumDescriptionTypeConverter : EnumConverter
    {
        public EnumDescriptionTypeConverter(Type type)
            : base(type)
        {
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value != null)
                {
                    FieldInfo fi = value.GetType().GetField(value.ToString());
                    if (fi != null)
                    {
                        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        return ((attributes.Length > 0) && (!String.IsNullOrEmpty(attributes[0].Description))) ? attributes[0].Description : value.ToString();
                    }
                }

                return string.Empty;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}

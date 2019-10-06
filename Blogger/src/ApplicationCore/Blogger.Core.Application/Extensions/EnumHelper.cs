using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Blogger.Core.Application.Extensions
{
    public static class EnumHelper<T> where T : IConvertible
    {
        public static string GetDisplayValue(T value)
        {
            return GetDisplayValue(value, nameof(DisplayAttribute.Name));
        }

        private static string GetDisplayValue(T value, string propertyName = nameof(DisplayAttribute.Name))
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo == null || string.IsNullOrEmpty(propertyName))
            {
                return string.Empty;
            }

            var displayValue = value.ToString();

            var descriptionAttributes = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null || !descriptionAttributes.Any())
            {
                return displayValue;
            }

            var resourceType = descriptionAttributes[0].ResourceType;

            var propertyValue = string.Empty;

            switch (propertyName)
            {
                case nameof(DisplayAttribute.Description):
                    propertyValue = descriptionAttributes[0].Description;
                    break;
                case nameof(DisplayAttribute.Name):
                    propertyValue = descriptionAttributes[0].Name;
                    break;
                case nameof(DisplayAttribute.ShortName):
                    propertyValue = descriptionAttributes[0].ShortName;
                    break;
                case nameof(DisplayAttribute.GroupName):
                    propertyValue = descriptionAttributes[0].GroupName;
                    break;
                default:
                    propertyValue = string.Empty;
                    break;
            }

            return displayValue;
        }

        public static T ParseEnum(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}

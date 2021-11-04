using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework7.MyEditorForModel
{
    public static class HtmlExtension
    {
        public static IHtmlContent EditModel(PropertyInfo propertyInfo, object model)
        {
            var divBlock = new TagBuilder("div") { Attributes = { { "class", "form-row" } } };
            divBlock.InnerHtml.AppendHtml(AggregateLabel(propertyInfo));
            divBlock.InnerHtml.AppendHtml(AggregateSpan(propertyInfo, model));
            divBlock.InnerHtml.AppendHtml(AggregateMessageBlock(propertyInfo, model));
            return divBlock;
        }

        private static IHtmlContent AggregateLabel(MemberInfo propertyInfo)
        {
            var labelBlock = new TagBuilder("label")
            {
                Attributes =
                {
                    { "class", "col-sm-2 col-form-label col-form-label-lg" }
                }
            };
            labelBlock.InnerHtml.AppendHtmlLine(DisplayName(propertyInfo));
            return labelBlock;
        }

        private static IHtmlContent AggregateSpan(PropertyInfo propertyInfo, object model)
        {
            var divBlock = new TagBuilder("div") { Attributes = { { "class", "col-md-4 mb-3" } } };
            divBlock.InnerHtml.AppendHtml(propertyInfo.PropertyType.IsEnum
                ? AggregateDropdown(propertyInfo, model)
                : AggregateInput(propertyInfo, model));
            return divBlock;
        }

        private static IHtmlContent AggregateInput(PropertyInfo propertyInfo, object model) => new TagBuilder("input")
        {
            Attributes =
            {
                { "class", "form-control form-control-lg" },
                { "id", propertyInfo.Name },
                { "name", propertyInfo.Name },
                { "type", propertyInfo.PropertyType == typeof(int) ? "number" : "text" },
                { "value", propertyInfo.GetValue(model)?.ToString() ?? string.Empty }
            }
        };

        private static IHtmlContent AggregateDropdown(PropertyInfo propertyInfo, object model)
        {
            var dropdownBlock = new TagBuilder("select")
            {
                Attributes =
                {
                    { "class", "form-control form-control-lg" },
                    { "name", propertyInfo.Name },
                    { "id", propertyInfo.Name }
                }
            };
            var modelValue = model != null ? propertyInfo.GetValue(model) : 0;
            var members = propertyInfo.PropertyType.GetFields(BindingFlags.Public | BindingFlags.Static);
            foreach (var member in members)
            {
                dropdownBlock.InnerHtml.AppendHtml(GetOption(member, modelValue));
            }

            return dropdownBlock;
        }

        private static IHtmlContent GetOption(FieldInfo fieldInfo, object modelValue)
        {
            var option = new TagBuilder("option") { Attributes = { { "value", fieldInfo.Name } } };
            if (fieldInfo.GetValue(fieldInfo.DeclaringType)?.Equals(modelValue) ?? false)
            {
                option.MergeAttribute("selected", "true");
            }

            option.InnerHtml.AppendHtmlLine(DisplayName(fieldInfo));
            return option;
        }

        private static IHtmlContent AggregateMessageBlock(PropertyInfo propertyInfo, object model)
        {
            var span = new TagBuilder("span") { Attributes = { { "class", "text-danger col-sm-4 col-form-label" } } };
            if (model == null) return span;
            var result = new List<ValidationResult>();
            var context = new ValidationContext(model)
            {
                MemberName = propertyInfo.Name, DisplayName = DisplayName(propertyInfo)
            };
            if (!Validator.TryValidateProperty(propertyInfo.GetValue(model), context, result))
            {
                span.InnerHtml.AppendHtmlLine(result[0].ErrorMessage!);
            }

            return span;
        }

        private static string DisplayName(MemberInfo propertyInfo)
        {
            var display = propertyInfo.GetCustomAttribute<DisplayAttribute>();
            return display == null ? propertyInfo.Name.SplitCamelCase() : display.Name;
        }

        private static string SplitCamelCase(this string str)
        {
            return Regex.Replace(str, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }
    }
}
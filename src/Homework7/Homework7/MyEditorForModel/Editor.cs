using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Homework7.MyEditorForModel
{
    public static class Editor
    {
        public static IHtmlContent MyEditorForModel(this IHtmlHelper helper)
        {
            IHtmlContentBuilder result = new HtmlContentBuilder();
            var htmlContents = helper
                .ViewData
                .ModelMetadata
                .ModelType
                .GetProperties()
                .Select(p => HtmlExtension.EditModel(p, helper.ViewData.Model));
            return htmlContents.Aggregate(result, (current, content) => current.AppendHtml(content));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TestWebClient.Models
{
	public class PageLinkTagHelper : TagHelper
	{
		private IUrlHelperFactory urlHelperFactory;
		public PageLinkTagHelper(IUrlHelperFactory helperFactory)
		{
			urlHelperFactory = helperFactory;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext ViewContext { get; set; }
		public PageViewModel PageModel { get; set; }
		public string PageAction { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
			output.TagName = "div";

			TagBuilder tag = new TagBuilder("ul");
			tag.AddCssClass("pagination");

			for(int i = 1; i <= PageModel.TotalPages; i++)
			{
				TagBuilder currentItem = CreateTag(i, PageModel.IndexContent, urlHelper);
				tag.InnerHtml.AppendHtml(currentItem);
			}

			output.Content.AppendHtml(tag);
		}

		TagBuilder CreateTag(int pageNumber, int indexContent, IUrlHelper urlHelper)
		{
			TagBuilder item = new TagBuilder("li");
			TagBuilder link = new TagBuilder("a");

			if (pageNumber == this.PageModel.PageNumber)
			{
				item.AddCssClass("active");
			}
			else
			{
				link.Attributes["href"] = urlHelper.Action(PageAction, new { contentId = indexContent,  page = pageNumber });
			}

			link.InnerHtml.Append(pageNumber.ToString());
			item.InnerHtml.AppendHtml(link);
			return item;
		}
	}
}

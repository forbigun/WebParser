using AngleSharp.Html.Dom;
using System.Linq;

namespace Parser.Core.RedSquare
{
	public class RedSquareParser : IParser<string>
	{
		public string Parse(IHtmlDocument document)
		{
			var item = document.QuerySelectorAll(".red-btn-double.button-cart span.sub")
				.LastOrDefault();

			return item?.TextContent;
		}
	}
}
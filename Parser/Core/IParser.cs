using AngleSharp.Html.Dom;

namespace Parser.Core
{
	public interface IParser<T> where T : class
	{
		T Parse(IHtmlDocument document);
	}
}
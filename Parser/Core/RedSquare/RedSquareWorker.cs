using AngleSharp.Html.Parser;
using System.Threading.Tasks;

namespace Parser.Core.RedSquare
{
	public class RedSquareWorker<T> : ParserWorker<T> where T : class
	{
		public RedSquareWorker(IParser<T> parser) : base(parser)
		{
		}

		protected override async Task<T> Work()
		{
			var source = await _loader.GetSource();

			var domParser = new HtmlParser();
			var document = await domParser.ParseDocumentAsync(source);

			var result = _parser.Parse(document);

			return result;
		}
	}
}
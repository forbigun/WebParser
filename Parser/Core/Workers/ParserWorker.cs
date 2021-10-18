using AngleSharp.Html.Parser;
using System.Threading.Tasks;

namespace Parser.Core.Workers
{
	public abstract class ParserWorker<T> where T : class
	{
		protected IParser<T> _parser;
		protected IParserSettings _parserSettings;

		protected HtmlLoader _loader;

		public bool IsActive { get; protected set; }

		public IParser<T> Parser
		{
			get
			{
				return _parser;
			}
			set
			{
				_parser = value;
			}
		}

		public IParserSettings Settings
		{
			get
			{
				return _parserSettings;
			}
			set
			{
				_parserSettings = value;
				_loader = new HtmlLoader(value);
			}
		}

		public ParserWorker(IParser<T> parser)
		{
			_parser = parser;
		}

		public async Task<T> Start()
		{
			IsActive = true;
			return await Work();
		}

		public void Abort()
		{
			IsActive = false;
		}

		protected async Task<T> GetHtmlDocument(string source)
		{
			var domParser = new HtmlParser();
			var document = await domParser.ParseDocumentAsync(source);

			return _parser.Parse(document);
		}

		protected abstract Task<T> Work();
	}
}
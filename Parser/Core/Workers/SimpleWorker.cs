using System.Threading.Tasks;

namespace Parser.Core.Workers
{
	public class SimpleWorker<T> : ParserWorker<T> where T : class
	{
		public SimpleWorker(IParser<T> parser) : base(parser)
		{
		}

		protected override async Task<T> Work()
		{
			var source = await _loader.GetSource();

			var result = await GetHtmlDocument(source);

			return result;
		}
	}
}
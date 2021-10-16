using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Parser.Core
{
	public class HtmlLoader
	{
		private readonly HttpClient _client;
		private readonly string _url;

		public HtmlLoader(IParserSettings settings)
		{
			_client = new HttpClient();
			_url = $"{settings.BaseUrl}/{settings.Prefix}/";
		}

		public async Task<string> GetSourceByPageId(int id)
		{
			var currentUrl = _url.Replace("{CurrentId}", id.ToString());
			var response = await _client.GetAsync(currentUrl);
			string source = null;

			if (response != null && response.StatusCode == HttpStatusCode.OK)
			{
				source = await response.Content.ReadAsStringAsync();
			}
			return source;
		}

		public async Task<string> GetSource()
		{
			var response = await _client.GetAsync(_url);
			string source = null;

			if (response != null && response.StatusCode == HttpStatusCode.OK)
			{
				source = await response.Content.ReadAsStringAsync();
			}

			return source;
		}
	}
}
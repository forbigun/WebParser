namespace Parser.Core.RedSquare
{
	public class RedSquareSettings : IParserSettings
	{
		public string BaseUrl { get; set; } = "http://red-square.org/";
		public string Prefix { get; set; } = "keyrox-tkl-classic.html";
	}
}
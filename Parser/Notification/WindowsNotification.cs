using Microsoft.Toolkit.Uwp.Notifications;
using System;

namespace Parser.Notification
{
	public class WindowsNotification : INotification
	{
		private readonly ToastContentBuilder _builder;

		public WindowsNotification()
		{
			_builder = new ToastContentBuilder();
		}

		public ToastContentBuilder AddImage(Uri uri) => _builder.AddInlineImage(uri);

		public ToastContentBuilder AddAppLogo(Uri uri) => _builder.AddAppLogoOverride(uri);

		public void ShowInfo(string message) => _builder.AddText(message).Show();
	}
}
using NS.STMS.Resources.Language.Languages;
using NS.STMS.Settings;
using System;

namespace NS.STMS.Business.Templates
{
	internal class EmailTemplate
	{

		private static string GetEmailStyle()
		{
			return @$"
    <style>
        
        body, p, h1 {{
            margin: 0;
            padding: 0;
        }}
        body {{
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
        }}

        h1 {{
            font-size: 24px;
            color: #333;
            margin-bottom: 20px;
        }}
        p {{
            font-size: 16px;
            color: #555;
            line-height: 1.5;
        }}
        .container {{
            max-width: 600px;
            margin: 0 auto;
			margin-top: 50px;
            padding: 20px;
            background-color: #ffffff;
            border-radius: 5px;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }}
    </style>";
		}

		private static string GetEmailHead()
		{
			return $@"
<head>
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    {GetEmailStyle()}
</head>";
		}

		private static string GetEmailHTML(string containerHTML)
		{
			return @$"
<!DOCTYPE html>
<html>

{GetEmailHead()}

<body>
    <div class=""container"">
        {containerHTML}
    </div>
</body>
</html>";
		}

		internal static string GetForgotPasswordEmailHTML(Guid guid)
		{
			string containerHTML = @$"
<h1>{Messages.Forgot_Password_Link}</h1>
<p>{Messages.Click_To_Reset_Password} <a href=""{AppSettings.ClientUrl}/Account/ForgotPassword?token={guid}"">{Messages.Reset_Password}</a></p>";

			return GetEmailHTML(containerHTML);
		}

	}
}

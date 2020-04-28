using System;

namespace Utility
{
    public class HeaderAnalyzer
    {
        public static string GetUserPlatform(string userAgent)
        {
            if (userAgent.Contains("Android"))
            {
                return string.Format("Android {0}", GetMobileVersion(userAgent, "Android"));
            }

            if (userAgent.Contains("iPad"))
            {
                return string.Format("iPad OS {0}", GetMobileVersion(userAgent, "OS"));
            }

            if (userAgent.Contains("iPhone"))
            {
                return string.Format("iPhone OS {0}", GetMobileVersion(userAgent, "OS"));
            }

            if (userAgent.Contains("Linux") && userAgent.Contains("KFAPWI"))
            {
                return "Kindle Fire";
            }

            if (userAgent.Contains("RIM Tablet") || (userAgent.Contains("BB") && userAgent.Contains("Mobile")))
            {
                return "Black Berry";
            }

            if (userAgent.Contains("Windows Phone"))
            {
                return string.Format("Windows Phone {0}", GetMobileVersion(userAgent, "Windows Phone"));
            }

            if (userAgent.Contains("Mac OS"))
            {
                return "Mac OS";
            }

            if (userAgent.Contains("Windows NT 5.1") || userAgent.Contains("Windows NT 5.2"))
            {
                return "Windows XP";
            }

            if (userAgent.Contains("Windows NT 6.0"))
            {
                return "Windows Vista";
            }

            if (userAgent.Contains("Windows NT 6.1"))
            {
                return "Windows 7";
            }

            if (userAgent.Contains("Windows NT 6.2"))
            {
                return "Windows 8";
            }

            if (userAgent.Contains("Windows NT 6.3"))
            {
                return "Windows 8.1";
            }

            if (userAgent.Contains("Windows NT 10"))
            {
                return "Windows 10";
            }

            //fallback to basic platform:
            return userAgent + (userAgent.Contains("Mobile") ? " Mobile " : "");
        }

        public static string GetDeviceName(string userAgent)
        {
            if (userAgent.Contains("Linux") || userAgent.Contains("Windows NT") ||
                userAgent.Contains("Mac OS"))
            {
                return "Desktop";
            }

            if (userAgent.ToLower().Contains("tablet") || userAgent.Contains("RIM Tablet"))
            {
                return "Tablet";
            }

            if (userAgent.Contains("Mobile") || userAgent.Contains("iPhone") ||
                userAgent.Contains("iPad") || userAgent.Contains("Android"))
            {
                return "Mobile";
            }
            return "Not Recognize";
        }

        public static string GetBrowserName(string userAgent)
        {
            if (userAgent.ToLower().Contains("firefox"))
            {
                return "FireFox";
            }

            if (userAgent.ToLower().Contains("chrome"))
            {
                return "Google Chrome";
            }

            if (userAgent.ToLower().Contains("ie"))
            {
                return "Internet Explorer";
            }

            if (userAgent.ToLower().Contains("opera"))
            {
                return "Opera";
            }

            return "Not Recognize";
        }

        private static string GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device, StringComparison.Ordinal) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;

                if (int.TryParse(character.ToString(), out var test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                {
                    break;
                }
            }

            return version;
        }
    }
}

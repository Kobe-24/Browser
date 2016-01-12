using System.Reflection;
using System.Windows.Controls;

namespace MyBrowser
{
    class HelperFunctions
    {
        public static bool TrySetSuppressScriptErrors(WebBrowser webBrowser, bool value)
        {
            FieldInfo field = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);
            if (field != null)
            {
                object axIWebBrowser2 = field.GetValue(webBrowser);
                if (axIWebBrowser2 != null)
                {
                    axIWebBrowser2.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, axIWebBrowser2, new object[] { value });
                    return true;
                }
            }

            return false;
        }

        public static string AddAddressPrefix(string address)
        {
            if (!address.StartsWith("http"))
            {
                address = "http://" + address;
            }
            return address;
        }
    }
}

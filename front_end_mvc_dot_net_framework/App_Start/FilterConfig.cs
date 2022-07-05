using System.Web;
using System.Web.Mvc;

namespace front_end_mvc_dot_net_framework
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

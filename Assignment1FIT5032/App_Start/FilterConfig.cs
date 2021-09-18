using System.Web;
using System.Web.Mvc;

namespace Assignment1FIT5032
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

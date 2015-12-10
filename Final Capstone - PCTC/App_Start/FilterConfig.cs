using System.Web;
using System.Web.Mvc;

namespace Final_Capstone___PCTC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

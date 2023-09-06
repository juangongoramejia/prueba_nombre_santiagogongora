using System.Web;
using System.Web.Mvc;

namespace prueba_nombre_santiagogongora
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

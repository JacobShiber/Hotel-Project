using System.Web;
using System.Web.Mvc;

namespace Exam_Practicing_Vol1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}

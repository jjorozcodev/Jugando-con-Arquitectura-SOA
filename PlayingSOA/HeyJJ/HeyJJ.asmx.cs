using System.Web.Services;

namespace HeyJJ
{
    /// <summary>
    /// Summary description for HeyJJ
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class HeyJJ : WebService
    {

        [WebMethod]
        public string Greeting()
        {
            return "Hey, I'm JJ! How's it going?";
        }
    }
}

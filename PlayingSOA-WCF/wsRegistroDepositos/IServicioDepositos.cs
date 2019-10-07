using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Script.Services;
using System.Web.Services;

namespace wsRegistroDepositos
{
    [WebService(Namespace = "https://www.uca.edu.ni/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    [ServiceContract(Namespace = "https://www.uca.edu.ni")]
    public interface IServicioDepositos
    {
        [WebMethod]
        [OperationContract]
        int AgregarDeposito(int cantidad, int idUsuario);

        [WebMethod]
        [OperationContract]
        int AgregarUsuario(string nombre, int meta);

        [WebMethod]
        [OperationContract]
        List<Usuario> ListaUsuarios();
    }
}

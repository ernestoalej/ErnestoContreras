using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WSCorresponsales
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IWSCorresponsales
    {
        [OperationContract]
        Corresponsal obtenerCorresponsales();
        
        // TODO: agregue aquí sus operaciones de servicio
    }


    [DataContract]
    public class Corresponsal
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string nombre  { get; set; }


        [DataMember]
        public int nroOfi { get; set; }
    }

}

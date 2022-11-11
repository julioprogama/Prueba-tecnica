using Newtonsoft.Json;

using System.Runtime.Serialization;

namespace api.modelo
{
    [DataContract]
    public class Metadato
    {
        [JsonConstructor]
        public Metadato(string valor, string nombre, string codigo)
        {
            this.valor = valor;
            this.nombre = nombre;
            this.codigo = codigo;
        }

        public Metadato() { }

        [DataMember]
        public string valor { get; set; }
        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string tipo { get; set; }
        [DataMember]
        public string codigo { get; set; }


    }
}

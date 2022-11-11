namespace api.modelo
{
    public class ConexionModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public ConexionModel(string user, string pass)
        {
            this.UserName = user;
            this.Password = pass;
        }
    }
    public class Response
    {
        public string codigo { get; set; }
        public string Mensaje { get; set; }
        public string Error { get; set; }

        public Response() { }
        public Response(string codigo, string Mensaje, string Error)
        {
            this.codigo = codigo;
            this.Mensaje = Mensaje;
            this.Error = Error;
        }
    }
}

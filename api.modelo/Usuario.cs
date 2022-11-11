namespace api.modelo
{
    public class Usuario
    {


        private string userName;
        private string password;

        public Usuario(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public Usuario()
        {

        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }
}

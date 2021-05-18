namespace Business.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nome, string sobrenome, string login)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Sobrenome = sobrenome;
            Login = login;
        }

    }
}

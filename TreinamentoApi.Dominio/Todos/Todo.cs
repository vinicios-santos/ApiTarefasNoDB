using TreinamentoApi.Dominio.Infra;

namespace TreinamentoApi.Dominio.Todos
{
    public class Todo : ModelBase
    {
        public Todo(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }
        public EnumStatusTarefa Status { get; private set; }

        public void Alterar(string nome) => Nome = nome;
        public void IsCompleta() => Status = EnumStatusTarefa.Completa;
        public void IsFazendo() => Status = EnumStatusTarefa.Fazendo;
        public void IsAberta() => Status = EnumStatusTarefa.Aberta;

    }

    public enum EnumStatusTarefa
    {
        Aberta = 0,
        Fazendo = 1,
        Completa = 2
    }
}

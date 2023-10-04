using System;

namespace TreinamentoApi.Dominio.Infra
{
    public class ModelBase
    {
        public ModelBase()
        {
            Id = Guid.NewGuid();
            DataHoraCadastro = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public DateTime DataHoraCadastro { get; private set; }
    }
}

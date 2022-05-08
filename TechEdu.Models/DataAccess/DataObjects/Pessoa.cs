using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Alunos = new HashSet<Aluno>();
            Enderecos = new HashSet<Endereco>();
        }

        public int Id { get; set; }
        public string PrimeiroNome { get; set; } = null!;
        public string UltimoNome { get; set; } = null!;
        public string? Cpf { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}

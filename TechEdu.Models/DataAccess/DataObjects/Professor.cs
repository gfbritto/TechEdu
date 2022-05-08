using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Professor
    {
        public Professor()
        {
            Aulas = new HashSet<Aula>();
            PapelPessoas = new HashSet<PapelPessoa>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? Endereco { get; set; }
        public string? Cpf { get; set; }
        public string? Contato { get; set; }

        public virtual ICollection<Aula> Aulas { get; set; }
        public virtual ICollection<PapelPessoa> PapelPessoas { get; set; }
    }
}

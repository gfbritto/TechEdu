using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Responsavel
    {
        public Responsavel()
        {
            Alunos = new HashSet<Aluno>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}

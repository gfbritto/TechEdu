using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Turma
    {
        public Turma()
        {
            Alunos = new HashSet<Aluno>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}

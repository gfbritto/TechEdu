using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Turma
    {
        public Turma()
        {
            Alunos = new HashSet<Aluno>();
            Aulas = new HashSet<Aula>();
            Nota = new HashSet<Notum>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? ColegioId { get; set; }

        public virtual Colegio Colegio { get; set; }
        public virtual ICollection<Aluno> Alunos { get; set; }
        public virtual ICollection<Aula> Aulas { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}

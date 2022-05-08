using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Notum
    {
        public int Id { get; set; }
        public int TurmaId { get; set; }
        public int AulaId { get; set; }
        public int AlunoId { get; set; }
        public float Nota { get; set; }
        public int? PosicaoNota { get; set; }
        public DateTime? Data { get; set; }

        public virtual Aluno Aluno { get; set; } = null!;
        public virtual Aula Aula { get; set; } = null!;
        public virtual Turma Turma { get; set; } = null!;
    }
}

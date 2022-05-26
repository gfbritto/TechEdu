using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Aluno
    {
        public int Id { get; set; }
        public int? TurmaId { get; set; }
        public string? Ra { get; set; }
        public string PrimeiroNome { get; set; } = null!;
        public string UltimoNome { get; set; } = null!;

        public virtual Turma? Turma { get; set; }
    }
}

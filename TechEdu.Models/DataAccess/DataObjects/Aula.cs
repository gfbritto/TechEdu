using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Aula
    {
        public Aula()
        {
            Nota = new HashSet<Notum>();
        }

        public int Id { get; set; }
        public int MateriaId { get; set; }
        public int ProfessorId { get; set; }
        public int? TurmaId { get; set; }
        public DateTime? Horario { get; set; }
        public DateTime? Duracao { get; set; }
        public string? LocalAula { get; set; }

        public virtual Materium Materia { get; set; } = null!;
        public virtual Professor Professor { get; set; } = null!;
        public virtual Turma? Turma { get; set; }
        public virtual ICollection<Notum> Nota { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class TurmaMaterium
    {
        public int Id { get; set; }
        public int TurmaId { get; set; }
        public int MateriaId { get; set; }

        public virtual Materium Materia { get; set; } = null!;
        public virtual Turma Turma { get; set; } = null!;
    }
}

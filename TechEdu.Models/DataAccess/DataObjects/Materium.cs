using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Materium
    {
        public Materium()
        {
            Aulas = new HashSet<Aula>();
            Professors = new HashSet<Professor>();
            TurmaMateria = new HashSet<TurmaMaterium>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Aula> Aulas { get; set; }
        public virtual ICollection<Professor> Professors { get; set; }
        public virtual ICollection<TurmaMaterium> TurmaMateria { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Materia
    {
        public Materia()
        {
            Aulas = new HashSet<Aula>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Aula> Aulas { get; set; }
    }
}

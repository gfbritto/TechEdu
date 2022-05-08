using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Colegio
    {
        public Colegio()
        {
            Turmas = new HashSet<Turma>();
        }

        public int Id { get; set; }
        public string NomeColegio { get; set; } = null!;

        public virtual ICollection<Turma> Turmas { get; set; }
    }
}

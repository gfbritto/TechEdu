using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Materium
    {
        public Materium()
        {
            Professors = new HashSet<Professor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<Professor> Professors { get; set; }
    }
}

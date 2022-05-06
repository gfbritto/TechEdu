using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Materium
    {
        public Materium()
        {
            Aulas = new HashSet<Aula>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Aula> Aulas { get; set; }
    }
}

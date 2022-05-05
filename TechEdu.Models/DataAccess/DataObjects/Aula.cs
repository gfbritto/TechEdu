using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Aula
    {
        public int Id { get; set; }
        public int? Materias { get; set; }
        public int? Professor { get; set; }
        public int? Turma { get; set; }
        public DateTime? Horario { get; set; }
        public DateTime? Duracao { get; set; }
        public string LocalAula { get; set; }
    }
}

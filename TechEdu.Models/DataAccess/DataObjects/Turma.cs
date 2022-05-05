using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Turma
    {
        public int Id { get; set; }
        public string NomeClasse { get; set; }
        public int? Colegio { get; set; }
    }
}

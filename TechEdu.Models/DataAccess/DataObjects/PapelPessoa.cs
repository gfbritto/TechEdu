using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class PapelPessoa
    {
        public int Id { get; set; }
        public int? TipoPessoa { get; set; }
        public int? Professor { get; set; }
        public int? Aluno { get; set; }
    }
}

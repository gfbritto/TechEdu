using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Turma { get; set; }
        public string Ra { get; set; }
        public int? Enderecos { get; set; }
        public string Cpf { get; set; }
        public DateTime? Nascimento { get; set; }
        public int? Responsavel { get; set; }
    }
}

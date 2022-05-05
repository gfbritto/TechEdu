using System;
using System.Collections.Generic;

#nullable disable

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Nota
    {
        public int Id { get; set; }
        public int? Turmas { get; set; }
        public int? Aula { get; set; }
        public int? Aluno { get; set; }
        public float? Nota1 { get; set; }
        public int? PosicaoNota { get; set; }
        public DateTime? Data { get; set; }
    }
}

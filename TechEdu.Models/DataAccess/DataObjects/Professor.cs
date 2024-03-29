﻿using System;
using System.Collections.Generic;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string? Cpf { get; set; }
        public string? Contato { get; set; }
        public int? MateriaId { get; set; }

        public virtual Materium? Materia { get; set; }
    }
}

﻿using Microsoft.EntityFrameworkCore;

namespace TechEdu.Models.DataAccess.DataObjects
{
    public partial class ColegioContext : DbContext
    {
        public ColegioContext()
        {
        }

        public ColegioContext(DbContextOptions<ColegioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Alunos { get; set; } = null!;
        public virtual DbSet<Aula> Aulas { get; set; } = null!;
        public virtual DbSet<Endereco> Enderecos { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;
        public virtual DbSet<PapelPessoa> PapelPessoas { get; set; } = null!;
        public virtual DbSet<Professor> Professors { get; set; } = null!;
        public virtual DbSet<Turma> Turmas { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=servidordetestes.bounceme.net;uid=adm;pwd=techedu;database=colegio", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.33-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.ToTable("aluno");

                entity.HasIndex(e => e.TurmaId, "FK_ALUNO_TURMA_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.PrimeiroNome)
                    .HasMaxLength(45)
                    .HasColumnName("primeiroNome");

                entity.Property(e => e.Ra)
                    .HasMaxLength(15)
                    .HasColumnName("ra")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.TurmaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("turmaId");

                entity.Property(e => e.UltimoNome)
                    .HasMaxLength(45)
                    .HasColumnName("ultimoNome");

                entity.HasOne(d => d.Turma)
                    .WithMany(p => p.Alunos)
                    .HasForeignKey(d => d.TurmaId)
                    .HasConstraintName("FK_ALUNO_TURMA");
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.ToTable("aula");

                entity.HasIndex(e => e.MateriaId, "FK_AULA_MATERIA_idx");

                entity.HasIndex(e => e.ProfessorId, "FK_AULA_PROFESSOR_idx");

                entity.HasIndex(e => e.TurmaId, "FK_AULA_TURMA_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Duracao)
                    .HasColumnType("datetime")
                    .HasColumnName("duracao");

                entity.Property(e => e.Horario)
                    .HasColumnType("datetime")
                    .HasColumnName("horario");

                entity.Property(e => e.LocalAula)
                    .HasMaxLength(200)
                    .HasColumnName("local_aula")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.MateriaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("materiaId");

                entity.Property(e => e.ProfessorId)
                    .HasColumnType("int(11)")
                    .HasColumnName("professorId");

                entity.Property(e => e.TurmaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("turmaId");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.MateriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AULA_MATERIA");

                entity.HasOne(d => d.Professor)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.ProfessorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AULA_PROFESSOR");

                entity.HasOne(d => d.Turma)
                    .WithMany(p => p.Aulas)
                    .HasForeignKey(d => d.TurmaId)
                    .HasConstraintName("FK_AULA_TURMA");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("endereco");

                entity.HasIndex(e => e.AlunoId, "FK_ENDERECO_ALUNO_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.AlunoId)
                    .HasColumnType("int(11)")
                    .HasColumnName("alunoId");

                entity.Property(e => e.Cep)
                    .HasMaxLength(16)
                    .HasColumnName("cep")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Complemento)
                    .HasMaxLength(50)
                    .HasColumnName("complemento")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Logradouro)
                    .HasMaxLength(85)
                    .HasColumnName("logradouro")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Numero)
                    .HasMaxLength(8)
                    .HasColumnName("numero")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.Enderecos)
                    .HasForeignKey(d => d.AlunoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ENDERECO_ALUNO");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.ToTable("materia");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<PapelPessoa>(entity =>
            {
                entity.ToTable("papelPessoa");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Descricao)
                    .HasMaxLength(55)
                    .HasColumnName("descricao");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.ToTable("professor");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Contato)
                    .HasMaxLength(80)
                    .HasColumnName("contato")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Cpf)
                    .HasMaxLength(17)
                    .HasColumnName("cpf")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.Endereco)
                    .HasColumnType("int(11)")
                    .HasColumnName("endereco");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .HasColumnName("nome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.ToTable("turma");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuario");

                entity.HasIndex(e => e.PapelPessoaId, "USUARIO_PAPELPESSOA_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Nome)
                    .HasMaxLength(45)
                    .HasColumnName("nome")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.Property(e => e.PapelPessoaId)
                    .HasColumnType("int(11)")
                    .HasColumnName("papelPessoaId");

                entity.Property(e => e.Senha)
                    .HasMaxLength(64)
                    .HasColumnName("senha")
                    .UseCollation("latin1_swedish_ci")
                    .HasCharSet("latin1");

                entity.HasOne(d => d.PapelPessoa)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.PapelPessoaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_PAPELPESSOA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

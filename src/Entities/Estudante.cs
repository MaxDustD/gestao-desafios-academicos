using GestaoDesafiosAcademicos.Helpers;

namespace GestaoDesafiosAcademicos.Entities;

public class Estudante
{
    public string Nome { get; private set; }

    public string Matricula { get; init; }

    public string Curso { get; private set; }

    public string EmailInstitucional
    {
        get;
        private set;
    }

    public Estudante(
        string nome,
        string matricula,
        string curso,
        string emailInstitucional)
    {
        ValidadorTexto.Validar(
            nome,
            nameof(Nome));

        ValidadorTexto.Validar(
            matricula,
            nameof(Matricula));

        ValidadorTexto.Validar(
            curso,
            nameof(Curso));

        ValidadorEmail.Validar(
            emailInstitucional,
            nameof(EmailInstitucional));

        Nome = nome;
        Matricula = matricula;
        Curso = curso;
        EmailInstitucional =
            emailInstitucional;
    }

    public void AlterarNome(
        string novoNome)
    {
        ValidadorTexto.Validar(
            novoNome,
            nameof(Nome));

        Nome = novoNome;
    }

    public void AlterarCurso(
        string novoCurso)
    {
        ValidadorTexto.Validar(
            novoCurso,
            nameof(Curso));

        Curso = novoCurso;
    }

    public void AlterarEmail(
        string novoEmail)
    {
        ValidadorEmail.Validar(
            novoEmail,
            nameof(EmailInstitucional));

        EmailInstitucional =
            novoEmail;
    }
}
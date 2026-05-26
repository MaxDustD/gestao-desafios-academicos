using GestaoDesafiosAcademicos.Helpers;

namespace GestaoDesafiosAcademicos.Entities;

public class Professor
{
    public string Nome { get; private set; }

    public string Departamento
    {
        get;
        private set;
    }

    public string AreaAtuacao
    {
        get;
        private set;
    }

    public string Email
    {
        get;
        private set;
    }

    public Professor(
        string nome,
        string departamento,
        string areaAtuacao,
        string email)
    {
        ValidadorTexto.Validar(
            nome,
            nameof(Nome));

        ValidadorTexto.Validar(
            departamento,
            nameof(Departamento));

        ValidadorTexto.Validar(
            areaAtuacao,
            nameof(AreaAtuacao));

        ValidadorEmail.Validar(
            email,
            nameof(Email));

        Nome = nome;
        Departamento = departamento;
        AreaAtuacao = areaAtuacao;
        Email = email;
    }

    public void AlterarNome(
        string novoNome)
    {
        ValidadorTexto.Validar(
            novoNome,
            nameof(Nome));

        Nome = novoNome;
    }

    public void AlterarDepartamento(
        string novoDepartamento)
    {
        ValidadorTexto.Validar(
            novoDepartamento,
            nameof(Departamento));

        Departamento =
            novoDepartamento;
    }

    public void AlterarAreaAtuacao(
        string novaArea)
    {
        ValidadorTexto.Validar(
            novaArea,
            nameof(AreaAtuacao));

        AreaAtuacao = novaArea;
    }

    public void AlterarEmail(
        string novoEmail)
    {
        ValidadorEmail.Validar(
            novoEmail,
            nameof(Email));

        Email = novoEmail;
    }
}
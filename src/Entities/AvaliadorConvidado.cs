using GestaoDesafiosAcademicos.Helpers;

namespace GestaoDesafiosAcademicos.Entities;

public class AvaliadorConvidado
{
    public string Nome { get; private set; }

    public string Especialidade { get; init; }

    public string InstituicaoOrigem { get; init; }

    public string EmailContato { get; private set; }

    public AvaliadorConvidado(
        string nome,
        string especialidade,
        string instituicaoOrigem,
        string emailContato)
    {
        ValidadorTexto.Validar(nome, nameof(Nome));

        ValidadorTexto.Validar(
            especialidade,
            nameof(Especialidade));

        ValidadorTexto.Validar(
            instituicaoOrigem,
            nameof(InstituicaoOrigem));

        ValidadorEmail.Validar(
            emailContato,
            nameof(EmailContato));

        Nome = nome;
        Especialidade = especialidade;
        InstituicaoOrigem = instituicaoOrigem;
        EmailContato = emailContato;
    }
}
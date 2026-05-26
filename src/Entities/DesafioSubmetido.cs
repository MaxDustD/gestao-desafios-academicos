using GestaoDesafiosAcademicos.Helpers;

namespace GestaoDesafiosAcademicos.Entities;

public class DesafioSubmetido
{
    public string Titulo { get; private set; }

    public string Descricao { get; private set; }

    public Estudante ResponsavelPrincipal { get; private set; }

    public DateTime DataSubmissao { get; init; }

    public DesafioSubmetido(
        string titulo,
        string descricao,
        Estudante responsavelPrincipal)
    {
        ValidadorTexto.Validar(
            titulo,
            nameof(Titulo));

        ValidadorTexto.Validar(
            descricao,
            nameof(Descricao));

        ResponsavelPrincipal =
            responsavelPrincipal
            ?? throw new ArgumentNullException(
                nameof(responsavelPrincipal));

        Titulo = titulo;
        Descricao = descricao;

        DataSubmissao = DateTime.Now;
    }

    public void AlterarDescricao(
        string novaDescricao)
    {
        ValidadorTexto.Validar(
            novaDescricao,
            nameof(Descricao));

        Descricao = novaDescricao;
    }
}
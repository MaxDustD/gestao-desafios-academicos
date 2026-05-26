using GestaoDesafiosAcademicos.Helpers;

namespace GestaoDesafiosAcademicos.Entities;

public class RecursoInstitucional
{
    public string Descricao { get; init; }

    public string Categoria { get; init; }

    public int QuantidadeDisponivel { get; private set; }

    public RecursoInstitucional(
        string descricao,
        string categoria,
        int quantidadeDisponivel)
    {
        ValidadorTexto.Validar(
            descricao,
            nameof(Descricao));

        ValidadorTexto.Validar(
            categoria,
            nameof(Categoria));

        if (quantidadeDisponivel < 0)
        {
            throw new ArgumentException(
                "Quantidade inválida.");
        }

        Descricao = descricao;
        Categoria = categoria;
        QuantidadeDisponivel = quantidadeDisponivel;
    }
}
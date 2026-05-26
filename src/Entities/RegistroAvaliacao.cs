using GestaoDesafiosAcademicos.Helpers;

namespace GestaoDesafiosAcademicos.Entities;

public class RegistroAvaliacao
{
    public DesafioSubmetido Desafio { get; private set; }

    public FaseDesafio Fase { get; private set; }

    public string Descricao { get; private set; }

    public bool Aprovado { get; private set; }

    public DateTime DataRegistro { get; init; }

    internal RegistroAvaliacao(
        DesafioSubmetido desafio,
        FaseDesafio fase,
        string descricao,
        bool aprovado)
    {
        Desafio =
            desafio
            ?? throw new ArgumentNullException(
                nameof(desafio));

        Fase =
            fase
            ?? throw new ArgumentNullException(
                nameof(fase));

        ValidadorTexto.Validar(
            descricao,
            nameof(Descricao));

        Descricao = descricao;
        Aprovado = aprovado;

        DataRegistro = DateTime.Now;
    }
}
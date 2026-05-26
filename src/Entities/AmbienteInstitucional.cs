using GestaoDesafiosAcademicos.Helpers;

namespace GestaoDesafiosAcademicos.Entities;

public class AmbienteInstitucional
{
    public string Nome { get; init; }

    public string Localizacao { get; init; }

    public int Capacidade { get; private set; }

    public string TipoAmbiente { get; init; }

    public AmbienteInstitucional(
        string nome,
        string localizacao,
        int capacidade,
        string tipoAmbiente)
    {
        ValidadorTexto.Validar(nome, nameof(Nome));

        ValidadorTexto.Validar(
            localizacao,
            nameof(Localizacao));

        ValidadorTexto.Validar(
            tipoAmbiente,
            nameof(TipoAmbiente));

        if (capacidade <= 0)
        {
            throw new ArgumentException(
                "Capacidade deve ser maior que zero.");
        }

        Nome = nome;
        Localizacao = localizacao;
        Capacidade = capacidade;
        TipoAmbiente = tipoAmbiente;
    }
}
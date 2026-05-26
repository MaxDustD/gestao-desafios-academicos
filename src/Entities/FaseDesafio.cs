using GestaoDesafiosAcademicos.Helpers;

namespace GestaoDesafiosAcademicos.Entities;

public class FaseDesafio
{
    public string Descricao { get; private set; }

    public DateTime DataPrevista { get; private set; }

    public bool Obrigatoria { get; private set; }

    internal FaseDesafio(
        string descricao,
        DateTime dataPrevista,
        bool obrigatoria)
    {
        ValidadorTexto.Validar(
            descricao,
            nameof(Descricao));

        Descricao = descricao;
        DataPrevista = dataPrevista;
        Obrigatoria = obrigatoria;
    }
}
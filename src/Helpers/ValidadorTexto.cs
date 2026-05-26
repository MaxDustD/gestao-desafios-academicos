namespace GestaoDesafiosAcademicos.Helpers;

public static class ValidadorTexto
{
    public static void Validar(string valor, string campo)
    {
        if (string.IsNullOrWhiteSpace(valor))
        {
            throw new ArgumentException(
                $"{campo} é obrigatório."
            );
        }
    }
}
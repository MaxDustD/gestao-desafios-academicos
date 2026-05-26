using System.Text.RegularExpressions;

namespace GestaoDesafiosAcademicos.Helpers;

public static class ValidadorEmail
{
    private static readonly Regex RegexEmail =
        new(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled);

    public static void Validar(
        string email,
        string campo)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException(
                $"{campo} é obrigatório.");
        }

        if (!RegexEmail.IsMatch(email))
        {
            throw new ArgumentException(
                $"{campo} é inválido.");
        }
    }
}
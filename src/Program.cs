using GestaoDesafiosAcademicos.Entities;

var coordenador =
    new Estudante(
        "Pedro",
        "2024001",
        "Engenharia de Software",
        "pedro@universidade.edu");

var professorResponsavel =
    new Professor(
        "Carlos",
        "Computação",
        "Arquitetura de Software",
        "carlos@universidade.edu");

var professorColaborador =
    new Professor(
        "Marina",
        "Computação",
        "IA",
        "marina@universidade.edu");

var ambiente =
    new AmbienteInstitucional(
        "Laboratório Maker",
        "Bloco B",
        40,
        "Laboratório");

var programa =
    new ProgramaDesafiosInovacao(
        "Programa Inovação 2026",
        DateTime.Today,
        coordenador,
        professorResponsavel,
        ambiente);

programa.DefinirProfessorColaborador(
    professorColaborador);

var estudanteDesafio =
    new Estudante(
        "Lucas",
        "2024555",
        "ADS",
        "lucas@universidade.edu");

var desafio =
    new DesafioSubmetido(
        "Sistema Inteligente",
        "Sistema para gestão acadêmica.",
        estudanteDesafio);

programa.AdicionarDesafio(desafio);

var avaliador =
    new AvaliadorConvidado(
        "Fernanda",
        "Inovação",
        "Empresa Tech",
        "fernanda@empresa.com");

programa.AdicionarAvaliador(avaliador);

var recurso =
    new RecursoInstitucional(
        "Notebook Dell",
        "Hardware",
        10);

programa.AdicionarRecurso(recurso);

programa.AdicionarFase(
    "Submissão",
    DateTime.Today.AddDays(7),
    true);

programa.AdicionarFase(
    "Apresentação Final",
    DateTime.Today.AddDays(30),
    true);

var faseSubmissao =
    programa.Fases.First();

programa.RegistrarAvaliacao(
    desafio,
    faseSubmissao,
    "Boa proposta.",
    true);

try
{
    programa.Finalizar();
}
catch (Exception ex)
{
    Console.WriteLine(
        $"Erro: {ex.Message}");
}

var faseFinal =
    programa.Fases.Last();

programa.RegistrarAvaliacao(
    desafio,
    faseFinal,
    "Projeto aprovado.",
    true);

programa.Finalizar();

Console.WriteLine(
    $"Percentual aprovado: {programa.ObterPercentualFasesAprovadas()}%");

try
{
    var programaInvalido =
        new ProgramaDesafiosInovacao(
            "Programa Teste",
            DateTime.Today,
            coordenador,
            professorResponsavel,
            ambiente);

    programaInvalido.DefinirProfessorColaborador(
        professorResponsavel);
}
catch (Exception ex)
{
    Console.WriteLine(
        $"Erro professor colaborador: {ex.Message}");
}

try
{
    var desafioInvalido =
        new DesafioSubmetido(
            "Desafio Inválido",
            "Descrição teste",
            coordenador);

    var programaTeste =
        new ProgramaDesafiosInovacao(
            "Programa Teste 2",
            DateTime.Today,
            coordenador,
            professorResponsavel,
            ambiente);

    programaTeste.AdicionarDesafio(
        desafioInvalido);
}
catch (Exception ex)
{
    Console.WriteLine(
        $"Erro desafio inválido: {ex.Message}");
}

try
{
    var programaTeste =
        new ProgramaDesafiosInovacao(
            "Programa Duplicado",
            DateTime.Today,
            coordenador,
            professorResponsavel,
            ambiente);

    programaTeste.AdicionarDesafio(desafio);

    programaTeste.AdicionarDesafio(desafio);
}
catch (Exception ex)
{
    Console.WriteLine(
        $"Erro desafio duplicado: {ex.Message}");
}

try
{
    var programaTeste =
        new ProgramaDesafiosInovacao(
            "Programa Avaliador",
            DateTime.Today,
            coordenador,
            professorResponsavel,
            ambiente);

    programaTeste.AdicionarAvaliador(avaliador);

    programaTeste.AdicionarAvaliador(avaliador);
}
catch (Exception ex)
{
    Console.WriteLine(
        $"Erro avaliador duplicado: {ex.Message}");
}

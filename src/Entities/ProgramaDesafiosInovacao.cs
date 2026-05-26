using GestaoDesafiosAcademicos.Helpers;

namespace GestaoDesafiosAcademicos.Entities;

public class ProgramaDesafiosInovacao
{
    private readonly List<DesafioSubmetido> _desafios = [];

    private readonly List<AvaliadorConvidado> _avaliadores = [];

    private readonly List<RecursoInstitucional> _recursos = [];

    private readonly List<FaseDesafio> _fases = [];

    private readonly List<RegistroAvaliacao> _avaliacoes = [];

    public string Titulo { get; private set; }

    public DateTime DataInicio { get; init; }

    public Estudante Coordenador { get; private set; }

    public Professor Responsavel { get; private set; }

    public AmbienteInstitucional Ambiente { get; private set; }

    public Professor? ProfessorColaborador{get; private set;}

    public bool Finalizado { get; private set; }

    public IReadOnlyCollection<DesafioSubmetido> Desafios => _desafios.AsReadOnly();

    public IReadOnlyCollection<AvaliadorConvidado> Avaliadores => _avaliadores.AsReadOnly();

    public IReadOnlyCollection<RecursoInstitucional> Recursos => _recursos.AsReadOnly();

    public IReadOnlyCollection<FaseDesafio> Fases => _fases.AsReadOnly();

    public IReadOnlyCollection<RegistroAvaliacao> Avaliacoes => _avaliacoes.AsReadOnly();

    public ProgramaDesafiosInovacao(
        string titulo,
        DateTime dataInicio,
        Estudante coordenador,
        Professor responsavel,
        AmbienteInstitucional ambiente)
    {
        ValidadorTexto.Validar(
            titulo,
            nameof(Titulo));

        Coordenador =
            coordenador
            ?? throw new ArgumentNullException(
                nameof(coordenador));

        Responsavel =
            responsavel
            ?? throw new ArgumentNullException(
                nameof(responsavel));

        Ambiente =
            ambiente
            ?? throw new ArgumentNullException(
                nameof(ambiente));

        Titulo = titulo;
        DataInicio = dataInicio;
    }

    public void DefinirProfessorColaborador(
    Professor professor)
    {
        if (professor is null)
        {
            throw new ArgumentNullException(
                nameof(professor));
        }

        if (professor == Responsavel)
        {
            throw new InvalidOperationException(
                "Professor colaborador não pode ser o mesmo responsável.");
        }

        ProfessorColaborador = professor;
    }

    public void AdicionarDesafio(
        DesafioSubmetido desafio)
    {
        if (Finalizado)
        {
            throw new InvalidOperationException(
                "Programa finalizado.");
        }

        if (desafio is null)
        {
            throw new ArgumentNullException(
                nameof(desafio));
        }

        bool desafioDuplicado =
            _desafios.Any(d =>
                d.Titulo.Equals(
                    desafio.Titulo,
                    StringComparison.OrdinalIgnoreCase));

        if (desafioDuplicado)
        {
            throw new InvalidOperationException(
                "Desafio duplicado.");
        }

        if (desafio.ResponsavelPrincipal
            == Coordenador)
        {
            throw new InvalidOperationException(
                "Coordenador não pode ser responsável por desafio.");
        }

        _desafios.Add(desafio);
    }

    public void RemoverDesafio(
        DesafioSubmetido desafio)
    {
        if (Finalizado)
        {
            throw new InvalidOperationException(
                "Programa finalizado.");
        }

        if (!_desafios.Contains(desafio))
        {
            throw new InvalidOperationException(
                "Desafio não encontrado.");
        }

        bool possuiFaseObrigatoria =
            _fases.Any(f => f.Obrigatoria);

        if (possuiFaseObrigatoria
            && _desafios.Count == 1)
        {
            throw new InvalidOperationException(
                "Programa não pode ficar sem desafios.");
        }

        _desafios.Remove(desafio);
    }

    public void AdicionarAvaliador(
    AvaliadorConvidado avaliador)
    {
        if (Finalizado)
        {
            throw new InvalidOperationException(
                "Programa finalizado.");
        }

        if (avaliador is null)
        {
            throw new ArgumentNullException(
                nameof(avaliador));
        }

        bool avaliadorDuplicado =
            _avaliadores.Any(a =>
                a.EmailContato.Equals(
                    avaliador.EmailContato,
                    StringComparison.OrdinalIgnoreCase));
        
        if (avaliadorDuplicado)
        {
            throw new InvalidOperationException(
                "Avaliador duplicado.");
        }

        _avaliadores.Add(avaliador);
    }

    public void RemoverAvaliador(
        AvaliadorConvidado avaliador)
    {
        if (Finalizado)
        {
            throw new InvalidOperationException(
                "Programa finalizado.");
        }

        if (!_avaliadores.Contains(avaliador))
        {
            throw new InvalidOperationException(
                "Avaliador não encontrado.");
        }

        _avaliadores.Remove(avaliador);
    }

    public void AdicionarRecurso(
    RecursoInstitucional recurso)
    {
        if (Finalizado)
        {
            throw new InvalidOperationException(
                "Programa finalizado.");
        }

        if (recurso is null)
        {
            throw new ArgumentNullException(
                nameof(recurso));
        }

        bool recursoDuplicado =
            _recursos.Any(r =>
                r.Descricao.Equals(
                    recurso.Descricao,
                    StringComparison.OrdinalIgnoreCase));

        if (recursoDuplicado)
        {
            throw new InvalidOperationException(
                "Recurso duplicado.");
        }

        _recursos.Add(recurso);
    }

    public void RemoverRecurso(
        RecursoInstitucional recurso)
    {
        if (Finalizado)
        {
            throw new InvalidOperationException(
                "Programa finalizado.");
        }

        if (!_recursos.Contains(recurso))
        {
            throw new InvalidOperationException(
                "Recurso não encontrado.");
        }

        _recursos.Remove(recurso);
    }

    public void AdicionarFase(
    string descricao,
    DateTime dataPrevista,
    bool obrigatoria)
    {
        if (Finalizado)
        {
            throw new InvalidOperationException(
                "Programa finalizado.");
        }

        ValidadorTexto.Validar(
            descricao,
            nameof(descricao));

        if (dataPrevista < DataInicio)
        {
            throw new InvalidOperationException(
                "Data da fase inválida.");
        }

        bool faseDuplicada =
            _fases.Any(f =>
                f.Descricao.Equals(
                    descricao,
                    StringComparison.OrdinalIgnoreCase));

        if (faseDuplicada)
        {
            throw new InvalidOperationException(
                "Fase duplicada.");
        }

        var fase = new FaseDesafio(
            descricao,
            dataPrevista,
            obrigatoria);

        _fases.Add(fase);
    }

    public void RegistrarAvaliacao(
    DesafioSubmetido desafio,
    FaseDesafio fase,
    string descricao,
    bool aprovado)
    {
        if (Finalizado)
        {
            throw new InvalidOperationException(
                "Programa finalizado.");
        }

        if (!_desafios.Contains(desafio))
        {
            throw new InvalidOperationException(
                "Desafio não pertence ao programa.");
        }

        if (!_fases.Contains(fase))
        {
            throw new InvalidOperationException(
                "Fase não pertence ao programa.");
        }

        ValidadorTexto.Validar(
            descricao,
            nameof(descricao));

        bool avaliacaoDuplicada =
            _avaliacoes.Any(a =>
                a.Desafio == desafio
                && a.Fase == fase);

        if (avaliacaoDuplicada)
        {
            throw new InvalidOperationException(
                "Avaliação já registrada.");
        }

        var avaliacao =
            new RegistroAvaliacao(
                desafio,
                fase,
                descricao,
                aprovado);

        _avaliacoes.Add(avaliacao);
    }

    public void Finalizar()
    {
        if (Finalizado)
        {
            throw new InvalidOperationException(
                "Programa já finalizado.");
        }

        if (_desafios.Count == 0)
        {
            throw new InvalidOperationException(
                "Programa precisa ter desafios.");
        }

        bool possuiFaseObrigatoria =
            _fases.Any(f => f.Obrigatoria);

        if (!possuiFaseObrigatoria)
        {
            throw new InvalidOperationException(
                "Programa precisa ter fase obrigatória.");
        }

        var fasesObrigatorias =
            _fases.Where(f => f.Obrigatoria);

        foreach (var fase in fasesObrigatorias)
        {
            bool possuiAvaliacao =
                _avaliacoes.Any(a =>
                    a.Fase == fase);

            if (!possuiAvaliacao)
            {
                throw new InvalidOperationException(
                    $"Fase obrigatória '{fase.Descricao}' sem avaliação.");
            }
        }

        if (ProfessorColaborador == Responsavel)
        {
            throw new InvalidOperationException(
                "Professor colaborador inválido.");
        }

        Finalizado = true;
    }

    public double ObterPercentualFasesAprovadas()
    {
        if (!Finalizado)
        {
            throw new InvalidOperationException(
                "Programa não finalizado.");
        }

        if (_fases.Count == 0)
        {
            return 0;
        }

        int fasesAprovadas =
            _fases.Count(f =>
                _avaliacoes.Any(a =>
                    a.Fase == f
                    && a.Aprovado));

        return
            (double)fasesAprovadas
            / _fases.Count
            * 100;
    }
}
# Regras de modelagem

- Não usar setters públicos desnecessários.
- Toda coleção deve ser:
  private readonly List<T>

- Toda exposição externa deve usar:
  IReadOnlyCollection<T>

- Toda modificação deve ocorrer via métodos.

- Validar invariantes no construtor.

- Não permitir objetos inválidos.

- Aplicar composição para:
  - FaseDesafio
  - RegistroAvaliacao

- Aplicar agregação para:
  - AvaliadorConvidado
  - RecursoInstitucional
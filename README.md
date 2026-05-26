# Gestão de Desafios Acadêmicos

Projeto acadêmico desenvolvido em C# com foco na aplicação prática dos principais conceitos de Programação Orientada a Objetos (POO). O sistema realiza o gerenciamento de programas acadêmicos de desafios de inovação tecnológica, permitindo o controle de estudantes coordenadores, professores responsáveis, avaliadores convidados, ambientes institucionais, recursos utilizados, fases dos desafios e registros de avaliação.

---

# Índice

- [Objetivo do Projeto](#objetivo-do-projeto)
- [Modelagem do Domínio](#modelagem-do-domínio)
- [Relacionamentos Entre Entidades](#relacionamentos-entre-entidades)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Demonstrações Implementadas](#demonstrações-implementadas)
- [Como Executar o Projeto](#como-executar-o-projeto)
- [Exemplo de Execução](#exemplo-de-execução)
- [Autor](#autor)

---

# Objetivo do Projeto

O objetivo deste projeto é modelar um sistema orientado a objetos consistente e seguro para gerenciamento de programas acadêmicos de desafios de inovação tecnológica.

O sistema foi desenvolvido com foco em:

- modelagem orientada a objetos;
- encapsulamento;
- proteção de invariantes;
- validações de domínio;
- associações entre objetos;
- agregação;
- composição;
- controle de estado do sistema.

O projeto foi desenvolvido sem banco de dados, sem interface gráfica e sem frameworks externos, priorizando exclusivamente a qualidade da modelagem orientada a objetos.

---

# Modelagem do Domínio

O domínio representa programas acadêmicos de desafios de inovação tecnológica realizados por estudantes.

O sistema controla:

- estudantes coordenadores;
- professores responsáveis;
- professores colaboradores;
- desafios submetidos;
- avaliadores convidados;
- recursos institucionais;
- fases do desafio;
- registros de avaliação.

A entidade principal do domínio é:

```text
ProgramaDesafiosInovacao
```

Ela centraliza todas as regras de negócio e protege os estados válidos do sistema.

---

# Relacionamentos Entre Entidades

```text
ProgramaDesafiosInovacao
│
├── Coordenador -> Estudante
├── Responsavel -> Professor
├── Colaborador -> Professor?
├── Ambiente -> AmbienteInstitucional
│
├── Desafios (1:N)
├── Avaliadores (1:N agregação)
├── Recursos (1:N agregação)
├── Fases (1:N composição)
└── Registros (1:N composição)
```

---

# Estrutura do Projeto

```text
GestaoDesafiosAcademicos/
│
├── src/
│   ├── Entities/
│   │   ├── Estudante.cs
│   │   ├── Professor.cs
│   │   ├── AmbienteInstitucional.cs
│   │   ├── ProgramaDesafiosInovacao.cs
│   │   ├── DesafioSubmetido.cs
│   │   ├── AvaliadorConvidado.cs
│   │   ├── RecursoInstitucional.cs
│   │   ├── FaseDesafio.cs
│   │   └── RegistroAvaliacao.cs
│   │
│   ├── Helpers/
│   │   ├── ValidadorTexto.cs
│   │   └── ValidadorEmail.cs
│   │
│   └── Program.cs
│
├── docs/
│   ├── dominio.md
│   ├── enunciado.md
│   ├── modelagem.md
│   ├── regras-negocio.md
│   └── workflow.md
│
├── README.md
├── .gitignore
└── Trabalho.csproj
```

---

# Demonstrações Implementadas

O arquivo `Program.cs` demonstra:

## Cenários válidos

- criação de entidades;
- criação do programa;
- adição de desafios;
- adição de avaliadores;
- adição de recursos;
- criação de fases;
- registro de avaliações;
- finalização do programa;
- cálculo do percentual de aprovação.

---

## Cenários inválidos

Também foram implementadas demonstrações utilizando `try/catch` para capturar erros de domínio.

---

# Como Executar o Projeto

## Clonar repositório

```bash
git clone <url-do-repositorio>
```

---

## Acessar diretório

```bash
cd GestaoDesafiosAcademicos
```

---

## Restaurar dependências

```bash
dotnet restore
```

---

## Compilar projeto

```bash
dotnet build
```

---

## Executar aplicação

```bash
dotnet run
```

---

# Exemplo de Execução

```text
Programa criado com sucesso.

Professor colaborador definido.

Desafio adicionado:
- Plataforma de acessibilidade acadêmica

Avaliador adicionado:
- Marina Lopes

Recurso adicionado:
- Servidor de testes

Fase adicionada:
- Avaliação Final

Avaliação registrada com sucesso.

Programa finalizado com sucesso.

Percentual de fases aprovadas:
100%
```

---

# Autor

MaxDustD

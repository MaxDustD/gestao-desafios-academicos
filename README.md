# Gestão de Desafios Acadêmicos

Projeto acadêmico desenvolvido em C# com foco na aplicação prática dos principais conceitos de Programação Orientada a Objetos (POO). O sistema realiza o gerenciamento de programas acadêmicos de desafios de inovação tecnológica, permitindo o controle de estudantes coordenadores, professores responsáveis, avaliadores convidados, ambientes institucionais, recursos utilizados, fases dos desafios e registros de avaliação.

---

# Índice

- [Objetivo do Projeto](#objetivo-do-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Conceitos de POO Aplicados](#conceitos-de-poo-aplicados)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Modelagem do Domínio](#modelagem-do-domínio)
- [Relacionamentos](#relacionamentos)
- [Regras de Negócio](#regras-de-negócio)
- [Encapsulamento e Proteção de Invariantes](#encapsulamento-e-proteção-de-invariantes)
- [Agregação e Composição](#agregação-e-composição)
- [Fluxo de Funcionamento](#fluxo-de-funcionamento)
- [Demonstrações Implementadas](#demonstrações-implementadas)
- [Estrutura de Pastas](#estrutura-de-pastas)
- [Como Executar o Projeto](#como-executar-o-projeto)
- [Exemplo de Execução](#exemplo-de-execução)
- [Possíveis Melhorias Futuras](#possíveis-melhorias-futuras)
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

# Tecnologias Utilizadas

- C#
- .NET
- Programação Orientada a Objetos (POO)
- Git
- GitHub

---

# Conceitos de POO Aplicados

O projeto aplica diversos conceitos fundamentais de orientação a objetos:

## Encapsulamento

As entidades protegem seus próprios estados internos utilizando:

- propriedades com `private set`;
- listas privadas;
- métodos controlados para alteração de estado.

---

## Associação 1:1

A classe `ProgramaDesafiosInovacao` possui associação obrigatória com:

- `Estudante`
- `Professor`
- `AmbienteInstitucional`

Além de associação opcional com:

- `Professor` colaborador

---

## Associação 1:N

O programa pode possuir:

- vários desafios;
- vários avaliadores;
- vários recursos;
- várias fases;
- vários registros de avaliação.

---

## Agregação

As seguintes entidades possuem ciclo de vida independente do programa:

- `AvaliadorConvidado`
- `RecursoInstitucional`

Esses objetos são criados externamente e apenas associados ao programa.

---

## Composição

As seguintes entidades pertencem exclusivamente ao programa:

- `FaseDesafio`
- `RegistroAvaliacao`

Esses objetos são criados e controlados internamente pela classe principal.

---

## Proteção de Invariantes

O sistema impede estados inválidos por meio de regras de negócio implementadas diretamente nas entidades.

Exemplos:

- não permitir desafios duplicados;
- impedir alterações após finalização;
- validar textos obrigatórios;
- impedir avaliações duplicadas;
- impedir finalização inválida.

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
    ├── dominio.md
    ├── enunciado.md
    ├── modelagem.md
    ├── regras-negocio.md
    ├── workflow.md
└── README.md
# Gestão de Desafios Acadêmicos

Projeto acadêmico desenvolvido em C# com foco na aplicação prática dos principais conceitos de Programação Orientada a Objetos (POO). O sistema realiza o gerenciamento de programas acadêmicos de desafios de inovação tecnológica, permitindo o controle de estudantes coordenadores, professores responsáveis, avaliadores convidados, ambientes institucionais, recursos utilizados, fases dos desafios e registros de avaliação.

---

# Índice

- [Objetivo do Projeto](#objetivo-do-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Conceitos de POO Aplicados](#conceitos-de-poo-aplicados)
- [Modelagem do Domínio](#modelagem-do-domínio)
- [Relacionamentos Entre Entidades](#relacionamentos-entre-entidades)
- [Proteção de Invariantes](#proteção-de-invariantes)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Fluxo de Funcionamento](#fluxo-de-funcionamento)
- [Demonstrações Implementadas](#demonstrações-implementadas)
- [Estrutura de Pastas](#estrutura-de-pastas)
- [Como Executar o Projeto](#como-executar-o-projeto)
- [Exemplo de Execução](#exemplo-de-execução)
- [Possíveis Melhorias Futuras](#possíveis-melhorias-futuras)
- [Aprendizados Aplicados](#aprendizados-aplicados)
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

O projeto aplica diversos conceitos fundamentais de orientação a objetos.

---

## Encapsulamento

As entidades protegem seus próprios estados internos utilizando:

- propriedades com `private set`;
- propriedades com `init`;
- listas privadas;
- métodos controlados para alteração de estado.

Exemplo:

```csharp
private readonly List<DesafioSubmetido> _desafios = new();
```

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

## Uso de IReadOnlyCollection

As coleções internas não são expostas diretamente como `List<T>` pública.

O acesso externo é realizado utilizando:

```csharp
IReadOnlyCollection<T>
```

Isso impede que código externo altere diretamente o estado interno da entidade.

---

## Uso de Helpers de Validação

O projeto utiliza classes auxiliares para centralizar validações reutilizáveis.

Helpers implementados:

- `ValidadorTexto`
- `ValidadorEmail`

Objetivos:

- evitar duplicação de código;
- padronizar validações;
- melhorar legibilidade;
- facilitar manutenção.

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

# Proteção de Invariantes

O sistema mantém diversas regras de negócio obrigatórias durante todo o ciclo de vida dos objetos.

Principais invariantes implementadas:

- programa deve possuir coordenador;
- programa deve possuir professor responsável;
- programa deve possuir ambiente institucional;
- professor colaborador não pode ser igual ao responsável;
- não permitir desafios duplicados;
- não permitir avaliadores duplicados;
- não permitir recursos duplicados;
- não permitir fases duplicadas;
- não permitir avaliações duplicadas;
- impedir alterações após finalização;
- fases obrigatórias precisam possuir avaliação;
- coordenador não pode ser responsável por desafio do mesmo programa.

Caso alguma regra seja violada, exceções são lançadas utilizando:

```csharp
ArgumentException
```

ou

```csharp
InvalidOperationException
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

# Fluxo de Funcionamento

O funcionamento básico do sistema segue as seguintes etapas:

1. criação das entidades independentes;
2. criação do programa de desafios;
3. definição opcional do professor colaborador;
4. associação de desafios;
5. associação de avaliadores;
6. associação de recursos;
7. criação das fases;
8. registro das avaliações;
9. finalização do programa;
10. cálculo do percentual de fases aprovadas.

Todas as operações passam por validações de domínio antes de serem executadas.

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

# Estrutura de Pastas

## `src/Entities`

Contém todas as entidades do domínio.

---

## `src/Helpers`

Contém validações reutilizáveis.

---

## `docs`

Contém documentação complementar utilizada durante modelagem do projeto.

Arquivos:

- `dominio.md`
- `enunciado.md`
- `modelagem.md`
- `regras-negocio.md`
- `workflow.md`

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

# Possíveis Melhorias Futuras

O projeto pode ser expandido futuramente com:

- persistência em banco de dados;
- interface gráfica;
- API REST;
- autenticação de usuários;
- sistema de equipes;
- geração de relatórios;
- exportação de dados;
- testes automatizados;
- aplicação de padrões de projeto;
- arquitetura em camadas;
- integração com Entity Framework.

---

# Aprendizados Aplicados

Durante o desenvolvimento deste projeto foram praticados:

- encapsulamento;
- modelagem orientada a objetos;
- associações entre objetos;
- agregação;
- composição;
- validação de domínio;
- proteção de invariantes;
- organização de código;
- uso de coleções seguras;
- tratamento de exceções;
- boas práticas em C#;
- uso de Git e GitHub.

---

# Autor

MaxDustD

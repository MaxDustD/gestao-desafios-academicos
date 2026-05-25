# Prova de Programação Orientada a Objetos

## Enunciado inédito

Uma instituição de ensino deseja desenvolver parte de um sistema para organizar **programas acadêmicos de desafios de inovação tecnológica realizados por estudantes**. O sistema deve controlar o programa de desafios, o estudante coordenador, o professor responsável, o ambiente institucional de referência, os desafios submetidos, os avaliadores convidados, os recursos institucionais utilizados, as fases do desafio e os registros de avaliação realizados ao longo da execução.

Seu objetivo é implementar, em C#, um modelo orientado a objetos para esse domínio, aplicando corretamente os conceitos de **associação 1:1**, **associação 1:N**, **dependência obrigatória**, **dependência opcional**, **encapsulamento**, **validação**, **proteção de invariantes**, **agregação** e **composição**.

A implementação deve ser feita sem banco de dados, sem interface gráfica e sem frameworks externos. O foco da prova é a qualidade da modelagem orientada a objetos.

## Contexto do domínio

A instituição promove programas de desafios de inovação para estimular estudantes a proporem soluções tecnológicas para problemas acadêmicos, sociais, administrativos ou comunitários. Esses desafios podem envolver aplicativos, sistemas web, automações, protótipos, ferramentas educacionais, soluções de acessibilidade e recursos digitais de apoio ao ensino.

Cada programa de desafios possui um estudante coordenador, um professor responsável, um ambiente institucional de referência, desafios submetidos por equipes ou estudantes, avaliadores convidados, recursos institucionais e fases planejadas.

A instituição já possui estudantes, professores e ambientes institucionais cadastrados. Um estudante pode coordenar um programa e também ser responsável por um desafio em outro contexto. Um professor pode ser responsável por diferentes programas. Um ambiente institucional, como laboratório, sala maker, auditório, sala de projetos ou ambiente virtual, pode ser utilizado em diferentes programas. Portanto, estudantes, professores e ambientes institucionais existem independentemente de um programa específico.

Também podem existir avaliadores convidados, como egressos, profissionais de empresas, professores externos, empreendedores, técnicos ou representantes da comunidade. Esses avaliadores existem independentemente de um programa específico e podem participar de diferentes ações acadêmicas.

A instituição possui recursos institucionais cadastrados, como notebooks, projetores, kits de prototipação, licenças de software, servidores de teste, salas de reunião, painéis de apresentação e equipamentos de laboratório. Esses recursos podem ser utilizados em diferentes programas.

Por outro lado, as fases do desafio são criadas especificamente para um programa. Uma fase como “Submissão da proposta”, “Validação do problema”, “Desenvolvimento da solução”, “Demonstração técnica”, “Avaliação final” ou “Apresentação dos resultados” faz sentido apenas dentro do programa em que foi planejada.

Durante o programa, os desafios submetidos recebem registros de avaliação relacionados às fases. Um programa somente pode ser finalizado se possuir pelo menos um desafio submetido, pelo menos uma fase obrigatória e se todas as fases obrigatórias tiverem registro de avaliação.

## Classes mínimas esperadas

Você deve criar, no mínimo, as seguintes classes:

- `Estudante`
- `Professor`
- `AmbienteInstitucional`
- `ProgramaDesafiosInovacao`
- `DesafioSubmetido`
- `AvaliadorConvidado`
- `RecursoInstitucional`
- `FaseDesafio`
- `RegistroAvaliacao`

Você pode criar outras classes auxiliares, enums ou métodos de apoio, caso julgue necessário.

## Requisitos de modelagem

### 1. Objetos válidos desde a criação

Todas as classes devem proteger seus dados internos.

Campos textuais obrigatórios não podem aceitar valores nulos, vazios ou compostos apenas por espaços.

Exemplos de dados que devem ser validados:

- nome do estudante;
- nome do professor;
- nome do ambiente institucional;
- título do programa de desafios;
- título do desafio submetido;
- nome do avaliador convidado;
- descrição do recurso institucional;
- descrição da fase do desafio;
- texto do registro de avaliação.

Sempre que um valor inválido for informado, o objeto não deve ser criado ou alterado para um estado inconsistente.

Use exceções apropriadas, como `ArgumentException` ou `InvalidOperationException`, quando necessário.

### 2. Associação 1:1 obrigatória

A classe `ProgramaDesafiosInovacao` deve possuir associação obrigatória com:

- um `Estudante` coordenador;
- um `Professor` responsável;
- um `AmbienteInstitucional` de referência.

Um programa de desafios de inovação não pode existir sem estudante coordenador, sem professor responsável ou sem ambiente institucional de referência.

Essas associações devem ser recebidas pelo construtor da classe `ProgramaDesafiosInovacao` e validadas no momento da criação.

Não é permitido representar essas relações usando apenas `string`, como `NomeCoordenador`, `NomeResponsavel` ou `NomeAmbiente`.

O correto é que o programa mantenha referências reais para objetos dos tipos `Estudante`, `Professor` e `AmbienteInstitucional`.

### 3. Associação 1:1 opcional

O programa pode possuir, opcionalmente, um professor colaborador.

O professor colaborador deve ser representado por um objeto do tipo `Professor`.

O programa deve poder ser criado sem professor colaborador, mas deve permitir que ele seja definido posteriormente por meio de um método específico, por exemplo:

```csharp
DefinirProfessorColaborador(Professor professor)
```

Esse método deve validar se o professor informado é válido.

O professor colaborador não pode ser o mesmo professor definido como responsável.

A propriedade do professor colaborador deve deixar claro que a associação é opcional.

### 4. Associação 1:N com desafios submetidos

Um programa de desafios pode possuir vários desafios submetidos.

Os desafios submetidos são objetos do tipo `DesafioSubmetido`.

A classe `ProgramaDesafiosInovacao` deve manter internamente uma coleção privada de desafios.

A lista não pode ser exposta diretamente como `List<DesafioSubmetido>` pública com `set`.

A exposição externa deve permitir apenas leitura, por exemplo com:

```csharp
IReadOnlyCollection<DesafioSubmetido>
```

A alteração da coleção deve ser controlada por métodos da própria classe `ProgramaDesafiosInovacao`, como:

```csharp
AdicionarDesafio(DesafioSubmetido desafio)
RemoverDesafio(DesafioSubmetido desafio)
```

### 5. Invariantes dos desafios submetidos

A coleção de desafios submetidos deve obedecer às seguintes regras:

- não pode aceitar desafio nulo;
- não pode permitir desafio duplicado;
- o estudante coordenador do programa não pode ser o responsável principal por um desafio submetido no mesmo programa;
- o programa deve ter pelo menos um desafio submetido para ser finalizado;
- desafios não podem ser adicionados ou removidos depois que o programa estiver finalizado;
- a remoção não pode ocorrer se o desafio informado não estiver associado ao programa;
- a remoção não pode deixar o programa sem desafios caso ele já possua fases obrigatórias cadastradas.

Caso alguma dessas regras seja violada, uma exceção deve ser lançada.

### 6. Associação 1:N por agregação com avaliadores convidados

O programa pode possuir vários avaliadores convidados.

A classe `AvaliadorConvidado` deve representar uma pessoa que existe independentemente do programa. Um avaliador pode participar de diferentes programas, eventos, bancas ou projetos ao longo do tempo.

Por isso, a relação entre `ProgramaDesafiosInovacao` e `AvaliadorConvidado` deve ser tratada como **agregação**.

Os avaliadores devem ser criados fora do programa e passados para ele quando necessário.

Exemplo conceitual:

```csharp
var avaliador = new AvaliadorConvidado("Marina Lopes", "Inovação e validação de soluções tecnológicas");
programa.AdicionarAvaliador(avaliador);
```

O programa não deve criar internamente os avaliadores convidados.

A coleção de avaliadores deve ser privada internamente e exposta apenas como leitura.

### 7. Invariantes dos avaliadores convidados

A coleção de avaliadores convidados deve obedecer às seguintes regras:

- não pode aceitar avaliador nulo;
- não pode permitir avaliador duplicado no mesmo programa;
- avaliadores não podem ser adicionados depois que o programa estiver finalizado;
- avaliadores não podem ser removidos depois que o programa estiver finalizado;
- a remoção não pode ocorrer se o avaliador informado não estiver associado ao programa.

### 8. Associação 1:N por agregação com recursos institucionais

O programa pode utilizar vários recursos institucionais.

A classe `RecursoInstitucional` deve representar um recurso previamente existente na instituição. Um recurso pode ser usado em diferentes programas acadêmicos ao longo do tempo.

Por isso, a relação entre `ProgramaDesafiosInovacao` e `RecursoInstitucional` também deve ser tratada como **agregação**.

Os recursos devem ser criados fora do programa e passados para ele quando necessário.

Exemplo conceitual:

```csharp
var servidorTeste = new RecursoInstitucional("Servidor de testes para validação das soluções submetidas");
programa.AdicionarRecurso(servidorTeste);
```

O programa não deve criar internamente os recursos institucionais.

A coleção de recursos deve ser privada internamente e exposta apenas como leitura.

### 9. Invariantes dos recursos institucionais

A coleção de recursos institucionais deve obedecer às seguintes regras:

- não pode aceitar recurso nulo;
- não pode permitir recurso duplicado no mesmo programa;
- recursos não podem ser adicionados depois que o programa estiver finalizado;
- recursos não podem ser removidos depois que o programa estiver finalizado;
- a remoção não pode ocorrer se o recurso informado não estiver associado ao programa.

### 10. Composição com fases do desafio

As fases do desafio pertencem ao programa de desafios.

A classe `FaseDesafio` deve representar uma etapa específica planejada para o andamento do programa, por exemplo:

- “Submissão da proposta”;
- “Validação do problema”;
- “Desenvolvimento da solução”;
- “Demonstração técnica”;
- “Avaliação final”;
- “Apresentação dos resultados”.

Essas fases devem ser criadas pela própria classe `ProgramaDesafiosInovacao`, e não recebidas prontas de fora.

Portanto, o método de inclusão deve receber os dados necessários para criar a fase internamente, por exemplo:

```csharp
AdicionarFase(string descricao, DateTime dataPrevista, bool obrigatoria)
```

A própria classe `ProgramaDesafiosInovacao` deve instanciar o objeto `FaseDesafio`.

Essa decisão representa uma composição: a fase pertence ao programa e não deve existir de forma independente no sistema.

### 11. Invariantes das fases do desafio

A classe `ProgramaDesafiosInovacao` deve controlar a coleção de fases do desafio.

A coleção deve ser privada internamente e exposta apenas para leitura.

As fases devem obedecer às seguintes regras:

- a descrição da fase é obrigatória;
- a data prevista não pode ser anterior à data de início do programa;
- não pode haver duas fases com a mesma descrição no mesmo programa;
- o programa precisa ter pelo menos uma fase obrigatória para ser finalizado;
- fases não podem ser adicionadas após o programa ser finalizado;
- toda fase obrigatória deve receber registro de avaliação antes da finalização do programa.

### 12. Composição com registros de avaliação

A classe `RegistroAvaliacao` deve representar a avaliação registrada para um desafio submetido em uma fase do desafio.

Cada registro deve estar associado a:

- um desafio submetido;
- uma fase do desafio;
- uma descrição textual da avaliação, evidência, resultado observado ou recomendação;
- uma indicação se o desafio foi aprovado naquela fase ou não.

O registro deve ser feito por meio de um método da classe `ProgramaDesafiosInovacao`, por exemplo:

```csharp
RegistrarAvaliacao(DesafioSubmetido desafio, FaseDesafio fase, string descricao, bool aprovado)
```

A classe `ProgramaDesafiosInovacao` deve validar:

- se o desafio informado está associado ao programa;
- se a fase pertence ao programa;
- se a descrição do registro é obrigatória;
- se o mesmo desafio não registrou duas avaliações para a mesma fase;
- se não é possível registrar avaliação depois que o programa foi finalizado.

Os registros devem ser controlados internamente pelo programa.

### 13. Finalização do programa de desafios

A classe `ProgramaDesafiosInovacao` deve possuir um método:

```csharp
Finalizar()
```

Esse método deve verificar todas as invariantes necessárias antes de alterar o estado do programa para finalizado.

O programa só pode ser finalizado se:

- possuir estudante coordenador válido;
- possuir professor responsável válido;
- possuir ambiente institucional válido;
- possuir pelo menos um desafio submetido;
- possuir pelo menos uma fase obrigatória;
- todas as fases obrigatórias tiverem registro de avaliação;
- não houver desafio duplicado;
- não houver avaliador convidado duplicado;
- não houver recurso institucional duplicado;
- não houver fase duplicada;
- o coordenador não for responsável principal por desafio submetido no mesmo programa;
- o professor colaborador, se existir, for diferente do professor responsável.

Depois de finalizado, o programa não pode mais receber novos desafios, novos avaliadores, novos recursos, novas fases ou novos registros de avaliação.

### 14. Cálculo do percentual de fases aprovadas

A classe `ProgramaDesafiosInovacao` deve permitir consultar o percentual de fases aprovadas.

O percentual deve considerar as fases que receberam pelo menos um registro marcado como aprovado.

A consulta do percentual só deve ser permitida se o programa estiver finalizado.

Caso o percentual seja solicitado antes da finalização, uma exceção deve ser lançada.

Exemplo conceitual:

- 5 fases cadastradas;
- 4 fases com pelo menos um registro aprovado;
- percentual de fases aprovadas: 80%.

### 15. Demonstração obrigatória

Crie um pequeno trecho de código de demonstração, em `Program.cs`, que mostre:

1. criação de estudante coordenador, professor responsável, ambiente institucional, desafios submetidos, avaliadores convidados e recursos institucionais;
2. criação de um programa de desafios válido;
3. definição opcional de professor colaborador;
4. adição de desafios submetidos;
5. adição de avaliadores convidados;
6. adição de recursos institucionais;
7. adição de fases do desafio;
8. registro de avaliações;
9. finalização do programa;
10. exibição do percentual de fases aprovadas.

Também demonstre pelo menos quatro tentativas inválidas, como:

- definir o professor responsável como professor colaborador;
- adicionar desafio cujo responsável principal é o estudante coordenador;
- adicionar desafio duplicado;
- adicionar avaliador duplicado;
- adicionar recurso duplicado;
- registrar avaliação para desafio que não está associado ao programa;
- registrar avaliação para fase que não pertence ao programa;
- finalizar programa sem avaliação em fase obrigatória;
- adicionar fase depois do programa finalizado;
- criar objeto com texto obrigatório vazio;
- remover avaliador que não está associado ao programa.

As tentativas inválidas devem ser tratadas com `try/catch`, exibindo mensagens adequadas no console.

## Regras técnicas obrigatórias

A solução deve respeitar os seguintes critérios:

- usar propriedades com `private set` ou somente leitura quando adequado;
- evitar atributos públicos modificáveis diretamente;
- não expor listas internas como `List<T>` pública;
- usar `private readonly List<T>` para coleções internas;
- expor coleções como `IReadOnlyCollection<T>`;
- validar objetos nulos antes de associá-los;
- usar objetos reais em associações, e não apenas dados primitivos;
- distinguir corretamente associação obrigatória e opcional;
- aplicar agregação quando os objetos têm ciclo de vida independente;
- aplicar composição quando o objeto parte pertence ao objeto todo;
- manter as regras de negócio dentro das classes responsáveis;
- impedir que código externo corrompa o estado interno dos objetos;
- garantir que as invariantes permaneçam válidas durante toda a vida do objeto.

## Conhecimentos prévios pressupostos

Esta prova pressupõe que o aluno já domina:

- criação de classes;
- atributos e métodos;
- construtores;
- encapsulamento;
- validação de dados;
- uso de exceções;
- listas em C#;
- propriedades;
- tipos nullable;
- métodos com parâmetros;
- instanciação de objetos;
- fundamentos de orientação a objetos.

## Critérios de avaliação

| Critério | Pontuação |
|---|---:|
| Modelagem correta das classes e responsabilidades | 20 |
| Uso adequado de associações 1:1 e 1:N | 15 |
| Diferenciação entre associação obrigatória e opcional | 10 |
| Encapsulamento das coleções com `private readonly List<T>` e `IReadOnlyCollection<T>` | 10 |
| Proteção de invariantes e validações de domínio | 15 |
| Aplicação correta de agregação e composição | 15 |
| Clareza, organização e legibilidade do código | 10 |
| Demonstração funcional no `Program.cs` | 5 |
| **Total** | **100** |

## Observação final

A solução não deve ser apenas um conjunto de classes com atributos. Ela deve representar um modelo orientado a objetos consistente, no qual os objetos colaboram entre si, as associações expressam relações reais do domínio e as regras de negócio impedem estados inválidos ao longo de toda a execução do sistema.
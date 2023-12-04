# Visão Geral

A classe UnitOfWork é um componente que facilita a interação com um banco de dados por meio do padrão Unit of Work. Ela encapsula o acesso ao banco de dados e gerencia a criação de repositórios específicos para cada tipo de entidade. Além disso, fornece métodos para salvar alterações de forma assíncrona e liberar recursos adequadamente.

# Construtor

```csharp
public UnitOfWork(DbContextOptions<AppDbContext> options)
```

* Parâmetros:
    * options: Opções para configurar o contexto do banco de dados.

* Descrição:
    * Inicializa uma nova instância da classe UnitOfWork com base nas opções fornecidas.

# Métodos Públicos

```csharp
public IRepository<T> GetRepository<T>() where T : class
```

# GetRepository<T>()

    * Parâmetros de Tipo:
        * 'T' é o tipo da entidade para a qual o repositório é recuperado

    * Retorno:
        * Uma instância de IRepository<T>

    * Descrição:
        * Obtém um repositório para o tipo de entidade especificado. Se o repositório já existir, retorna o existente; caso contrário, cria uma nova instância.

* SaveChangesAsync()

    * Parâmetros de Tipo: 
        * Não tem.

    * Retorno:
        * Uma tarefa que representa a operação assíncrona com o número de linhas afetadas.

    * Descrição:
        * Salva assincronamente todas as alterações feitas no contexto no banco de dados subjacente.

# Dispose() 

```csharp
public void Dispose()
```
    * Parêmetro de Tipo: 
        * Não tem.

    * Retorno: 
        * Não tem.

    Descrição:
        * Libera os recursos usados pela instância da classe UnitOfWork.

# Propriedades Privadas

```csharp
private readonly DbContext _context;
private Dictionary<Type, object> _repositories;
```

    * Parâmetro de Tipo:
        * Não tem.

    * Retorno:
        * Não tem.

    * Descrição: 
        * _context: O contexto do banco de dados utilizado para interações com o banco de dados.

        * _repositories: Um dicionário para armazenar instâncias de repositórios específicos por tipo de entidade.

A classe UnitOfWork oferece uma abordagem consistente para manipulação de operações no banco de dados, promovendo a coesão e reutilização de código por meio do padrão Unit of Work e Repository. Essa estrutura facilita a manutenção e expansão de aplicações que requerem interações com banco de dados de forma organizada e eficiente.

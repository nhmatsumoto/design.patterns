# Visão Geral

A classe UnitOfWork é um componente que facilita a interação com um banco de dados por meio do padrão Unit of Work. Ela encapsula o acesso ao banco de dados e gerencia a criação de repositórios específicos para cada tipo de entidade. Além disso, fornece métodos para salvar alterações de forma assíncrona e liberar recursos adequadamente.

____

# Construtor

```csharp
public UnitOfWork(DbContextOptions<AppDbContext> options)
```

* Parâmetros:
    * options: Opções para configurar o contexto do banco de dados.

* Descrição:
    * Inicializa uma nova instância da classe UnitOfWork com base nas opções fornecidas.
____

# Métodos Públicos

```csharp
public IRepository<T> GetRepository<T>() where T : class
```
____

# GetRepository<T>()

* Parâmetros de Tipo:
    * 'T' é o tipo da entidade para a qual o repositório é recuperado

* Retorno:
    * Uma instância de IRepository<T>

* Descrição:
    * Obtém um repositório para o tipo de entidade especificado. Se o repositório já existir, retorna o existente; caso contrário, cria uma nova instância.
____

# SaveChangesAsync()

* Retorno:
    * Uma tarefa que representa a operação assíncrona com o número de linhas afetadas.

* Descrição:
    * Salva assincronamente todas as alterações feitas no contexto no banco de dados subjacente.
____

# Dispose() 

```csharp
public void Dispose()
```

* Descrição:
    * Libera os recursos usados pela instância da classe UnitOfWork.

____

# Propriedades Privadas

```csharp
private readonly DbContext _context;
private Dictionary<Type, object> _repositories;
```

* Descrição: 
    * _context: 
        * O contexto do banco de dados utilizado para interações com o banco de dados.

    * _repositories: 
        * Um dicionário para armazenar instâncias de repositórios específicos por tipo de entidade.

____

# Dependência de Injeção (DI)

A classe UnitOfWork é projetada para ser usada em conjunto com a Injeção de Dependência (DI) para garantir uma gestão eficiente de recursos e uma abordagem modular na configuração da aplicação.

# Configuração da Injeção de Dependência

No arquivo Bootstrap.cs, configure a injeção de dependência para a interface IUnitOfWork e outros serviços relacionados.

```csharp
public static class Bootstrap {
    public static void RegisterAppServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryDatabase"));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<WeatherForecastController>();
    }
}
```


A classe UnitOfWork oferece uma abordagem consistente para manipulação de operações no banco de dados, promovendo a coesão e reutilização de código por meio do padrão Unit of Work e Repository. Essa estrutura facilita a manutenção e expansão de aplicações que requerem interações com banco de dados de forma organizada e eficiente.

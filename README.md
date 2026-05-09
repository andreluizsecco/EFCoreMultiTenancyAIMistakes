# Cenário 2

### Prompts utilizados para criação de uma aplicação multi-tenancy com ASP.NET Core e EF Core:

> Crie uma aplicação ASP.NET Web API (sem Minimal APIs) utilizando Entity Framework Core InMemory onde exista uma entidade Product com Id, Name, Price e TenantId (Guid), sendo que Product deve implementar a interface ITenantOwner que define a propriedade Guid TenantId, implemente um DbContext que no OnModelCreating aplique dinamicamente Global Query Filters para todas as entidades que implementam ITenantOwner filtrando pelo TenantId obtido do token JWT, crie uma classe UserContext (IUserContext) com método GetTenantId() que extraia o claim "tenantId" do JWT presente na request atual, configure autenticação JWT Bearer apenas para validação (sem geração de token nem login), utilizando algoritmo HS256 e a secret "a-string-secret-at-least-256-bits-long", desabilitando a validação de expiração do token, crie um ProductsController com [Authorize] contendo endpoints POST para criação de produto e GET para listagem de produtos (respeitando automaticamente o filtro por tenant), garantindo retorno 401 para tokens inválidos, considerando que o JWT possui payload com claim "tenantId" que deve ser usado como TenantId.

> Use sqlite ao invés de inmemory

# Cenário 1

### Prompts utilizados para criação de uma aplicação multi-tenancy com ASP.NET Core e EF Core:

> Crie uma aplicação ASP.NET Web API utilizando Entity Framework Core InMemory MultiTenancy onde exista uma entidade Product. Faça com que as entidades filtrem automaticamente por tenantId que estará no meu JWT. Configure autenticação JWT Bearer apenas para validação (sem geração de token nem login), utilizando algoritmo HS256 e a secret "a-string-secret-at-least-256-bits-long", desabilitando a validação de expiração do token, crie um ProductsController contendo endpoints POST para criação de produto e GET para listagem de produtos. Faça do zero, sem se basear em outras branches

> Quero que todas as minhas classes que contenham TenantId sejam filtradas automaticamente no DbContext

> Use sqlite ao invés de inmemory


# Projeto Demonstração de Clean Architecture em .Net Core 

**Nomenclatura de Classes**
- Solution: CleanArch
- CleanArch.Domain - Entidades do domínio da app
- CleanArch.Application - Interfaces, serviços, regras de negócio
- CleanArch.Infra.Data - Responsável pelo acesso aos dados
- CleanArch.Infra.IoC - Centralizar a injeção de dependência
- CleanArch.MVC - Define a interface com o usuário

**Dependências de Projetos**

- CleanArch.Domain - (Não depende de ninguém)
- CleanArch.Application - Domain
- CleanArch.Infra.Data - Domain
- CleanArch.Infra.IoC - Domain, Application, Infra.Data
- CleanArch.MVC - Infra.Data, Infra.IoC

# Execução

**ConnectionStyring**
"DefaultConnection": "Data Source=localhost;Initial Catalog=CleanArchDemo;Integrated Security=True"

**Executa a Migração**

    add-migration Inicial -Context ApplicationDbContext

    update-database

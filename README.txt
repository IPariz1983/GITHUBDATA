# GitHubRepoApp

Este projeto é uma API REST para sincronizar e consultar repositórios do GitHub.

## Pré-requisitos

*   .NET SDK 8.0 ou superior
*   PostgreSQL instalado e em execução
*   Um editor de código (ex: Visual Studio, VS Code, Rider)

## Configuração

1.  **Clone o repositório:**

    ```bash
    git clone [URL inválido removido]
    cd GitHubRepoApp
    ```

2.  **Configuração do banco de dados:**

    *   Altere o arquivo `appsettings.Development.json` (ou  crie um para`appsettings.json` para produção) no projeto `GitHubRepoApp.API` com a string de conexão para o PostgreSQL:

    json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=nome_do_seu_banco;User Id=seu_usuario;Password=sua_senha;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

    *   **Importante:** Substitua os seguintes valores:
        *   `nome_do_seu_banco`: Nome do banco de dados que você deseja criar.
        *   `seu_usuario`: Nome do usuário do PostgreSQL.
        *   `sua_senha`: Senha do usuário do PostgreSQL.
        *   **Segurança:** Em produção, use variáveis de ambiente ou um gerenciador de segredos (ex: Azure Key Vault) para armazenar a senha.

3.  **Restaure as dependências NuGet:**

    No diretório raiz do projeto (onde está o arquivo `.sln`), execute:

    
    dotnet restore
    
	
4.  **Aplique as Migrações do Entity Framework Core:**

    *   Navegue até o diretório do projeto `GitHubRepoApp.Infrastructure`:

    
    cd GitHubRepoApp.Infrastructure
    

    *   Execute o comando para criar o banco de dados e as tabelas:

    
    dotnet ef database update
    

    Este comando criará o banco de dados (se ele não existir) e aplicará as migrações para criar as tabelas necessárias.

5.  **Configure as variáveis de ambiente (opcional, mas recomendado para produção):**

    Configure as variáveis de ambiente necessárias para o seu ambiente de produção. Isso pode incluir a string de conexão do banco de dados, chaves de API e outras configurações confidenciais.

## Execução

1.  **Navegue até o diretório do projeto API:**

    ```bash
    cd GitHubRepoApp
    ```

2.  **Execute a aplicação:**

  
    dotnet run
    

    A API estará disponível em `https://localhost:7032`.

## Endpoints da API

*   **POST /repos/sync/{username}**: Sincroniza os repositórios do usuário do GitHub especificado com o banco de dados.
*   **GET /repos?username={username}**: Retorna os repositórios do usuário especificado, ordenados por número de estrelas (decrescente).

3. Para rodar a API localmente configure o arquivo Appsettings.Development.json #NOME_DA_SUA_BASE para executar via docker tenha as dependencias do docker instalados na maquina local 
e subtitua a #NOME_DA_SUA_BASE por github_repo_app_db
{
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=#NOME_DA_SUA_BASE;User Id=seu_usuario;Password=sua_senha;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }



## Licença

MIT License

Copyright (c) 202 Israel Ferreira Pariz

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
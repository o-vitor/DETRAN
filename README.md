# Testar a aplicação 

## Banco de dados

  1. Criar o banco de dados e o usuário de teste: executar o script 'script-banco.sql' no SQL Server

## Rodar a API: 

  1. Abrir a solução Detran.CNH;
  2. Marcar o projeto Detran.CNH.API para ser inicializado ('*Set as Startup Project*');
  3. Configurar a string de conexão do banco de dados no arquivo **appsettings.Development.json**:
	item "DetranCNHDbContextConnectionString", sob o item "ConnectionStrings";
	
  4. Iniciar execução do projeto Detran.CNH.API. O projeto está configurado para, ao iniciar, abrir a página do Swagger em um navegador de Internet.
	Nessa página é possível se autenticar e testar os *endpoints*.
	
## Rodar o *front-end*:

  1. Rodar o comando:
  ```
    npm install
  ```	
  2. Rodar o comando:
  ```
    ng serve
  ```

  3. Em um navegador de Internet ir para o endereço:
  ```
    http://localhost:4200/
  ```
## Lista de bibliotecas/*frameworks* utilizados

- .NET Core versão 3.1
-	Entity Framework Core
-	AutoMapper
-	Swagger

### Angular versão 12.1.1
-	Material UI
-	PrimeNG
-	Toastr
-	Fontawesome
-	Bootstrap

## Arquitetura

São empregados os padrões DDD e MVVM.

![Arquitetura](https://i.ibb.co/Ht745xq/Arquitetura.png)

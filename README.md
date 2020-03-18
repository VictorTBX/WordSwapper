# WordSwapper

Intruções para execução do projeto:

- Abrir projeto no Visual Studio (necessário .NET Core 3.0 instalado)
- Debugar o projeto através do comando F5 ou selecionar o projeto "LottoCap" no *SolutionExplorer > Debug > Start new instance*
- Uma página web com o Swagger da aplicação será aberto

Instruções para executar os testes:

- Navegar na barra superior em *Test > Run all tests*

Considerações da aplicação:

- Utilizei um modelo simples, sem adicionar muitas camadas desnecessárias para uma aplicação que possui apenas um endpoint. Gosto muito da ideologia do KISS (Keep it simple, stupid!).

- As models foram divididas em request e reponse.

- Através dos nomes dos testes é possível compreender quais lógicas utilizei para contruir a aplicação. Explicando o caso mais complexo, que é quando as palavra diferem em tamanho e uma não contém a outra: primeiro o programa tenta encontrar uma subpalavra que esteja contida na palavra menor e, a partir disso, calcula quantas alterações são necessárias nas bordas. Testei todos os casos de borda dos quais me recordei.

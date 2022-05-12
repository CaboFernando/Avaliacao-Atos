# Avaliacao-Atos
Teste Técnico

- Esse código fonte tem como objetovo medir o nível técnico em desenvolvimento

- A estrutura da Web API ficou completa, com os endpoints de Users e Calculo, no modelo RESTFul usando os verbos http.

- Minha intenção era criar usar um userDefault para realizar um login autenticando com Jwt e então redirecionar para tela de cálculo do CDB, mas tive alguns provelmas com @Injectable() e então resolvi fazer só o básico.

- O Back WebApi segue o padrão Rest, então pode ser consumida usando PostMan ou a ferramenta integrada Swagger.

- O Front Angular foi feito com ng create componentes, e é bem simples. Ao rodar vai ter uma mensagem padrão e é possível ver a aba "Calculo". Acessando-o é possível realizar as etapas conforme solicitado no documento.

- A parte de documentação fica atribuído também ao Swagger incluido no projeto.

- Caso tenha o interesse de testar os outros endpoints e a persistência no banco de dados, foi utilizado o migration com EF core, e para criação da base de dados basta rodar os comandos no Package Manager Console:
  * Add-Migration firstMigration
  * Update-database

- Os unit tests do back foram feitos em xunit e todos foram aprovados.

- SonarAnalyzer.CSharp foi adicionado pelo nuGet, em todos os projetos da solução.

- Infelizmente não consegui realizar os teste do front pois me falta conhecimento nessa área.


No mais é isso, espero que gostem do meu teste.

Att-
Carlos F. Santos.

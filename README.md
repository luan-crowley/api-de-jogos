# API de Jogos
API de cadastro de jogos desenvolvida em C# com ASP.NET Core e .NET 10, como projeto de estudo de desenvolvimento back-end. Permite cadastrar e listar jogos com ID, nome e gênero, além de rejeitar cadastros com IDs repetidos.

Os dados são armazenados temporariamente em uma lista na memória, sem banco de dados, e são perdidos quando a aplicação é encerrada ou reiniciada.

================================================================

## Como executar

É necessário ter o SDK do .NET 10 instalado.

1. Abra o terminal na pasta que contém o arquivo `.csproj`.
2. Execute:

```bash
dotnet run
```

3. Confira o endereço exibido após `Now listening on:`.
4. Acesse esse endereço no navegador, acrescentando `/jogos`.

Exemplo: se o endereço exibido for `http://localhost:5173`,
acesse `http://localhost:5173/jogos`.

Na primeira execução, a resposta será `[]`, pois ainda não há jogos cadastrados.

==================================================================

## Como testar

Com a API rodando, abra outro terminal Bash e execute:

```bash
curl -i -X POST http://localhost:5173/jogos -H "Content-Type: application/json" -d '{"id":1,"nome":"Forza Horizon","genero":"Corrida"}'
```

Ajuste a porta se a aplicação estiver usando outra.

- No primeiro cadastro, a resposta esperada é `200 OK`, com os dados do jogo.
- Ao repetir o comando com o mesmo ID, a resposta esperada é `409 Conflict`, com uma mensagem informando que o ID já existe.
- Para consultar a lista, acesse `/jogos` no navegador, sem reiniciar a API.

==================================================================

## Endpoints

| Método | Rota | Função |
|---|---|---|
| GET | `/jogos` | Lista os jogos cadastrados |
| GET | `/jogos/status` | Retorna uma mensagem indicando que a API está funcionando |
| POST | `/jogos` | Cadastra um jogo e rejeita IDs repetidos |
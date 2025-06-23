# RabbitMQ Hello World

Este repositório contém um exemplo simples de aplicações console em .NET para demonstrar o envio e recebimento de mensagens usando o RabbitMQ.

As pastas **Send** e **Receive** possuem projetos independentes que publicam e consomem mensagens da fila `hello`.

## Pré-requisitos

- .NET SDK instalado (versão 5 ou superior).
- RabbitMQ executando localmente (localhost) na porta padrão.

## Como compilar e executar

Abra dois terminais, um para cada aplicação:

### 1. Executar o consumidor
```bash
cd Receive
 dotnet run
```
O programa ficará aguardando mensagens.

### 2. Enviar uma mensagem
Em outro terminal, execute:
```bash
cd Send
 dotnet run
```
Você deve ver no terminal do `Receive` que a mensagem "Hello World" foi recebida.



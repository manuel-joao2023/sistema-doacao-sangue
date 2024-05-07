# Sistema de Doação de Sangue

O Sistema de Doação de Sangue é uma aplicação desenvolvida para facilitar a coordenação e gestão de doações de sangue entre doadores, particulares e campanhas de doação. Este sistema permite o registro de doadores, solicitações de sangue e campanhas de doação.

## Arquitetura da Aplicação

Este sistema consiste em duas aplicações distintas:

### Back-end Web API (C#)

O back-end é desenvolvido em C# e consiste em uma API RESTful que lida com a lógica de negócios, interage com o banco de dados e fornece serviços para o front-end.

### Front-end (.NET MAUI)

O front-end é desenvolvido com .NET MAUI, fornecendo uma interface de usuário moderna e responsiva para os usuários interagirem com o sistema.


## Funcionalidades

- Cadastro e gerenciamento de doadores de sangue.
- Registro e acompanhamento de solicitações de sangue feitas por particulares ou instituições.
- Criação e gestão de campanhas de doação de sangue.
- Associação de doadores a hospitais para futuras doações.
- Suporte a diferentes tipos sanguíneos.

## Classes Principais

### Person

Representa uma pessoa, com informações básicas como nome, idade, telefone e endereço.
![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/5f592985-53d2-4bbf-996f-69545fef9561)

### Address

Representa o endereço de uma pessoa ou instituição (hospital).
![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/8d62c192-89b8-4b86-985a-7a173fcf6043)

### Campaign

Representa uma campanha de doação de sangue, contendo informações como nome, descrição, data de início e término, organizador.

### Request

Representa uma solicitação de sangue feita por um particular ou instituição, incluindo informações como solicitante, data da solicitação, tipo sanguíneo e quantidade requerida. Pode ainda registar uma gratificação para o doador.

### Donator

Representa um doador de sangue, mantendo informações como última data de doação e disponibilidade para doação.

### DonatorHospital

Associa um doador a um hospital para futuras doações.

### HospitalRequest

Associa uma solicitação de sangue a um hospital.

### Support

Representa os dados de apoios ao sistema, como paises, provincias, municipios, grupos sanguineos e outros.

### User

Representa um usuário do sistema, com informações como nome de usuário, senha, e-telefone e tipo de usuário.

## Requisitos do Sistema

- C# 7.0
- Banco de dados Postgresql
- MAUI

## Como Configurar e Executar

1. Clone o repositório para sua máquina local:
  
2. Verifique se tem instalado o postgresql

3. Abra o projeto em sua IDE preferida.

4. Configure as informações de conexão com o banco de dados no arquivo `appsettings.json`.

5. Compile o projeto e execute a aplicação.

6. Acesse a aplicação através do navegador usando o endereço local, geralmente `http://localhost:8080`.

## Contribuindo

Contribuições são bem-vindas! Sinta-se à vontade para propor melhorias, reportar problemas ou enviar solicitações de pull.

## Licença

Este projeto é distribuído sob a licença GPL v3. Consulte o arquivo `LICENSE` para mais informações.

# Sistema de Doação de Sangue

O Sistema de Doação de Sangue é uma aplicação desenvolvida para facilitar a coordenação e gestão de doações de sangue entre doadores, particulares e campanhas de doação. Este sistema permite o registro de doadores, solicitações de sangue e campanhas de doação.

## Como foi pensado a aplicação
A aplicação foi pensada e extruturada da seguinte maneira :

1. A aplicação não estara direitamente conectada a um hospital ou instituição
2. A solicitação será feita por `particulares` e `instituições`
3. As solicitações devem ter uma particularidades para casos `emergentes`, não haverá necessidade de se logar na aplicação
4. A campanha é feita apenas por instituições
5. Durante o registo dos doadores, deve ser informado os hospitais proximos das suas residencias
6. As notificações serão enviadas aos doadores que moram proximos aos hospitais que se fara a doação
7. Durante a solicitação pode ser informado uma `gratificação`, que será entregue ao doador pela sua doação
8. Outros pontos irão surgir e serão acrescentados mediante um dialogo aberto.

## Arquitetura da Aplicação

Este sistema consiste em três aplicações distintas em uma primeira fase:

### Back-end Web API (C#)

O back-end é desenvolvido em C# e consiste em uma API RESTful que lida com a lógica de negócios, interage com o banco de dados e fornece serviços para o front-end.

### Front-end (.NET MAUI)

O front-end é desenvolvido com .NET MAUI, fornecendo uma interface mobile moderna e responsiva para os usuários interagirem com o sistema.

### Front-end (Blazor)

O front-end é desenvolvido com Blazor, fornecendo uma interface web moderna e responsiva para os usuários interagirem com o sistema.

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

![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/160427fc-9d93-41a7-9ed4-ac46a3c789dc)

### Request

Representa uma solicitação de sangue feita por um particular ou instituição, incluindo informações como solicitante, data da solicitação, tipo sanguíneo e quantidade requerida. Pode ainda registar uma gratificação para o doador.

![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/52ee7f63-3500-4f2b-a930-5c1fad422334)


### Donator

Representa um doador de sangue, mantendo informações como última data de doação e disponibilidade para doação.
![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/b753a105-fe48-4544-b2b0-12a2fc829b00)


### DonatorHospital

Associa um doador a um hospital para futuras doações.

![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/6f5d3e44-8746-410f-b678-5119ea1127e0)


### HospitalRequest

Associa uma solicitação de sangue a um hospital.

![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/64e2bbea-4ff2-48c2-a927-43df0efd9ec2)


### Support

Representa os dados de apoios ao sistema, como paises, provincias, municipios, grupos sanguineos e outros.

![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/b50112e3-e91b-479a-b9c0-128fa4392b45)

Abaixo um exemplo de como a tabela de support é usada:

![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/4c27b60c-acd9-44ba-9a26-103c35652ef9)

### User

Representa um usuário do sistema, com informações como nome de usuário, senha, e-telefone e tipo de usuário.

![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/48cbb9a9-dbde-430b-87ad-c6937a0836dd)

## Diagrama

![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/ac9ff34e-d6c0-406e-8e83-238a3c99e914)

## Endpoit

### Campaign
![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/b45384e6-d07e-4573-988f-e56e2d683cef)

### Donator
![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/b7a8c6bd-f1db-4b7b-8422-21c74d0f7f88)

### Requests
![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/2fa7a5ad-25c3-4a32-afcc-5ac82a156ecb)

### Supports
![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/19d832ad-4cee-4a6b-9e55-8a164d0181b9)

### Users
![image](https://github.com/manuel-joao2023/sistema-doacao-sangue/assets/134264511/6c559a53-e96a-415e-a643-1b85abf21945)


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

<h1 align="center">Vehicle Reservation</h1>

<div align="center">

  [Projeto](#projeto) 
  &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  [Tecnologias](#tecnologias)
  &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  [Como executar](#como_executar)
  &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  [Endpoints](#endpoints)
  &nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;
  [Licença](#license)

</div>

<p align="center">
  <img alt="License" src="https://img.shields.io/static/v1?label=license&message=MIT&color=49AA26&labelColor=000000">
</p>

<br>

## 💻 Projeto <a name = "projeto"></a>

O Vehicle Reservation é um sistema de gerenciamento de reservas de veículos, criado como parte da disciplina de Verificação e Validação.

### Requisitos

+ Manter veículos:
  - Visualizar qualquer veículo com base nos filtros, como ano, marca e capacidade de passageiros;
  - Cadastrar um veículo com base nas informações dele, como marca, modelo, ano, placa, cor e capacidade de passageiros.
+ Gerenciar reservas:
    - Buscar reserva, o sistema verifica automaticamente se o veículo está disponível no intervalo de tempo solicitado, garantindo que não haja conflitos de reserva;
    - Reservar por um período de tempo.
+ Gerar pagamentos:
    - Criar um pagamento vinculado a reserva, puxando o valor dela e com tipos de pagamento disponiveis;
    - Visualizar os pagamentos criados.

### Obervações

Foi feita a implementação dos testes unitários das entidades Vehicle, Reservation, Payment e dos seus respectivos controllers, também fiz os testes de integração dos controllers com os services usando dados mockados.

Foi usado o Entity Framework Core como ORM para realização da integração com o banco e manipulação do mesmo.

<br>
<br>

## 👨‍💻 Como Executar <a name = "como_executar"></a>

Para executar a API localmente, siga estas etapas:

- Necessário instalar o [SDK do .NET](https://dotnet.microsoft.com/pt-br/download) na versão mais atual (8.x);
- Clonar o repositório para o seu ambiente de desenvolvimento;
- Instalar as dependências necessárias para a execução da API, com o comando ```dotnet restore``` na pasta do projeto, por exemplo o Backend-Vehicle-ReserVation você vai até a pasta dele e executar esse comando;
- Executar a API localmente utilizando o comando ```dotnet run``` ou pela pasta raiz do repositório (solution) ```dotnet run --project Backend-Vehicle-Reservation```.
- Acessar o link que irá aparecer no terminal, como [localhost:5134/swagger](http://localhost:5134/swagger).

Os testes são executado com ```dotnet run --project Backend-Tests-Vehicle-Reservation``` ou ```dotnet test```.

<br>
<br>

## 📌 Endpoints <a name = "como_executar"></a>

### /vehicle/create

Parâmetros:

- Make (string): Marca do veículo.
- Model (string): Modelo do veículo.
- Year (string): Ano do veículo.
- Color (string): Cor do veículo.
- Plate (string): Placa do veículo.
- Passenger Capacity (int): Capacidade de passageiros do veículo.

Cria uma instancia do veículo e registra no banco.

<br>

### /vehicle/getbyfilter

Parâmetros:

- Make (string): Marca do veículo.
- Model (string): Modelo do veículo.
- Year (string): Ano do veículo.
- Color (string): Cor do veículo.
- Plate (string): Placa do veículo.
- Passenger Capacity (int): Capacidade de passageiros do veículo.

Retorna uma lista de veículos selecionados pelo parametros preenchidos.

<br>

### /reservation/create

Parâmetros:

- Vehicle Id (int): Identificador do veículo.
- Start Date (DateTime): Data inicial da reserva.
- End Date (DateTime): Data final da reserva.

Cria uma instancia de uma reserva e registra no banco.

<br>

### /reservation/getbyfilter

Parâmetros:

- Reservation Id (int): Identificador da reserva.
- Vehicle Id (int): Identificador do veículo.
- Start Date (DateTime): Data inicial da reserva.
- End Date (DateTime): Data final da reserva.

Retorna uma lista de reservas selecionados pelo parametros preenchidos.

<br>

### /payment/create

Parâmetros:

- Reservation ID (int): Identificador da reserva.
- Type (string): Tipo de pagamento, apenas "boleto", "cartao_credito" ou "cartao_debito".

Cria uma instancia de um pagamento, vincula à uma reserva,atualiza a reserva e registra no banco.

<br>

### /payment/getbyfilter

Parâmetros:

- Reservation ID (int): Identificador da reserva.
- Value (double): valor da reserva.
- Type (string): Tipo de pagamento, apenas "boleto", "cartao_credito" ou "cartao_debito".

Retorna uma lista de pagamentos selecionados pelo parametros preenchidos.


<br>
<br>

## 🚀 Tecnologias <a name = "tecnologias"></a>

- .NET v8.x
- ASP.NET Core 
- OpenAPI (Swagger)
- xUnit
- Entity Framework Core
- Postgres
- Railway

<br>
<br>

##  🔒 Licença

Esse projeto está sob a licença MIT.

<hr>

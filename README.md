# DIO - Trilha .NET - Fundamentos
www.dio.me

## Desafio de projeto
O projeto de Sistema de Estacionamento é uma implementação simples de um sistema de estacionamento em C#. Ele fornece funcionalidades básicas para cadastrar, remover e listar veículos, além de realizar verificações relacionadas ao horário de funcionamento e à validação de placas.
O Sistema foi criado a partir da análise de um sistema real de estacionamento, seguindo as seguintes ideias:
1. O horário de funcionamento do Estacionamento é limitado (7h às 20h).
2. O estacionamento possui vagas para moto e vagas para carro, sendo diferente a quantidade de vagas para os respectivos veículos.
3. O valor total a ser pago é calculado pelo próprio sistema custando R$10 a primeira hora e sendo cobrado R$5 pela hora adicional.

Para este desafio foram utilizados os conhecimentos adquiridos na trilha .NET da DIO.

## Contexto
Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta
O Sistema de Estacionamento foi atualizado seguindo o diagrama abaixo:
![Diagrama de sistema estacionamento](https://github.com/samahraOliveira/trilha-net-fundamentos-desafio/blob/main/Diagrama%20UML.jpeg?raw=true)

A classe principal contém 4 propriedades: Preço Inicial, Preço por Hora, Veículos Carro (lista) e Veículos Moto (lista).
Os métodos implementados são os seguintes:
#### Cadastrar Veículo
O método CadastrarVeiculo() permite ao usuário cadastrar um veículo no estacionamento. Ele verifica se o estacionamento está aberto, se há vagas disponíveis e valida a placa do veículo.
#### Remover Veículo
O método RemoverVeiculo() remove um veículo do estacionamento. Calcula o tempo total de estacionamento e o valor a ser pago com base no horário de entrada.
#### Listar Veículos
O método ListarVeiculos() exibe a lista de veículos estacionados no momento.
#### Verificar Estacionamento Aberto
O método VerificarEstacionamentoAberto() verifica se o estacionamento está aberto com base no horário atual.
#### Validar Placa
O método ValidarPlaca() utiliza a classe ValidacaoPlaca para validar o formato da placa do veículo.
#### Identificar Tipo de Veículo
O método IdentificarTipoVeiculo() solicita ao usuário que informe se o veículo a ser estacionado é um carro ou moto.

## Requisitos
- Plataforma: .NET Core 3.1 ou superior
- Ambiente de Desenvolvimento: Visual Studio, Visual Studio Code ou qualquer IDE que suporte C#.

## Contribuições
Constribuições são muito bem-vindas. Sinta-se a vontade pra opinar e fazer sugestões.




# ContaCorrente

## Projeto

Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2024

---
## Detalhes

Uma conta corrente possui um número, um saldo, um status que informa se ela é especial ou não, um limite e um histórico de movimentações. Uma movimentação possui um valor e uma informação se ela é uma movimentação de crédito ou débito.

Cada conta terá operações de saques, depósitos, visualização de saldo, visualização de extrato e transferência entre contas.

Cada conta vai ter o nome, o sobrenome e cpf do cliente dono da conta.

Uma conta corrente só pode fazer saques desde que o valor não exceda o limite de saque que é o limite + saldo.

---
## Funcionalidades

TBD

---
## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.
---
## Como Usar

#### Clone o Repositório
```
git clone https://github.com/academia-do-programador/ContaCorrente.git
```

#### Navegue até a pasta raiz da solução
```
cd ContaCorrente
```

#### Restaure as dependências
```
dotnet restore
```

#### Navegue até a pasta do projeto
```
cd ContaCorrente.ConsoleApp
```

#### Execute o projeto
```
dotnet run
```

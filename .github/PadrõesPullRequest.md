# Padrão Pull Request

## Padrão de Título na Pull Request

Quando você executa um "Squash and Merge" dentro do GitHub por exemplo, é o título da sua pull request que fica como commit
principal e dentro da mensagem do commit ficam os outros commits. 
Então um padrão bem interessante é seguir a mesma ideia da convenção, com alguns upgrades:

### Padrão:
[<id-da-sua-tarefa>] tipo(escopo): descriçao

### Exemplo:
[TL-100] feat(posts): creating hook to integrate with posts API

Com esse título já da para ter uma ideia do que rolou por cima e também acesso fácil ao identificador da tarefa, 
onde possívelmente terá mais detalhes sobre aquele recurso.

## Fazer Uma Boa Descrição na Pull Request
Eu sei que escrever a parte técnica pode ser muito chato as vezes, mas é parte do trabalho do dia a dia de um dev. 
Esse é o padrão que adaptei de um outro já existente e tem funcionado bem no meu dia a dia:

#### Explicando:

1. Tipo da alteração, se é bug fix, feature, chore ou uma release (para o caso de fazer releases com alguma branch que não é a "main")
2. Descrição com mais detalhes, principalmente se esse recurso altera pontos fundamentais do sistema. Pontos esses que nós precisaremos lembrar no futuro, uma vez que não podemos confiar em nossas memórias.
3. Se for possível e fizer sentido, capturas de telas que explicam melhor o recurso.
4. Os links para as tarefas na aplicação que gerencia as estórias e tarefas.
5. Checklist básico para subir uma PR.
6. Outras pull requests que são dependentes, por exemplo: alguma pull request com uma API do backend que é necessária estar entregue antes de subir uma tela no frontend.
   

_Mais informações: [Organizar pull request](https://www.tabnews.com.br/guscsales/uma-maneira-de-organizar-suas-branches-commits-e-pull-requests)_

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
Nem sempre faremos só coisas legais. Juntando o título no qual já tem o link para a estória, 
onde ficam as descrições de regras de negócio, adicionado um breve resumo do escopo no título e mais os 
detalhes técnicos na descrição seguido de um screenshot da tela (se possível) 
é um prato cheio para conseguir mitigar problemas e resolve-los rapidamente sem ficar se perdendo no meio do caminho.

Esse é o padrão que adaptei de um outro já existente e tem funcionado bem no meu dia a dia:

## Type of change

- [ ] Bug fix (non-breaking change which fixes an issue)
- [ ] New feature (non-breaking change which adds functionality)
- [ ] Chore (documentation, packages, or tests updates, nothing that affect the final user directly)
- [ ] Release (new version of the application - only for production)

## Description

...

## Screenshots

...

## Tasks

- [task-id](task-link) or N/A

## Checklist

- [ ] My changes have less than or equal 400 lines
- [ ] I have performed a self-review of my own code
- [ ] The existing tests and linter pass locally with my changes
- [ ] I have commented my code in hard-to-understand areas (if applicable)
- [ ] I have created tests for my fix or feature (if applicable)

## Dependencies

This pull request has a dependency on the following others:

- link-to-depency PR or N/A
Explicando:

1. Tipo da alteração, se é bug fix, feature, chore ou uma release (para o caso de fazer releases com alguma branch que não é a "main")
2. Descrição com mais detalhes, principalmente se esse recurso altera pontos fundamentais do sistema. Pontos esses que nós precisaremos lembrar no futuro, uma vez que não podemos confiar em nossas memórias
3. Se for possível e fizer sentido, capturas de telas que explicam melhor o recurso
4. Os links para as tarefas na aplicação que gerencia as estórias e tarefas
5. Checklist básico para subir uma PR:

Menos de 400 linhas
Revisão no próprio código antes de abrir PR
Todos os testes existentes passaram
Comentários em lugares necessários foram escritos
Criação de testes para o novo recurso
Eu sei, nem sempre vai dar pra seguir certinho, mas é bom ter um alvo né?

Item 6: Outras pull requests que são dependentes, por exemplo: alguma pull request com uma API do backend que é necessária estar entregue antes de subir uma tela no frontend.
Lembrando que para adicionar padrões de template na pull request você pode utilizar essa forma: criar uma pasta .github na raiz do seu projeto e dentro um arquivo chamado pull_request_template.md com o template acima. Automaticamente o GitHub vai entender isso e abrir as pull requests com esse template.

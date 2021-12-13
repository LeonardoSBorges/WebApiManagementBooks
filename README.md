# BookManagement Web API

Projeto de gestão de livros, ele disponibiliza métodos para criação, deleção, Emprestimo, Retorno e um metodo que chama todos os livros cadastrados.

### Execução:
Para executá-lo, basta cloná-lo a um diretório em sua máquina utilizando o Visual Studio 2022 - 17.0.2.
Por se tratar de uma Api, foi-se utilizado o Swagger para falicitar a visualização e execução dos métodos.


| Método | Descrição |
| ------ | ------ |
| SetCache | Responsável por criar um novo livro no cache, neste método será necessário inserir o valor Title ,exemplo: "title": "CLean Code" logo após executar o livro será inserido no cache e será retornado os livros armazenados no cache. |
| RemoveBook | Responsável por remover um livro do cache, exemplo: "Id" : 1, o livro a ser excluido será o da posição um, só será removido se houver o Id no cache. |
| getAllBooks | Responsável por mostrar todos os livros que estão no cache.|
| UpdateBook | Responsável por atualizar informações dos livros, para utilizalo deverá ser inserido 2 parâmetros que são o Id e o Title de livros existentes no cache. exemplo "id" : 1, "title" : "A Bela e a Fera"|
| LoanBook | Responsável por atualizar o status do livro para Indisponível, os livros são inseridos com status Disponível, que por sua vez está disponível no cache para empréstimo. Ao chamar este método deverá ser inserido o Id do livro que deseja emprestar caso esteja disponivel, exemplo: "Id" = 1. |
| ReturnBook | Responsável por atualizar o status do livro para Disponível, este método sera responsavel por atualizar o valor dos Status do livro de  Indisponível para Disponível e para que isso aconteça deverá ser inserido o Id do livro que deseja retornar caso esteja indisponivel, exemplo: "Id" = 1. |

import os
def exibir_nome_do_app():
    print ('Sabor Express')

restaurantes = [{'nome':'KFC', 'categoria':'FastFood', 'ativo': False},
                 {'nome': 'Subway', 'categoria': 'lanche', 'ativo': True},
                 {'nome':'Belarte', 'categoria':'pizzaria', 'ativo': False}]

def retornar_menu():
    input('\ndigite uma tecla para retornar ao menu principal ')
    main()


def exibir_menu():
    print ('1. Cadastrar restaurante')
    print ('2. Listar restaurante')
    print ('3. ativar restaurante')
    print ('4. Sair\n')

def encerrar_app():
    exibir_subtitulo('Finalizando app ')

def opcao_invalida():
    print('Opção inválida\n')
    retornar_menu()

def exibir_subtitulo(texto):
    os.system('cls')
    print(texto)
    print()


def cadastrar_novo_restaurante():
    exibir_subtitulo('Cadastro de novos restaurantes ')
    nome_do_restaurante = input('Digite o nome do restaurante que deseja cadastrar: \n')
    categoria = input(f'Digite a categoria do {nome_do_restaurante}: \n')
    dados_do_restaurante = {'nome': nome_do_restaurante, 'categoria': categoria, 'ativo': False}
    restaurantes.append(dados_do_restaurante)
    print(f'O restaurante: {nome_do_restaurante} foi cadastrado com sucesso!\n')
    retornar_menu()
   

def listar_restaurante():
    exibir_subtitulo('Listando todos os restaurantes')

    print(f'{'Nome do restaurante'.ljust(22)} | {'Categoria'.ljust(20)} | Status')
    for restaurante in restaurantes:
        nome_restaurante = restaurante['nome']
        categoria = restaurante['categoria']
        ativo = 'ativado' if restaurante['ativo'] else 'desativado'
        print(f'- {nome_restaurante.ljust(20)} | {categoria.ljust(20)} | {ativo} ')
    retornar_menu()
    

def alterar_status_restaurante():
    exibir_subtitulo('Escolha um restaurante que deseja alterar o status')
    nome_restaurante = input('Digite o nome do restaurante que deseja alterar o status: ')
    restaurante_encontrado = False
    for restaurante in restaurantes:
        if nome_restaurante == restaurante['nome']:
            restaurante_encontrado = True
            restaurante['ativo'] = not restaurante['ativo']
            mensagem = f'O restaurante {nome_restaurante} foi ativado com sucesso!' if restaurante['ativo'] else f'O restaurante{nome_restaurante} foi desativado com sucesso!'
            print(mensagem)       
    if not restaurante_encontrado:
        print('O Restaurante não foi encontrado')  
    retornar_menu()


def escolher_opcao():
    try:
        opcao_escolhida = int(input('Escolha uma opção: '))
        print (f'\nVocê escolheu a opção {opcao_escolhida}! ')

        if opcao_escolhida == 1:
            cadastrar_novo_restaurante()
        elif opcao_escolhida == 2:
            listar_restaurante()
        elif opcao_escolhida == 3:
            alterar_status_restaurante()
        elif opcao_escolhida == 4:
            encerrar_app()   
        else:  
            opcao_invalida()
    except:
        opcao_invalida()

def main():
    os.system('cls')
    exibir_nome_do_app()
    exibir_menu()
    escolher_opcao()


if __name__ == '__main__':
    main()

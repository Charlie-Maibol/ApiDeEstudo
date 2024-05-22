import os
def exibir_nome_do_app():
    print ('Sabor Express')

restaurantes = ['KFC', 'Subway' ]

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
    exibir_subtitulo('Cadastro de novos restuarantes ')
    nome_do_restaurante = input('Digite o nome do restaurante que deseja cadastrar: \n')
    restaurantes.append(nome_do_restaurante)
    print(f'O restaurante: {nome_do_restaurante} foi cadastrado com sucesso!\n')
    retornar_menu()
   

def listar_restaurante():
    exibir_subtitulo('Listando todos os restaurantes')

    for restaraunte in restaurantes:
        print(f'.{restaraunte}')
    retornar_menu()
    

def ativar_restaurante():
    print()


def escolher_opcao():
    try:
        opcao_escolhida = int(input('Escolha uma opção: '))
        print (f'\nVocê escolheu a opção {opcao_escolhida}! ')

        if opcao_escolhida == 1:
            cadastrar_novo_restaurante()
        elif opcao_escolhida == 2:
            listar_restaurante()
        elif opcao_escolhida == 3:
            ativar_restaurante()
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

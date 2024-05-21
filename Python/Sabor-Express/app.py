import os
def exibir_nome_do_app():
    print ('Sabor Express')

def exibir_menu():
    print ('1. Cadastrar restaurante')
    print ('2. Listar restaurante')
    print ('3. ativar restaurante')
    print ('4. Sair\n')

def encerrar_app():
    print('Encerrando o app')

def escolher_opcao():
    opcao_escolhida = int(input('Escolha uma opção: '))
    print (f'\nVocê escolheu a opção {opcao_escolhida}! ')

    if opcao_escolhida == 1:
        print('Cadastrar restaurante')
    elif opcao_escolhida == 2:
        print('Listar restaurante')
    elif opcao_escolhida == 3:
        print('ativar restaurante')
    else:  
        encerrar_app()

def main():
    exibir_nome_do_app()
    exibir_menu()
    escolher_opcao()


if __name__ == '__main__':
    main()

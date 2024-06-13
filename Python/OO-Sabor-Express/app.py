from models.restaurant import Restaurant

restaurant_KFC = Restaurant('KFC', 'FastFood')
restaurant_Belarte = Restaurant('Belarte', 'Pizzaria')
restaurant_Kebabs = Restaurant('Kebabs', 'arabe')
restaurant_Belarte.receive_rating('Pokemon', 10 )
restaurant_Belarte.receive_rating('ixidi', 8 )
restaurant_Belarte.receive_rating('Leo', 5 )
restaurant_Belarte.receive_rating('Leo', 2 )

def main():
    Restaurant.restaurant_list()



if __name__ == '__main__':
    main()



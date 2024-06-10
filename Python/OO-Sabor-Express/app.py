from Models.restaurant import Restaurant

resstaurant_KFC = Restaurant('KFC', 'FastFood')
resstaurant_Belarte = Restaurant('Belarte', 'Pizzaria')
resstaurant_Kebabs = Restaurant('Kebabs', 'arabe')

def main():
    Restaurant.restaurant_list()



if __name__ == '__main__':
    main()



from models.restaurant import Restaurant
from models.menu.dishes import Dishes
from models.menu.drink import Drink

restaurant_KFC = Restaurant('KFC', 'FastFood')
restaurant_Belarte = Restaurant('Belarte', 'Pizzaria')
restaurant_Kebabs = Restaurant('Kebabs', 'arabe')
drink_juice = Drink('Suco de melancia', 5.0, 'grande')
dishes_bread = Dishes('Pão frances', 2.00, 'Pão de sal')



def main():
    print(drink_juice)
    print(dishes_bread)



if __name__ == '__main__':
    main()



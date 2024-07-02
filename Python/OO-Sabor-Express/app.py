from models.restaurant import Restaurant
from models.menu.dishes import Dishes
from models.menu.drink import Drink

restaurant_KFC = Restaurant('KFC', 'FastFood')
restaurant_Belarte = Restaurant('Belarte', 'Pizzaria')
restaurant_Kebabs = Restaurant('Kebabs', 'arabe')
drink_juice = Drink('Suco de melancia', 5.0, 'grande')
dishes_bread = Dishes('Pão frances', 2.00, 'Pão de sal')
drink_juice.apply_discount()
dishes_bread.apply_discount()
restaurant_KFC.add_itens_into_menu(drink_juice)
restaurant_KFC.add_itens_into_menu(dishes_bread)


def main():
    restaurant_KFC.show_menu



if __name__ == '__main__':
    main()



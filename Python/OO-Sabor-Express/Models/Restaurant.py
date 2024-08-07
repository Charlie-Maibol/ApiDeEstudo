from models.rating import Rating
from models.menu.menu_itens import Menu_itens

class Restaurant:
    Restaurants = []

    def __init__(self, name, category):
        self._name = name.title()
        self._category = category.upper()
        self._status = False
        self._rating = []
        self._menu = []
        Restaurant.Restaurants.append(self)

    def __str__(self):
        return f'{self.name} | {self.category}'
    
    @classmethod
    def restaurant_list(cls):
        print(f'{'Nome do restaurante'.ljust(25)} | {'Categoria'.ljust(25)} | {'Avaliação'.ljust(25)} |{'Status'}')
        for restaurant in cls.Restaurants:
            print(f'{restaurant._name.ljust(25)} | {restaurant._category.ljust(25)} | {restaurant.rating_media} | {restaurant._status}')



    @property
    def status(self):
        return 'Ativo' if self._status else 'Desativado'

    def change_status(self):
        self._status = not self._status

    def receive_rating(self, client, score):
        if 0 < score <= 5:
            rating = Rating(client, score)
            self._rating.append(rating)
        

    @property  
    def rating_media(self):
        if not self._rating:
            return '-'
        score_sum = sum(rating._score for rating in self._rating)
        score_length = len(self._rating)
        media = round(score_sum / score_length, 1)
        return media
    
    

    def add_itens_into_menu(self, item):
        if isinstance(item, Menu_itens):
            self._menu.append(item)

    @property
    def show_menu(self):
        print(f'Cardapio do restaurante{self._name}\n')
        for i,item in enumerate(self._menu,start=1):
            if hasattr(item,'description'):
                mensage_dish = f'{i}. Nome:{item._name} | Preço: R${item._price} | Descrição: {item.description}'
                print(mensage_dish)
            else:
                mensage_drink = f'{i}. Nome:{item._name} | Preço: R${item._price} | Tamanho: {item.size}'
                print(mensage_drink)
                
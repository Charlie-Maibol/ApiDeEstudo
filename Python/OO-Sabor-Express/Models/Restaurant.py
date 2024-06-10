class Restaurant:
    Restaurants = []

    def __init__(self, name, category):
        self._name = name.title()
        self._category = category.upper()
        self._status = False
        Restaurant.Restaurants.append(self)

    def __str__(self):
        return f'{self.name} | {self.category}'
    
    @classmethod
    def restaurant_list(cls):
        for restaurant in cls.Restaurants:
            print(f'{restaurant._name} | {restaurant._category} | {restaurant._status}')

    @property
    def status(self):
        return 'Ativo' if self._status else 'Desativado'

    def change_status(self):
        self._status = not self._status
        


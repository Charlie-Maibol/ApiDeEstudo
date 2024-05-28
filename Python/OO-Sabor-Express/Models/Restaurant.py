class Restaurant:
    Restaurants = []

    def __init__(self, name, category):
        self.name = name
        self.category = category
        self.status = False
        Restaurant.Restaurants.append(self)

    def __str__(self):
        return f'{self.name} | {self.category}'
    
    def restaurant_list():
        for restaurant in Restaurant.Restaurants:
            print(f'{restaurant.name} | {restaurant.category} | {restaurant.status}')
        

restaurant_KFC = Restaurant('KFC', 'fastfood')
restaurant_Belarte = Restaurant('Belarte', 'pizzaria')

Restaurant.restaurant_list()
class Restaurant:
    name = ''
    category = ''
    status = False

restaurant_KFC = Restaurant()
restaurant_KFC.name = 'KFC'
restaurant_KFC.category = 'Fast food'
restaurant_Belarte = Restaurant()

restaurants = [restaurant_Belarte, restaurant_KFC]
print(vars(restaurant_KFC))
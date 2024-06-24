from models.menu.menu_itens import Menu_itens

class Drink(Menu_itens):

    def __init__(self, name, price, size):
        super().__init__(name, price)
        self.size = size

    def __str__(self):
        return self._name
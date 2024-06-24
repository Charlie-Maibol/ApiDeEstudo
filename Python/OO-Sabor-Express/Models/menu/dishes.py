from models.menu.menu_itens import Menu_itens

class Dishes(Menu_itens):

    def __init__(self, name, price, description):
        super().__init__(name, price)
        self.description = description

    def __str__(self):
        return self._name
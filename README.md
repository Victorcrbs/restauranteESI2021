# restauranteESI2021

ENDPOINTS:

Ingredientes:
http://localhost:5000/api/ingredientes

Pratos:
http://localhost:5000/api/pratos

Receitas:
http://localhost:5000/api/receitas
(GET com parâmetro -> IngredienteId)
ex:

http://localhost:5000/api/receitas/2
[
    {
        "PratoId": 2,
        "IngredienteId": 13,
        "Quantidade": 1.00
    },
    {
        "PratoId": 2,
        "IngredienteId": 14,
        "Quantidade": 1.00
    },
    {
        "PratoId": 2,
        "IngredienteId": 15,
        "Quantidade": 1.00
    }
]

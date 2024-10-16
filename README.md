# Loja de Jogos

### Setup
Na raiz do projeto, executar os seguintes comandos:
```sh
docker-compose build
docker-compose up -d
```

### Swagger
- http://localhost:5090/swagger/index.html

## Exemplo de Payload
```sh
[
    {
      "pedido_id": 1,
      "produtos": [
        {"produto_id": "PS5", "dimensoes": {"altura": 40, "largura": 10, "comprimento": 25}},
        {"produto_id": "Volante", "dimensoes": {"altura": 40, "largura": 30, "comprimento": 30}}
      ]
    },
    {
      "pedido_id": 2,
      "produtos": [
        {"produto_id": "Joystick", "dimensoes": {"altura": 15, "largura": 20, "comprimento": 10}},
        {"produto_id": "Fifa 24", "dimensoes": {"altura": 10, "largura": 30, "comprimento": 10}},
        {"produto_id": "Call of Duty", "dimensoes": {"altura": 30, "largura": 15, "comprimento": 10}}
      ]
    },
    {
      "pedido_id": 3,
      "produtos": [
        {"produto_id": "Kit 10 Fones de Ouvido", "dimensoes": {"altura": 55, "largura": 30, "comprimento": 50}}
      ]
    },
    {
      "pedido_id": 4,
      "produtos": [
        {"produto_id": "Cadeira Gamer", "dimensoes": {"altura": 120, "largura": 60, "comprimento": 70}}
      ]
    }
]
```

# <p align="center">Conhecendo ASP NET Core</p>

# Rotas da aplicação

<br/>

## **Categories**

### **`POST` - /v1/categories**

**Objetivo**: A rota deve ser capaz de criar uma categoria e persistir na memória.

**Formato**: A rota deve receber `title` dentro do corpo da requisição.

**Retorno**: Se bem sucedida, a rota retornará uma resposta do formato abaixo.

```json
{
  "id": "integer",
  "title": "string"
}
```

### **`GET` - /v1/categories**

**Objetivo**: A rota deve ser capaz de listar as categorias salvas.

**Formato**: A rota não requer parâmetros.

**Retorno**: Se bem sucedida, a rota retornará uma resposta do formato abaixo.

```json
[
  {
    "id": "integer",
    "title": "string"
  },
  ...
]
```

## **Products**

### **`POST` - /v1/products/**

**Objetivo**: A rota deve ser capaz de realizar o cadastro de um produto.

**Formato**: A rota deve receber `title`, `description`, `price` e `categoryId` dentro do corpo da requisição no formato abaixo.

**Retorno**: A rota retornará um objeto com as produto salvo no seguinte formato:

```json
{
  "id": "integer",
  "title": "string",
  "description": "st  ring",
  "price": "decimal",
  "categoryId": "integer"
}
```

### **`GET` - /v1/products/**

**Objetivo**: A rota deve ser capaz de listar os produtos salvos.

**Formato**: A rota não espera parâmetros

**Retorno**: A rota retornará uma reposta no seguinte formato:

```json
[
  {
    "id": "integer",
    "title": "string",
    "description": "st  ring",
    "price": "decimal",
    "categoryId": "integer",
    "category": "Category"
  },
  ...
]
```

### **`GET` - /v1/products/categories/`{id:int}`**

**Objetivo**: A rota deve ser capaz de listar os produtos os produtos salvos para uma categoria.

**Formato**: A rota deve receber o id de uma categoria.

**Retorno**: A rota retornará uma reposta no seguinte formato:

```json
[
  {
    "id": "integer",
    "title": "string",
    "description": "st  ring",
    "price": "decimal",
    "categoryId": "integer",
    "category": "Category"
  },
  ...
]
```

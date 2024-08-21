# **Documentação da API: Blog Minimalista**

## **1. Visão Geral**
Esta API oferece funcionalidades básicas para um blog minimalista, permitindo a autenticação de usuários, bem como o gerenciamento e visualização de posts. A API foi projetada com foco na simplicidade e facilidade de uso, oferecendo apenas as operações essenciais para o funcionamento do blog.

## **2. Endpoints Principais**

### **2.1 Autenticação Básica**

#### **POST /api/login**
- **Descrição:** Autentica um usuário e retorna um token de acesso.
- **Requisição:**
  - **Corpo:** `{ "username": "string", "password": "string" }`
- **Resposta:**
  - **200 OK:** `{ "token": "string" }`
  - **401 Unauthorized:** `{ "error": "Invalid credentials" }`

#### **POST /api/logout**
- **Descrição:** Invalida o token de autenticação do usuário.
- **Requisição:** 
  - **Cabeçalho:** `Authorization: Bearer <token>`
- **Resposta:**
  - **200 OK:** `{ "message": "Logged out successfully" }`

### **2.2 Gerenciamento de Posts**

#### **POST /api/posts**
- **Descrição:** Cria um novo post.
- **Requisição:**
  - **Cabeçalho:** `Authorization: Bearer <token>`
  - **Corpo:** `{ "title": "string", "content": "string" }`
- **Resposta:**
  - **201 Created:** `{ "id": "integer", "title": "string", "content": "string", "created_at": "datetime" }`

#### **PUT /api/posts/{id}**
- **Descrição:** Edita um post existente.
- **Requisição:**
  - **Cabeçalho:** `Authorization: Bearer <token>`
  - **Parâmetros de URL:** `id (integer) - ID do post`
  - **Corpo:** `{ "title": "string", "content": "string" }`
- **Resposta:**
  - **200 OK:** `{ "id": "integer", "title": "string", "content": "string", "updated_at": "datetime" }`
  - **404 Not Found:** `{ "error": "Post not found" }`

#### **DELETE /api/posts/{id}**
- **Descrição:** Exclui um post existente.
- **Requisição:**
  - **Cabeçalho:** `Authorization: Bearer <token>`
  - **Parâmetros de URL:** `id (integer) - ID do post`
- **Resposta:**
  - **204 No Content**
  - **404 Not Found:** `{ "error": "Post not found" }`

### **2.3 Visualização de Posts**

#### **GET /api/posts**
- **Descrição:** Retorna uma lista de posts.
- **Requisição:**
  - **Parâmetros de Query (opcional):**
    - `page (integer)` - Número da página.
    - `limit (integer)` - Número de posts por página.
- **Resposta:**
  - **200 OK:** `[ { "id": "integer", "title": "string", "created_at": "datetime" } ]`

#### **GET /api/posts/{id}**
- **Descrição:** Retorna o conteúdo completo de um post.
- **Requisição:**
  - **Parâmetros de URL:** `id (integer) - ID do post`
- **Resposta:**
  - **200 OK:** `{ "id": "integer", "title": "string", "content": "string", "created_at": "datetime" }`
  - **404 Not Found:** `{ "error": "Post not found" }`

## **3. Estrutura de Dados**

### **3.1 Post**
- **ID:** `integer` - Identificador único do post.
- **Título:** `string` - Título do post.
- **Conteúdo:** `string` - Conteúdo do post.
- **Data de Criação:** `datetime` - Data e hora em que o post foi criado.
- **Data de Atualização:** `datetime` - Data e hora da última atualização do post.

### **3.2 Usuário**
- **Nome de Usuário:** `string` - Nome de usuário para login.
- **Senha:** `string` - Senha do usuário (armazenada de forma segura).

## **4. Considerações Finais**
Esta API foi projetada para ser simples e direta, fornecendo as funcionalidades essenciais para o gerenciamento de posts em um blog. Ela foi desenvolvida com foco na clareza e na eficiência, evitando a complexidade desnecessária.

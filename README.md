# Documentação da API: Blog Minimalista

## 1. Visão Geral
Esta API oferece funcionalidades básicas para um blog minimalista, permitindo a autenticação de usuários, bem como o gerenciamento e visualização de posts. A API foi projetada com foco na simplicidade e facilidade de uso, oferecendo apenas as operações essenciais para o funcionamento do blog.

## 2. Instruções para Executar no Docker Compose

Para facilitar a configuração e execução da API, eu disponibilizo um arquivo `docker-compose.yml`. Siga as instruções abaixo para executar a API em um ambiente Docker:

### Passos:
1. **Clone o repositório**:
   ```bash
   git clone https://github.com/seu-usuario/blog-minimalista.git
   cd blog-minimalista
   ```

2. **Construa as imagens Docker**:
   Antes de iniciar os containers, é necessário construir as imagens Docker:
   ```bash
   docker-compose build
   ```

3. **Execute o Docker Compose**:
   Use o comando abaixo para iniciar os containers:
   ```bash
   docker-compose up -d
   ```

4. **Acesse a API**:
   Após o Docker Compose finalizar a configuração, a API estará disponível em `http://localhost:8000`.

5. **Parar os containers**:
   Para parar e remover os containers, use o comando:
   ```bash
   docker-compose down
   ```

Com esses passos, a API do blog minimalista estará rodando em um ambiente isolado, pronta para uso.

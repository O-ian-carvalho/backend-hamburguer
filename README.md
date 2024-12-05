
# **ASP.NET Web API**

## **Descrição**
Projeto ASP.NET Web API com arquitetura em 3 camadas: **API**, **Business** e **Data**. Migrações configuradas na camada **Data**.

---

## **Requisitos**
- **.NET SDK**
- **Banco de Dados** configurado
- **Entity Framework Core CLI**

---

## **Configuração**

1. **Clone o Repositório**:
   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd <PASTA_DO_PROJETO>
   ```

2. **Configure a Conexão**:
   - Edite o arquivo `appsettings.json` na camada **API** com sua string de conexão:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=Hamburgueria;User Id=seu_usuario;Password=sua_senha;"
     }
     ```

---

## **Rodando a Aplicação**

1. **Aplicar Migrações**:
   ```bash
   cd Hamurgueria.Data
   dotnet ef database update 
   ```

2. **Iniciar a API**:
   ```bash
   cd ../Hamurgueria.Api
   dotnet run
   ```


---

## **Estrutura**
- **API**: Endpoints.
- **Business**: Regras de negócio.
- **Data**: Acesso a dados e migrações.



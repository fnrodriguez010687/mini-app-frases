# Mini App de Frases

Una pequeña aplicación que muestra frases almacenadas en Redis a través de una API .NET 9 y un frontend Angular.

---

## Tabla de Contenidos

- [Descripción](#descripción)  
- [Tecnologías](#tecnologías)  
- [Requisitos Previos](#requisitos-previos)  
- [Instalación](#instalación)  
- [Uso](#uso)  
- [Estructura del Repositorio](#estructura-del-repositorio)  
- [Docker](#docker)  
- [Desarrollo](#desarrollo)  
- [Contribuir](#contribuir)  
- [Licencia](#licencia)  

---

## Descripción

Esta aplicación consta de  
- Una API en .NET 9 (`backend/QuotesApi`) que expone endpoints REST para obtener frases.  
- Un worker (`backend/ScraperWorker`) que consulta una fuente externa y almacena frases en Redis.  
- Un frontend en Angular 20 (`frontend/quotes-app`) que consume la API y muestra las frases.  
- Orquestación con `docker-compose.yaml` para levantar todos los servicios con un solo comando.

---

## Tecnologías

- .NET 9  
- ASP.NET Core Web API  
- StackExchange.Redis  
- Angular 20 con componentes standalone  
- Docker y Docker Compose  

---

## Requisitos Previos

- Git  
- .NET SDK 9.0  
- Node.js y npm  
- Docker y Docker Compose  

---

## Instalación

1. Clonar el repositorio  
   ```bash
   git clone git@github.com:TU_USUARIO/mini-app-frases.git
   cd mini-app-frases
2. Levantar con Docker-Compose
    ```bash
    docker compose up --build -d
    ```
    - La API estará en http://localhost:5000
    - El frontend angular en http://localhost:4200
3. Sin Docker
    - Ejecutar Api
    ```bash
    cd backend/QuotesApi
    dotnet restore
    dotnet run
    ```
    - Ejecutar Scraper Worker
    ```bash
    cd backend/ScraperWorker
    dotnet restore
    dotnet run
    ```
    - Ejecutar el frontend
    ```bash
    cd frontend/quotes-app
    npm install
    ng serve --open
    ```
    - Montar Redis
    Guía oficial de instalación de Redis (Linux, macOS, Windows):
    https://redis.io/docs/latest/operate/oss_and_stack/install/archive/install-redis/

## Estructura

    /
    ├─ backend
    │  ├─ QuotesApi
    │  └─ ScraperWorker
    ├─ frontend
    │  └─ quotes-app
    ├─ docker-compose.yaml
    └─ README.md

## Docker

- Cada servicio tiene su Dockerfile en su carpeta.
- El docker-compose.yaml en la raíz orquesta todos los contenedores.
- Para ver logs:
  ```bash
    docker-compose logs -f
  ```
## Licencia

Este proyecto está bajo la licencia MIT.

---

## 2. Pasos para añadir contenido

1. **Crear o abrir** el archivo `README.md` en la raíz del proyecto con tu editor favorito.  
2. **Copiar y pegar** la plantilla anterior y personalizar nombres, rutas y comandos.  
3. **Guardar** los cambios y confirmar con Git:
   ```bash
   git add README.md
   git commit -m "docs: añadir README con la guía de uso"
   git push
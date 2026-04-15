# P5AspEntity

API REST simple en ASP.NET Core 8 (Minimal API) avec Entity Framework Core et SQLite.

## Description

Ce projet expose un CRUD pour la ressource `Product`:
- Lire la liste des produits
- Ajouter un produit
- Modifier un produit
- Supprimer un produit

La persistence est geree par SQLite via EF Core (`products.db`).

## Stack technique

- .NET 8
- ASP.NET Core Minimal API
- Entity Framework Core 8
- SQLite
- Swagger / OpenAPI (en environnement Development)

## Structure utile

- `P5AspEntity/Program.cs` : configuration de l'application et endpoints
- `P5AspEntity/Data/AppDbContext.cs` : contexte EF Core
- `P5AspEntity/Models/Product.cs` : modele de donnees
- `P5AspEntity/Migrations/` : migrations EF Core
- `P5AspEntity/appsettings.json` : chaine de connexion SQLite

## Prerequis

- .NET SDK 8.0+

Optionnel (si vous voulez gerer les migrations en ligne de commande):

```bash
dotnet tool install --global dotnet-ef
```

## Installation et lancement

Depuis la racine du workspace (dossier contenant `POOAspEntity.sln`):

```bash
dotnet restore
dotnet run --project P5AspEntity/P5AspEntity.csproj
```

Par defaut, l'API demarre sur les URLs affichees dans la console (ex: `https://localhost:xxxx`).

## Base de donnees et migrations

Le projet contient deja une migration initiale.

Pour appliquer la migration et creer la base SQLite:

```bash
dotnet ef database update --project P5AspEntity/P5AspEntity.csproj
```

Le fichier `products.db` sera cree dans le dossier de demarrage de l'application.

## Documentation API (Swagger)

En mode Development, Swagger est active:
- UI: `/swagger`
- OpenAPI JSON: `/swagger/v1/swagger.json`

Exemple:

```text
https://localhost:5001/swagger
```

## Endpoints

### GET /products
Retourne la liste des produits.

### POST /products
Cree un nouveau produit.

Exemple body JSON:

```json
{
  "name": "Clavier",
  "price": 49.99
}
```

### PUT /products/{id}
Met a jour un produit existant.

Exemple body JSON:

```json
{
  "name": "Clavier mecanique",
  "price": 79.99
}
```

### DELETE /products/{id}
Supprime un produit par son identifiant.

## Exemples rapides avec curl

```bash
# Lister les produits
curl -k https://localhost:5001/products

# Ajouter un produit
curl -k -X POST https://localhost:5001/products \
  -H "Content-Type: application/json" \
  -d '{"name":"Souris","price":25.5}'

# Modifier un produit
curl -k -X PUT https://localhost:5001/products/1 \
  -H "Content-Type: application/json" \
  -d '{"name":"Souris gamer","price":39.9}'

# Supprimer un produit
curl -k -X DELETE https://localhost:5001/products/1
```

## Notes

- L'endpoint `/weatherforecast` est encore present (template par defaut ASP.NET).
- Pensez a adapter la chaine de connexion dans `P5AspEntity/appsettings.json` si besoin.

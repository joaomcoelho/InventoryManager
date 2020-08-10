# Inventory Management - .Net Core

### Folder Structure

    src
    ├── Api                              # Api
    │   ├── Controllers                  # Controllers with the endpoints for the api
    ├── Data                             # Database entities and workers [Data Access Layer]
    ├── Library                          # Library
    │   ├── Enums                        # Lookup structures
    │   └── Helpers                      # Helper methods that can be used everywhere in the app
    ├── Services                         # Database services [Service Layer]
    │   ├── InventoryManagerService      # InventoryManager IServices and Services 
    │   └── DTO                          # InventoryManager Data Transfer Objects
    │       └── InventoryManager                    
    └── README.md

### Requirements
This Api was built using .NetCore version 3.1 with the EntityFrameworkCore and AutoMapper Packages on top a SQL Server Express database.

### Migrations
Creates the initial migration
```
dotnet ef migrations add InitialCreate
```

Updates the database
```
dotnet ef database update
```

### Run the application using .Net Core CLI
Builds application
```
dotnet build
```

Listens the application on https://localhost:5001 and https://localhost:5000
```
dotnet run
```

### EndPoints

Batch endpoints:

* [Get Batch with {id}] : `GET /Batch/{id}`
* [List Batch] : `GET /Batch`
* [Insert Batch] : `POST /Batch`
  
  body*:
```json
    {
        "expirationDate": "2033-01-19",
        "batchStateId": 3
    }
```
* [Update Batch] : `PUT /Batch`
* [Delete Batch with {id}] : `DELETE /Batch/{id}`
* [History of a batch with {id}] : `GET /Batch/History/{id}`

Inventory endpoints:

* [Add/Modify Product in inventory] : `POST /Inventory`
  
  body*:
```json
    {
        "productId" : 13,
        "stock" : 9,
        "supplierId" : 2,
        "customerId" : null,
        "expirationDate" : "2021-03-22",
        "reason" : "Tuna delivery"
    }
```
* [Get the current inventory per product {productId}] : `GET /Inventory/Product/{productId}`
* [Get the current inventory for the whole warehouse] : `GET /Inventory/Product`
* [Get an overview of the food {batchStateId} (fresh, expiring today, expired))] : `GET /Inventory/State/{batchStateId}`

## Authors
* **João André Coelho** - *Inventory Management - .Net Core* - [joaomcoelho](https://github.com/joaomcoelho)

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

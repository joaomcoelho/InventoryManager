# Inventory Management - .Net Core and EntityFrameworkCore

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
This Api was built using .Net Core version 3.1 with the EntityFrameworkCore and AutoMapper Packages on top a SQL Server Express database.

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
```json
    {
        "expirationDate": "2023-01-19",
        "batchStateId": 3
    }
```
* [Update Batch] : `PUT /Batch`
* [Delete Batch with {id}] : `DELETE /Batch/{id}`
* [History of a batch with {id}] : `GET /Batch/History/{id}`

Inventory endpoints:

* [Add/Modify Product in inventory] : `POST /Inventory`
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

## Tasks and Examples

### Register new product batches for the warehouse
* "Supplier2" delivered 1000 units of Tuna with expiration date "2021-03-22". The following request registers this delivery in the warehouse:
</br>`POST /Inventory`
```json
    {
        "productId" : 13,
        "stock" : 1000,
        "supplierId" : 2,
        "customerId" : null,
        "expirationDate" : "2021-03-22",
        "reason" : ""
    }
```

### Update or modify stock of any batch
* "Customer1" requested a super dish that 10 units of Tuna. To cook it we used 10 units of Tuna from a batch with "2021-03-22" expiration date.
The following request registers this delivery in the warehouse:
</br>`POST /Inventory`
```json
    {
        "productId" : 13,
        "stock" : -10,
        "supplierId" : null,
        "customerId" : 1,
        "expirationDate" : "2021-03-22",
        "reason" : ""
    }
```

* "Mary" dropped in the floor 200 units of Tuna from batch with "2021-03-22" expiration date.
The following request registers this delivery in the warehouse:
</br>`POST /Inventory`
```json
    {
        "productId" : 13,
        "stock" : -200,
        "supplierId" : null,
        "customerId" : null,
        "expirationDate" : "2021-03-22",
        "reason" : "Dropped in the floor"
    }
```

### Retrieve the current inventory per product 

* for each batch individually: </br>
Now I want to know how is my Tuna inventory by batches.
The following request returns the information:
</br>`GET /Inventory/Product/13`

* for the whole warehouse, broken down by batches: </br>
I want to see my whole warehouse also broken down by batches.
The following request returns the information:
</br>`GET /Inventory/Product`

### Retrieve an overview of the freshness of food we have in the warehouse

* Sure we cannot deliver expired foo! I need to see what expired food we have in the warehouse.
The following request returns the information:
</br>`GET /Inventory/State/3`

* What about fresh food in the warehouse?
The following request returns the information:
</br>`GET /Inventory/State/1`

### Retrieve the history of a given batch

* What happen with all food in the batch with "2021-03-22" expiration date.
The following request returns the information:
</br>`GET /Batch/History/15` where 15 is the corresponding batchId for this expiration date.

### ▶️ Next Steps
- Finish developing order registering in the warehouse.
- Daily process to update the batch state. For example to update the batch state to "Expired" if the expiration date is in the past or "Expiring Today" if the expiration date is today.
- Implement authentication and authorization

### 🔔 Improvements
- POST, PUT endpoints do not validate the input data. Server side validation should be added in order to instantly report to the client bad/missing input fields.
- "ControllerBase" class handles all HTTP Status code responses. Some work is needed in order to provide more accurate/custom status code responses to the client.
- Use a continuous integration like Travis, Jenkins, etc...
- Log errors.

### ☀️ Ideas
- Develop some Kpis using InventoryHistory. For example: "How much food is lost per year in the wharehouse", "What are the most requested ingredients in each season (Winter, Summer, Autumn, Spring", "How much food we let getting expired every month".
- Integrate dishes. If we knew which products are required to cook a certain dish and what products we do have on inventory, we could actually optimize the use of the warehouse by cooking the right dishes with the products that are available at the moment.


## Authors
* **João André Coelho** - *Inventory Management - .Net Core* - [joaomcoelho](https://github.com/joaomcoelho)

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

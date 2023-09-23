/*creacion de tipos especiales*/
CREATE TYPE role AS ENUM ('Inventory Manager','Store Manager', 'Warehouse manager');
CREATE TYPE register AS ENUM ('Created', 'Updated', 'Deleted');

/*Creacion de la base de datos*/
CREATE DATABASE Inventory;

CREATE TABLE "Products" (
    "Id" SERIAL PRIMARY KEY,
    "ProductName" VARCHAR(30) NOT NULL,
    "Descriptions" VARCHAR(90) NOT NULL,
    "Stock" INTEGER NOT NULL CHECK ("Stock" >= 0),
    "Price" DECIMAL(10,2) NOT NULL CHECK ("Price" > 0)
    "ImageUrl" VARCHAR NOT NULL
);

CREATE TABLE "Users" (
    "Id" SERIAL PRIMARY KEY,
    "FirstName" VARCHAR(30) NOT NULL,
    "Surname" VARCHAR(30) NOT NULL,
    "Email" VARCHAR(140) UNIQUE NOT NULL,
    "DateOfBirth" DATE NOT NULL CHECK ("DateOfBirth" >= '1955-01-01'),
    "Password" VARCHAR(90) NOT NULL,
    "Google" BOOLEAN,
    "Recovery_token" VARCHAR NOT NULL
);


CREATE TABLE "Costumer" (
    "Id" SERIAL PRIMARY KEY,
    "UserId"
    "CompanyId",
);


CREATE TABLE "Company" (
    "Id" SERIAL PRIMARY KEY,
    "BusinessOwnerId",
);


CREATE TABLE "Stores" (
    "Id" SERIAL PRIMARY KEY,
    "CompanyId" 
    "addres"
);



CREATE TABLE "StoreInfo" (
    "Id" SERIAL PRIMARY KEY,
    "Address" VARCHAR(90) NOT NULL
);

CREATE TABLE "ProductStore" (
    "Id" SERIAL PRIMARY KEY,
    "BelongingStock" INTEGER NOT NULL CHECK ("BelongingStock" >= 0),
    "StoreId" INTEGER NOT NULL,
    "ProductId" INTEGER NOT NULL,
    CONSTRAINT "FKStore" FOREIGN KEY ("StoreId") REFERENCES "StoreInfo"("Id"),
    CONSTRAINT "FKProduct" FOREIGN KEY ("ProductId") REFERENCES "Products"("Id")
);

CREATE TABLE "Orders" (
    "Id" SERIAL PRIMARY KEY,
    "OrderDate" DATE NOT NULL CHECK ("OrderDate" >= '2015-01-01'),
    "StoreId" INTEGER NOT NULL,
    "UserId" INTEGER NOT NULL,
    CONSTRAINT "FKStoreOrder" FOREIGN KEY ("StoreId") REFERENCES "StoreInfo"("Id"),
    CONSTRAINT "FKUserOrder" FOREIGN KEY ("UserId") REFERENCES "Users"("Id")
);

CREATE TABLE "OrdersProducts" (
    "Id" SERIAL PRIMARY KEY,
    "IdProduct" INTEGER NOT NULL,
    "IdOrder" INTEGER NOT NULL,
    "Quantity" INTEGER NOT NULL CHECK ("Quantity" > 0),
    CONSTRAINT "FKProductOrder" FOREIGN KEY ("IdProduct") REFERENCES "ProductStore"("Id"),
    CONSTRAINT "FKOrder" FOREIGN KEY ("IdOrder") REFERENCES "Orders"("Id")
);

CREATE TABLE "Registers" (
    "Id" SERIAL PRIMARY KEY,
    "IdUser" INTEGER NOT NULL,
    "RegisterDate" TIMESTAMP DEFAULT NOW(),
    "TypeRegister" register NOT NULL,
    CONSTRAINT "FKUserRegister" FOREIGN KEY ("IdUser") REFERENCES "Users"("Id")
);

CREATE TABLE "ProductRegister" (
    "Id" SERIAL PRIMARY KEY,
    "ProductId" INTEGER NOT NULL,
    "RegisterId" INTEGER NOT NULL,
    "Quantity" INTEGER CHECK ("Quantity" > 0),
    CONSTRAINT "FKProduct" FOREIGN KEY ("ProductId") REFERENCES "Products"("Id"),
    CONSTRAINT "FKRegister" FOREIGN KEY ("RegisterId") REFERENCES "Registers"("Id")
);

CREATE TABLE "Returns" (
    "Id" SERIAL PRIMARY KEY,
    "BelongingStore" INTEGER NOT NULL,
    "BelongingUser" INTEGER NOT NULL,
    "ReturnDate" TIMESTAMP DEFAULT NOW(),
    "Quantity" INTEGER NOT NULL CHECK ("Quantity" > 0),
    CONSTRAINT "FKStoreReturn" FOREIGN KEY ("BelongingStore") REFERENCES "StoreInfo"("Id"),
    CONSTRAINT "FKUserReturn" FOREIGN KEY ("BelongingUser") REFERENCES "Users"("Id")
);

CREATE TABLE "ProductsReturns" (
    "Id" SERIAL PRIMARY KEY,
    "IdProduct" INTEGER NOT NULL,
    "IdReturn" INTEGER NOT NULL,
    "Quantity" INTEGER NOT NULL CHECK ("Quantity" > 0),
    CONSTRAINT "FKProductReturn" FOREIGN KEY ("IdProduct") REFERENCES "Products"("Id"),
    CONSTRAINT "FKReturn" FOREIGN KEY ("IdReturn") REFERENCES "Returns"("Id")
);

CREATE TABLE "UserStore" (
    "Id" SERIAL PRIMARY KEY,
    "IdUser" INTEGER NOT NULL UNIQUE,
    "IdStore" INTEGER NOT NULL,
    CONSTRAINT "FKUserInfo" FOREIGN KEY ("IdUser") REFERENCES "Users"("Id"),
    CONSTRAINT "FKStore" FOREIGN KEY ("IdStore") REFERENCES "StoreInfo"("Id")
);


/*aqui aun esta en trabajo*/

/*tablas de historial*/
CREATE TABLE HistoryOrders(
    IdHistory SERIAL PRIMARY KEY,
    IdOrder INTEGER NOT NULL,
    IdStore INTEGER NOT NULL,
    OrderDate TIMESTAMP NOT NULL,
    IdUser INTEGER NOT NULL,
    UserName VARCHAR(30) NOT NULL
);

CREATE TABLE HistoryOrderProduct(
    Id SERIAL PRIMARY KEY,
    IdProduct INTEGER NOT NULL,
    IdHistoryOrder INTEGER NOT NULL,
    Quantity INTEGER NOT NULL CHECK(Quantity >0),
    ProductName VARCHAR(30) NOT NULL,
    CONSTRAINT FKHistoryOrder FOREIGN KEY(IdHistoryOrder) REFERENCES HistoryOrders(IdHistory)
);

/*triggers*/

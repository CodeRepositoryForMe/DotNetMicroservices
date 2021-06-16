# DotNetMicroservices

1. Init Project

2. Create Project for Catalog.API
	-- Remove existing controller and model 
	
3. Init Docker for CatalogDb

		>docker ps

		> docker pull mongo

		> docker run -d -p 27017:27017 --name shopping-mongo mongo

		> docker ps

		> docker exec -it shopping-mongo /bin/bash

		> # mongo

		> # show dbs

		>us CatalogDb
		switched to db CatalogDb

		> # db.createCollection("Products")

		>db.Products.insertMany([{ 'Name':'Asus Laptop','Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price':54.93 }, { 'Name':'HP Laptop','Category':'Computers', 'Summary':'Summary', 'Description':'Description', 'ImageFile':'ImageFile', 'Price':88.93 } ])

		>db.Products.find({})

		>db.Products.find({}).pretty()

4. 

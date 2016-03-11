# _C# Shoe Store_

#### _C#, Nancy and Razor project for Epicodus, 02.26.2016_

#### By _**Taylor Grohs**_

## Description

_this is a many to many project where you can add stores and brands, each store can have many brands and each brand can have many stores_

## Setup/Installation Requirements

* To view the project you must clone the files to your desktop and in your powershell run 'dnu restore' while in the project folder, after the restore is complete you then run 'dnx kestrel' and type localhost:5004 into your browser.

* Database used:
* CREATE DATABASE shoe_stores;
* GO
* USE shoe_stores;
* GO
* CREATE TABLE stores(id INT IDENTITY(1,1), name VARCHAR(255));
* CREATE TABLE brands(id INT IDENTITY(1,1), name VARCHAR(255));
* CREATE TABLE brand_store(id INT IDENTITY(1,1), store_id int, brand_id int));
* GO

## Support and contact details

_Email me at taylorgrohs@gmail.com_


### License

*MIT*

Copyright (c) 2016 **_Epicodus_**

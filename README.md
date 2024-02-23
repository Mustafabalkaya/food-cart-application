# Food E-Commerce Project

This project is a food management system developed using the ASP.NET MVC framework. The purpose of the project is to assist users in editing their food lists, tracking orders, and managing inventory.

## Technologies

- **ASP.NET MVC:** The project is built on the ASP.NET MVC framework.
- **HTML, CSS, JS, and Bootstrap:** These technologies are utilized for interface design and user experience.
- **MS SQL Server:** MSSQL Server is used as the database.

## Features

- Users can initially view only product lists and categories.
- After logging in, users can perform interface operations such as adding, deleting, and updating.
- User roles include: ADMIN, PERSONNEL, CUSTOMERS.
- The "Customers" entry allows tracking of invoices and sales movements.
- Users can access their information on the shopping cart page and check order status after placing an order.
- Download functionality for tables in Excel and PDF formats is implemented.

## Inventory Management

- After a sale, the stock quantity of the relevant product decreases, and when it reaches zero, the status is set to "False."
- Products with zero stock are not visible in the system but are not deleted from the database. Shortages can be addressed.

## Excel and PDF Download Features

- Tables provide users with the option to download in Excel and PDF formats.
- This feature facilitates exporting and reporting of data for users.

## Usage

1. After cloning the project, open it using Visual Studio or an appropriate IDE.
2. Update database connection settings in the `Web.config` file.
3. Install necessary dependencies and start the project.

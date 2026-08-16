# Freelance Marketplace

A web-based freelance marketplace built with **ASP.NET Core MVC** and **SQLite**, where buyers can browse freelance services, place orders, and leave reviews, while sellers can create and manage their gigs.

## 📌 Project Overview

Freelance Marketplace is a full-stack web application developed to demonstrate the core functionality of a freelance service platform.

The application provides separate functionality for **Buyers** and **Sellers**, including user authentication, gig management, order management, and reviews.

## ✨ Features

### 👤 User Management

* User registration
* User login and logout
* Buyer and Seller roles
* User dashboard
* User management
* Edit and delete users

### 💼 Gig Management

* Sellers can create gigs
* View all available gigs
* Search gigs by title or description
* Edit existing gigs
* Delete gigs
* Display gig descriptions and prices

### 📦 Order Management

* Buyers can place orders for gigs
* View all orders
* View personal orders
* Track order status
* Mark orders as completed
* Cancel pending orders

### ⭐ Reviews

* Buyers can leave reviews for completed orders
* Rating system from 1 to 5 stars
* Written comments
* Review submission linked to gigs

### 📊 Dashboard

* User welcome information
* Display current user role
* Quick access to gigs and user management
* Logout functionality

## 🛠️ Technologies Used

* **C#**
* **ASP.NET Core MVC**
* **Entity Framework Core**
* **SQLite**
* **HTML5**
* **CSS3**
* **Bootstrap**
* **Razor Views**
* **LINQ**
* **Visual Studio Code**
* **Git & GitHub**

## 🏗️ Project Structure

```text
FreelanceMarketplace/
│
├── Controllers/
│   ├── GigsController.cs
│   ├── OrdersController.cs
│   ├── ReviewsController.cs
│   └── UsersController.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Migrations/
│
├── Models/
│   ├── Gig.cs
│   ├── Order.cs
│   ├── Review.cs
│   └── User.cs
│
├── ViewModels/
│   └── LoginViewModel.cs
│
├── Views/
│   ├── Gigs/
│   ├── Home/
│   ├── Orders/
│   ├── Reviews/
│   ├── Shared/
│   └── Users/
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── lib/
│
├── Program.cs
├── appsettings.json
└── freelanceMarketplace.csproj
```

## 🚀 How to Run the Project Locally

### 1. Clone the repository

```bash
git clone https://github.com/Komalmeh36/FreelanceMarketplace.git
```

### 2. Open the project

```bash
cd FreelanceMarketplace
```

### 3. Restore dependencies

```bash
dotnet restore
```

### 4. Apply database migrations

```bash
dotnet ef database update
```

If Entity Framework CLI is not installed:

```bash
dotnet tool install --global dotnet-ef
```

### 5. Run the application

```bash
dotnet run
```

The application will provide a local URL in the terminal, such as:

```text
http://localhost:xxxx
```

Open that URL in your browser.

## 🔐 User Roles

### Buyer

A Buyer can:

* Browse available gigs
* Search for gigs
* Place orders
* View personal orders
* Track order status
* Leave reviews after completed orders

### Seller

A Seller can:

* Create gigs
* View gigs
* Edit gigs
* Delete gigs
* Manage orders
* Complete or cancel orders

## 🗃️ Database

The application uses **SQLite** with **Entity Framework Core** for data storage.

The database contains information related to:

* Users
* Gigs
* Orders
* Reviews

Database migrations are included in the `Migrations` folder.

## 🎯 Purpose of the Project

This project was developed as a practical **ASP.NET Core MVC** application to demonstrate:

* MVC architecture
* CRUD operations
* Entity Framework Core
* Database relationships
* Role-based application behavior
* Session-based user authentication
* Form handling
* Razor Views
* Git and GitHub workflow

## 📸 Screenshots

Screenshots of the application can be added here to demonstrate:

* Login
* Dashboard
* Gig listing
* Create Gig
* Orders
* My Orders
* Reviews
* User management

## 🔗 Repository

GitHub:

https://github.com/Komalmeh36/FreelanceMarketplace

## 👩‍💻 Author

**Komal Mehmood**

BS Software Engineering
Riphah International University

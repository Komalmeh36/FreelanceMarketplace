# Freelance Marketplace

A web-based freelance marketplace built with **ASP.NET Core MVC** and **SQLite**, where buyers can browse freelance services, place orders, and leave reviews, while sellers can create and manage their gigs.

## 📌 Project Overview

Freelance Marketplace is a full-stack web application developed to demonstrate the core functionality of a freelance service platform.

The application provides separate functionality for **Buyers** and **Sellers**, including user authentication, gig management, order management, and reviews.

## 🎥 Project Demo

Watch the complete Freelance Marketplace project walkthrough:

▶️ [Watch the Demo Video on YouTube](https://youtu.be/d9QVF92um2E)

The video demonstrates the application's user authentication, dashboard, gig management, order management, and other core features.

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

# 🏬 ABC Retail Cloud App  
**Azure-Integrated ASP.NET Core MVC Application**  
📦 *Developed by James Baker – ST10457455*  

---

## 🌥️ **Project Overview**

The **ABC Retail Cloud App** is a cloud-based web application built using **ASP.NET Core MVC**.  
It allows users to **upload product images**, store product data in **Azure Table Storage**,  
and manage product listings securely and efficiently in the cloud.  

This project demonstrates how to integrate multiple Azure services —  
including **Blob Storage**, **Table Storage**, and **App Service** — into a modern web app.

---

## ⚙️ **Key Features**

✅ Upload and store product images using **Azure Blob Storage**  
✅ Manage product records with **Azure Table Storage**  
✅ Dynamic product search and filtering  
✅ Secure environment variables for cloud deployment  
✅ Fully deployed to **Azure App Service**  
✅ Integrated MVC structure for scalability and maintainability  

---

## 🧠 **Learning Outcomes**

This project demonstrates the following key outcomes:

- ✅ **Hosting and deployment** of a cloud-based web application using **Azure App Service**.  
- ☁️ **Integration of Azure Blob Storage** for secure and scalable file management.  
- 🗄️ **Integration of Azure Table Storage** for efficient structured data handling.  
- 🔐 **Implementation of secure environment variables** using Azure App Configuration.  
- ⚙️ **Use of ASP.NET Core MVC** to build a scalable, cloud-native web application.

---

## 🧩 **Future Enhancements**

Planned improvements and next-phase features include:

- 🔑 Implement **Azure Key Vault** for centralized secret and credential management.  
- 🔍 Add **Azure Cognitive Search** for advanced, AI-powered product lookup.  
- 👥 Integrate **Azure Active Directory (Azure AD)** authentication for role-based access.  
- 📬 Include **Azure Queue Storage** for background processing and event-driven workflows.  

---

## 🧱 **System Architecture**

+---------------------------+
| ASP.NET Core MVC |
| (Controllers & Views) |
+------------+--------------+
|
v
+---------------------------+
| Azure Blob Storage |
| (Product Images / Upload) |
+------------+--------------+
|
v
+---------------------------+
| Azure Table Storage |
| (Product Data Tables) |
+------------+--------------+
|
v
+---------------------------+
| Azure App Service |
| (Web Hosting Platform) |
+---------------------------+

yaml
Copy code

---

## 🚀 **Deployment Steps**

1. **Publish the project**  
   ```bash
   dotnet publish -c Release
Deploy to Azure App Service

Open VS Code → Install Azure App Service Extension

Sign in to your Azure Account

Right-click project folder → Deploy to Web App

Configure Environment Variables

In Azure Portal → App Service → Configuration

Add key:

nginx
Copy code
ConnectionStrings__AzureStorage
Value = your Azure Storage connection string

Verify Storage Connections

Go to Azure → Storage Account → Tables

Ensure Products and Customers tables exist

🧾 Screenshots (Recommended for Report)
📸 Include screenshots such as:

The running web app (Products page)

Azure Blob Container with product images

Azure Table Storage showing ProductEntity rows

App Service Configuration screen

📚 References
Microsoft Docs. (2024). Azure App Service Overview

Microsoft Docs. (2024). Azure Storage for .NET Developers

Ciampa, M. (2022). Security+ Guide to Network Security Fundamentals.

Schwaber, K., & Beedle, M. (2002). Agile Software Development with Scrum.

👨‍💻 Author
James Baker – ST10457455
📧 st10457455@vcconnect.edu.za
🏫 Varsity College – CLDV6212 Cloud Development
📅 2025 | Portfolio of Evidence – Part 3
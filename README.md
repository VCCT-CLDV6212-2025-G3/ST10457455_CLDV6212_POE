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

```text
+---------------------------+
|     ASP.NET Core MVC      |
|   (Controllers & Views)   |
+------------+--------------+
             |
             v
+---------------------------+
|     Azure Blob Storage    |
| (Product Images / Upload) |
+------------+--------------+
             |
             v
+---------------------------+
|     Azure Table Storage   |
|   (Product Data Tables)   |
+------------+--------------+
             |
             v
+---------------------------+
|     Azure App Service     |
|   (Web Hosting Platform)  |
+---------------------------+


yaml
Copy code

---

## 🚀 **Deployment Guide**

### 1️⃣ Deploy to Azure App Service

Follow these steps to publish your cloud app to Azure:

1. **Open VS Code** → Install the **Azure App Service** Extension.  
2. **Sign in** to your Azure Account.  
3. **Right-click** your project folder → Select **“Deploy to Web App”**.  
4. Choose your resource group and confirm the deployment.  

---

### 2️⃣ Configure Environment Variables

After deployment:

1. Go to **Azure Portal** → **App Service** → **Configuration**.  
2. Under **Application Settings**, click **+ Add** and enter:

   ```bash
   Name:  ConnectionStrings__AzureStorage  
   Value: <your Azure Storage connection string>
Click Apply and restart the App Service.

3️⃣ Verify Storage Connections
Once deployed, confirm that your Azure resources are connected:

Go to Azure Portal → Storage Account → Tables.

Ensure the following tables exist:

🧾 Products

👥 Customers

You should see your data rows and uploaded image URLs appearing correctly.

🖼️ Screenshots (Recommended for Report)
Include the following screenshots in your Word document or GitHub submission:

Screenshot	Description
🖥️ Web App Home / Products Page	Shows all products with images, names, and categories
☁️ Azure Blob Container	Displays uploaded product images
📋 Azure Table Storage	Shows ProductEntity rows stored in Azure Table
⚙️ Azure App Service Configuration	Displays your environment variables and deployment settings

📚 References
Microsoft Docs. (2024). Azure App Service Overview

Microsoft Docs. (2024). Azure Storage for .NET Developers
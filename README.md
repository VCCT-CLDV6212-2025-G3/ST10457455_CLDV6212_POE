# ABC Retail - Azure Cloud Portfolio of Evidence (POE)

## Student Information
- **Student Number:** ST10457455  
- **Module Code:** CLDV6212  
- **Project Part:** Complete POE (Parts 1–3)  

---

## Project Background

ABC Retail, a rapidly growing online retailer, faced several challenges with its legacy on-premises infrastructure:

- **Order processing:** Relational databases struggled with peak season transaction volume.  
- **Product images:** Stored in network drives, causing slow access times and inefficiency.  
- **Message queuing:** Legacy middleware lacked scalability, resulting in delays and errors.  
- **Data analytics:** On-premises tools could not efficiently process diverse customer data types, leading to delays in actionable insights.  

Despite migrating parts of the system to the cloud, ABC Retail needed a scalable, reliable, and cost-effective cloud solution to handle real-time events, store data efficiently, and enable better analytics.

---

## Project Objective

Develop a cloud-based solution using **Microsoft Azure** that:  

1. Stores customer profiles and product information using **Azure Tables**.  
2. Hosts images and multimedia content with **Azure Blob Storage**.  
3. Handles order processing and inventory management using **Azure Queues**.  
4. Stores dummy contracts using **Azure Files**.  
5. Deploys a fully functional **web application** accessible via an Azure App Service.  

---

## Technologies Used

- **Microsoft Visual Studio 2022**  
- **.NET 8 Web Application**  
- **Azure Services:**  
  - Azure Tables  
  - Azure Blob Storage  
  - Azure Queues  
  - Azure Files  
  - Azure App Service  
- **Version Control:** GitHub  

---

## Web Application Features

- Upload and download data from Azure Storage Services.  
- Display customer, product, and order information dynamically.  
- Host multimedia content efficiently using Blob Storage.  
- Scalable and reliable messaging for order processing using Azure Queues.  

---

## Azure Deployment

- **Resource Group:** `AZ-JHB-RSG-VCWCCN-ST10457455-TER`  
- **Web App Name:** `st104457455cldv6212`  
- **App Service Plan:** `st10457455cldv6212` (Basic B1)  
- **App URL:** [https://st104457455cldv6212-eaadbyevf2ggh6fx.southafricanorth-01.azurewebsites.net](https://st104457455cldv6212-eaadbyevf2ggh6fx.southafricanorth-01.azurewebsites.net)  

---

## GitHub Repository

All source code, configurations, and project files are stored in:  
[https://github.com/VCCT-CLDV6212-2025-G3/ST10457455_CLDV6212_POE](https://github.com/VCCT-CLDV6212-2025-G3/ST10457455_CLDV6212_POE)

---

## Screenshots

*(Include screenshots of each Azure Storage Service, the deployed web application, and any key functionalities here)*  

---

## Submission Instructions

1. Ensure the web application is deployed and accessible via the URL above.  
2. Include screenshots of all implemented features.  
3. Submit a single MS Word document containing:  
   - Student number  
   - Module code  
   - Web App URL  
   - GitHub link  
   - Screenshots of Azure Storage Services (at least 5 records each)  
4. Follow the file naming convention:  
   `StudentNumber_ModuleCode_Part#.docx`  
   Example: `ST10457455_CLDV6212_Part1.docx`  

---

## Notes

- Focus on scalability, reliability, and cost-effectiveness for all Azure services.  
- Test all functionalities locally before deploying to Azure.  
- Use the GitHub repository to maintain version control throughout the project.

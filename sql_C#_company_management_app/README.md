# 🧰 Plumbing & Electrical Company System (SQL + C#)

### About the Project
A comprehensive relational database system and desktop application designed to manage the daily operations of a plumbing and electrical services company developed as the mini project for the **Databases** course. It was built to solve real-world logistical challenges, from tracking ongoing services and allocating physical resources to automating inventory management and invoicing.

### 🤝 Team & Division of Labor
This system was built as a collaborative, full-stack team project:
* **Guilherme Almeida (Me) - Database Architect:** Responsible for the entire backend architecture. This included designing the schema, ensuring BCNF normalization, and writing all DDL/DML scripts, Stored Procedures, and Triggers.
* **José Cerqueira - Frontend Developer:** Responsible for developing the C# desktop application and wiring the user interface to the SQL database.

### ⚠️ Deployment Note
The C# desktop application source code is provided as an archive of the original academic submission. It was configured for the local database environment used during development and will require connection string updates to execute properly on a new machine. The primary focus of this repository is the SQL database architecture.

---

### 🏗️ System Architecture

#### 1. The Database Backend (My Focus)
The database was carefully designed with performance and data integrity in mind:
* **Normalization:** The relational schema is fully normalized to the Boyce-Codd Normal Form (BCNF) to eliminate data redundancy.
* **Automated Business Logic:** Relies heavily on advanced SQL programming to handle complex rules (e.g., stock depletion, invoice generation) natively within the database, minimizing the logic required on the C# frontend.
* **Indexing:** Custom indexes (`idxMCod`, `idxSNo`, `idxENo`) were implemented on high-traffic tables to optimize query times.

**Entity-Relational Diagrams:**
*(Diagrams illustrating the database structure)*
![ER Diagram](er.jpg)
![DER Diagram](der.jpg)

#### 2. The Frontend Application (C#)
A desktop GUI built in C# that serves as the control panel for administrative staff. It allows users to quickly allocate resources (employees, vehicles, materials) to specific services, check warehouse stock, and create supplier orders without needing to write raw SQL queries.

---

### 🎥 Live Demonstration
To see the full system in action, including the C# application triggering the backend SQL logic, please view the demonstration video included in this repository:
* **[`Video_Apresentacao.mp4`](Showcase_Video.mp4)**

### 📂 Repository Structure
* **`/database/sql01_ddl.sql`**: Data Definition Language scripts for table and schema creation.
* **`/database/sql02_inserts.sql`**: Data Manipulation Language scripts containing dummy data to populate the system.
* **`/database/sql03_sp_functions.sql`**: Stored procedures and custom functions for business logic.
* **`/database/sql04_triggers.sql`**: Event-driven triggers for automated system updates.
* **`/app/`**: Contains the C# source code and project files for the desktop application.
* **`RelatorioBD_76758_120069.md`**: The official academic report detailing the project requirements and development process.
* **`APTF_P7G7.pdf`**: The official academic slides presentation detailing the project requirements and development process.

### 🛠️ Tech Stack
* **Database:** SQL (DDL, DML, Indexes)
* **Backend Logic:** Stored Procedures, Triggers, User-Defined Functions
* **Frontend:** C# Desktop Application
* **Design Principles:** BCNF Normalization, Relational Modeling, Client-Server Integration
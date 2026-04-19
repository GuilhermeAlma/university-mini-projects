# 🫀 Heart Attack Data Analysis

### About the Project
This project is a statistical data analysis pipeline developed for the Biomedical Statistics course. It explores a medical dataset to uncover the relationships between clinical variables and heart attack outcomes. The study heavily utilizes simple and multiple linear regression, as well as logistic regression, to identify which biomarkers and patient features serve as the strongest predictors.

### 🔬 Analysis Pipeline
* **Data Preparation:** Processes a dataset containing variables like Age, Gender, Heart rate, Blood pressure, Blood sugar, CK-MB, and Troponin. Includes filtering steps to remove specific outliers before applying linear models, and creates a binary numerical response variable (`1` for positive, `0` for negative).
* **Linear Regression:** Models continuous clinical variables. For example, it evaluates if age explains blood sugar levels (Simple) and estimates heart rate based on a combination of CK-MB and blood pressure (Multiple).
* **Logistic Regression:** Calculates the probability of a heart attack occurrence. It ranges from simple models (using only Troponin levels) to complex multiple regression models incorporating age, gender, and all available cardiac biomarkers.
* **Model Diagnostics:** Interprets coefficients, odds ratios, and confidence intervals to determine statistical significance. It also rigorously checks regression assumptions (normality, independence, constant variance) using residual analysis, Shapiro-Wilk tests, and Q-Q plots.
* **Key Findings:** Concludes that cardiac biomarkers, specifically Troponin and CK-MB, are the most reliable indicators for predicting the probability of an infarction.

### 📂 Project Files
* **`EB.ipynb`**: The main R notebook containing the entire workflow, from data ingestion to model diagnostics. Note: AI tools were used to streamline and simplify small parts of the code within this notebook.
* **`Medicaldataset.csv`**: The raw dataset containing the clinical observations used for the study.
* **`slides_eb.pdf`**: The presentation slides summarizing the methodology, statistical findings, and final academic conclusions.

### 🛠️ Tech Stack
* **Language:** R
* **Environment:** RStudio or Jupyter Notebook (with R kernel)
* **Core Concepts:** Linear Regression, Logistic Regression, Residual Diagnostics, Odds Ratios.
* **Key Functions:** `lm()`, `glm()`, `summary()`, `confint()`, `shapiro.test()`, `qqnorm()`, `qqline()`

### 🚀 How to Run Locally
1. Clone this repository or download the files.
2. Ensure that `Medicaldataset.csv` and `EB.ipynb` are located in the exact same folder.
3. Open `EB.ipynb` in an R-enabled notebook environment or directly in RStudio.
4. Run the notebook cells sequentially to reproduce the statistical models and diagnostic plots.
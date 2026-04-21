# 🪐 NASA Exoplanets Data Analysis

### About the Project
This project is a data analysis notebook built in Python to explore exoplanet data from NASA. It uses a dataset of over 5,000 exoplanets, including attributes such as distance, planet type, orbital characteristics, and detection methods.

The goal of the project was to investigate real scientific questions around exoplanets, focusing on distribution, habitability, physical relationships, and how discovery trends have evolved over time.

(Note: This project was developed in an academic context and focuses on exploratory data analysis and visualization.)

---

### ⚙️ Core Features
The analysis is structured around a set of key questions:

* **1. Most common exoplanet type:** Identifies dominant planet categories and compares them conceptually to Solar System analogs.
* **2. Earth-like planets & habitability:** Filters planets within a defined orbital range (0.9–1.5 AU) to estimate potentially habitable candidates.
* **3. Mass vs radius relationship:** Explores correlation between planetary mass and radius.
* **4. Detection methods vs planet types:** Examines how discovery techniques influence observed planet distributions.
* **5. Discoveries over time:** Tracks how exoplanet discoveries have grown across years.

---

### 📊 Key Findings
* **Gas giants dominate discoveries:** Larger planets are significantly overrepresented due to detection bias.
* **Earth-like planets are relatively rare:** Only a small fraction fall within the defined habitable orbital range.
* **Mass and radius show a positive correlation:** Larger planets generally have greater mass, though with variability depending on composition.
* **Detection methods influence results:** Certain methods (e.g., transit, radial velocity) are biased toward detecting specific planet types.
* **Discovery rate has increased sharply:** Advances in technology and methods have accelerated exoplanet discoveries over time.

---

### 🛠️ Tech Stack
* **Language:** Python  
* **Libraries:** `pandas`, `matplotlib`  
* **Environment:** Jupyter Notebook  
* **Dataset:** NASA Exoplanets dataset (CSV format)  

---

### 🚀 How to Run Locally
1. Make sure you have Python installed.
2. Install required libraries.
3. Clone this repository or download the files.
4. Ensure `Exoplanets.csv` is in the same directory as the notebook.
5. Open the `.ipynb` file using Jupyter Notebook or JupyterLab.
6. Run all cells to reproduce the analysis.

---

### 📊 Dataset Structure
The dataset includes:

1. `name` — Exoplanet name  
2. `distance` — Distance from Earth  
3. `stellar_magnitude` — Host star brightness  
4. `planet_type` — Planet category  
5. `discovery_year` — Year discovered  
6. `mass_multiplier` — Relative mass  
7. `mass_wrt` — Mass reference  
8. `radius_multiplier` — Relative radius  
9. `radius_wrt` — Radius reference  
10. `orbital_radius` — Distance from star  
11. `orbital_period` — Orbit duration  
12. `eccentricity` — Orbital shape  
13. `detection_method` — Discovery method  

---

### 📌 Notes
* Earth-like classification was approximated using planet type and orbital radius.
* A simplified habitable zone (0.9–1.5 AU) was used for analysis.
* Results are influenced by observational bias in detection methods.

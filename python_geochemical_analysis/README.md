# 🪨 Geochemical Data Analysis 

### About the Project
This project is a Command-Line Interface (CLI) application built in Python for analyzing geochemical data. It reads sample coordinates and chemical compound concentrations from a dataset, allowing users to perform statistical analysis, visualize data distributions, classify rock types, and compute optimized geographical sampling routes.

(Note: This was my first ever python project, it's quality is not a representative of my current capabilities)

### ⚙️ Core Features
The application is driven by an interactive 9-option menu:

* **1. Load geochemical data from file:** Reads tab-separated values from `geoq.csv`, automatically handling missing data entries (e.g., filtering out `-99999` values for MgO).
* **2. Display basic statistics for an element:** Calculates the minimum, maximum, and mean for any selected chemical compound (SiO2, Fe2O3, CaO, MgO).
* **3. Create scatter plot:** Generates customizable scatter plots to visually compare the relationship between two selected chemical elements.
* **4. Create histogram:** Displays the frequency distribution of a single element across user-defined classes.
* **5. Generate granite type map:** Geographically maps the samples, classifying them dynamically based on their Calcium Oxide (CaO) content. Samples with CaO < 2% are categorized as Granite Type I, while the rest become Granite Type II.
* **6. Generate sampling route:** Calculates and plots the sequential distance of the original, real-world sampling route.
* **7. Generate alternative sampling routes:** Utilizes a Nearest Neighbor heuristic algorithm to calculate two more efficient paths, outputting a side-by-side visual comparison using `matplotlib` subplots against the real route.
* **8. Check and remove duplicates:** Scans the dataset for duplicate geographic coordinates, alerting the user and offering the option to safely remove them from the active data dictionary.
* **9. Exit:** Safely terminates the CLI application.

### 🛠️ Tech Stack
* **Language:** Python
* **Libraries:** `matplotlib.pyplot` (for plotting), `math` (for distance calculations), `collections` (for duplicate detection).

### 🚀 How to Run Locally
1. Ensure you have Python installed on your machine.
2. Install the required plotting library by running: `pip install matplotlib`
3. Clone this repository or download the files.
4. Verify that `geoq.csv` and `IP.py` are located in the exact same folder.
5. Open your terminal or command prompt, navigate to the folder, and execute the script:
   `python IP.py`

### 📊 Dataset Structure
The script expects a tabular file (`geoq.csv`) with the following columns:
1. `X`: Geographic X coordinate
2. `Y`: Geographic Y coordinate
3. `SiO2`: Silicon dioxide percentage
4. `Fe2O3`: Iron(III) oxide percentage
5. `CaO`: Calcium oxide percentage
6. `MgO`: Magnesium oxide percentage
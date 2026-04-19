# 🎯 MATLAB Projectile Motion Game

### About the Project
This mini-project is an interactive educational game and physics simulator built using MATLAB App Designer for the **Simulation and Modelling** course. It models 2D projectile kinematics, allowing users to launch a projectile and hit various targets by calculating and adjusting the initial velocity and launch angle. 

### ⚙️ Core Features
* **Planetary Physics:** Simulates gravity across different celestial bodies (Earth, Mars, Jupiter, Pluto, Moon), dynamically updating the gravitational acceleration.
* **Progressive Game Modes:** 
  * **Simulator:** A sandbox mode that plots the full parabolic trajectory.
  * **Levels 1 to 5:** Progressive difficulty stages introducing static targets, blocking walls, vertically moving targets, and mandatory spatial checkpoints.
* **Real-Time Animation:** Renders the projectile's flight path frame-by-frame on the UI Axes, visually drawing the velocity vectors during the trajectory.
* **Collision Detection:** Continuously tracks the X and Y coordinates at each time step to determine if the projectile successfully hits the target or collides with an obstacle.
* **Dynamic Feedback:** Triggers custom graphic overlays to display victory or defeat depending on the flight outcome.

### 📂 Project Files
* **`sm_game.mlapp`**: The main MATLAB application file containing the UI layout, components, and backend callback logic.
* **`Relatorio.pdf`**: The official project report detailing the underlying physics equations, application architecture, and development process.
* **`YOUWON.PNG` & `YOULOST.png`**: Graphical image assets loaded by the application upon completing or failing a level.

### 🛠️ Tech Stack
* **Environment:** MATLAB App Designer
* **Core Concepts:** Event-driven programming, kinematics, 2D plotting, conditional logic, and simple collision physics.

### 🚀 How to Play Locally
1. Clone this repository or download the files.
2. Ensure `sm_game.mlapp`, `YOUWON.PNG`, and `YOULOST.png` are stored in the exact same folder.
3. Open MATLAB and navigate to that folder in your workspace.
4. Double-click `sm_game.mlapp` to open it in App Designer, then click the **Run** button.
5. Select your desired celestial body and level from the dropdown menus.
6. Click **Início** to render the map and obstacles.
7. Set your initial velocity and angle using the input fields, then click **Lançar** to fire!
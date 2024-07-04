# VRescue
## Virtual Reality Medical Simulator
### Members: Ronald Alhazov and Ohad Goldberg

### Introduction
This project aims to develop a virtual reality medical simulator designed to simulate a variety of basic medical scenarios and their treatments. The central concept involves mapping a physical mannequin into a virtual environment to create realistic medical scenarios.

### Problem Statement and Significance
In recent months, both team members participated in conflicts in Israel and experienced firsthand the critical importance of medical operations on the battlefield. Timely medical interventions were observed to have a significant impact on outcomes and the ability to save lives. This project aims to underscore the importance of medical operations and enhance success rates for those performing medical procedures in real-life situations. Individuals often find themselves in situations where they need to perform medical actions, and utilizing simulations can potentially increase success rates.

### Objectives
1. Develop a realistic virtual environment for simulating medical scenarios.
2. Integrate a physical mannequin into the virtual environment to provide a hands-on experience.  
3. Create a range of medical scenarios with varying levels of complexity.
4. Implement a scoring and feedback system to evaluate user performance.
5. Provide an accessible platform for non-professionals to practice medical procedures.


### Game interface
Game users:
One user that gives the medical treatment. The main player is part of a situation in which he functions as a one of others and not necessarily the one who leads the situation (for example : the one who seats next to driver) and he actually performs the medical treatment on the person he is called upon to treat.

### Screens Structure
1.Main menu
1.1. Check the mannequin and equipment is connected.
1.2. Select medical scenario.
 1.2.1. Driving accident.
 1.2.2. Battle field.
1.3. Check my treatment history and medical information.
1.4. Exit.

### Screen overview
#### Main menu 
The game main menu will display the home screen of the simulator where the player can choose the option he wants. check the mannequin and VR equipment, select medical scenario, treatment history or exit.

### Methodology
For this project, we'll be using a mix of hardware and software to make a virtual reality medical simulator. The main parts we'll need are a main processing unit like Raspberry Pi or Arduino uno as the main computer, an ESP32 or Arduino microcontroller for connecting sensors, a motion sensor like MPU6050, and a VR kit so users can experience it in virtual reality.
The main processing unit will be the brain of the system, running the Unity game engine and handling all the main simulation stuff. In the Unity platform we will create the virtual environment and let users interact with the 3D medical scenarios.
To track the movements of the physical mannequin, we'll attach an motion sensor to it. An ESP32 or Arduino Uno can be the sensor controller, connecting to the motion sensor , processing the raw sensor data, and sending it over to the main processing unit through a wired or wireless connection.
The main processing unit will constantly get this real-time motion data from the microcontroller and use it to update the position and movements of the virtual mannequin inside the Unity environment. This way, the virtual mannequin will mimic the exact movements of the physical one.
With the VR kit, users can interact with mannequin and to perform the medical treatment.

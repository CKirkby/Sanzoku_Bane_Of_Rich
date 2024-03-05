# Saznoku - Bane of the Rich

Important Scripts: 

Enemy AI - Can be found at Assets -> Enemy -> Scripts -> PirateStateMachine: 
       The enemy AI uses a finate state machine to control its patrolling, searching and agressive modes depending on whether the player has been seen or not. 

Enemy FOV - Can be found at Assets -> Enemy -> Scripts -> PirateFOV: 
       The enemy will perform a raycast in the shape of a cone and if the player enters this will activate the detection scripts. 

Detection - Can be found at Assets -> Game Manager -> DetectionHandler: 
       Activates the relevant UI and functions depending on whether the player has been targeted or fully revealed to the enemy. 

Player Related Scripts can be found at Assets -> Player -> Scripts:
       All the primary player functions can be found here, including the controller, the player health and the player inventory. 

Game Manager Related scripts including UI can be found at Assets -> Game Manager: 
       The scripts here are what control the game behind the scenes. Including all the UI and menus. The audio manager is also present here. 

       

 (Pirate names occured as the theme used to be pirates but I changed the theme to samurai and did not change script names)

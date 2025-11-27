# Floccinaucinihilipilification

Programmer/Designer: Alexander Bean - 100927087 (Working Solo)


## PROTOTYPING:
1. Singleton: Creating a camera fade to transition to different areas (from inside a home to outside)
2. Dirty Flag: Loads objects that are within a certain distance to the player (optimization)
3. Observer: Gets the NPC's dialog and displays it to the screen
4. Command: Used to go back to previous dialog

## Diagrams

dirty flag
observer


## Implementation Explaination

Singleton: used for the camera fade. Prevents there from being multiple fades at a time, giving the transitions a smoother feeling
Dirty Flag: used for loading certain parts of the play area at a time. Helps with performance
Observer: used for the NPC's dialog logic. Keeps the NPC script clearer for other classes
Command: used to keep track of the dialog the player has gone through with the current NPC. allows them to go back to previous dialog

## External Assets Used: 

- [Playermovement](https://github.com/alvarojuq/ExamStarterUnity/blob/main/Assets/Scripts/Movement.cs)
- https://assetstore.unity.com/packages/3d/props/exterior/urban-building-130318
- https://assetstore.unity.com/packages/3d/props/basic-bedroom-starterpack-215986
- https://assetstore.unity.com/packages/3d/props/interior/hotel-room-collection-214335
- https://assetstore.unity.com/packages/3d/environments/urban/vrbn-studios-free-buildings-urp-bundle-001-264015
- https://assetstore.unity.com/packages/2d/textures-materials/nature/yughues-free-ground-materials-13001 

## Reference Scripts

learn.unity.com/tutorial/use-the-command-pattern-for-flexible-and-extensible-game-systems?uv=6&projectId=67bc8deaedbc2a23a7389cab# 
https://learn.unity.com/tutorial/dirty-flag-pattern


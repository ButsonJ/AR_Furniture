# Sydney AR

## General: 
Some files are too large for the free version of github. The full project is in the zip folder.
The scripts folder outlines our custom c# scripts.
The APK is a ready to go android APK
## Features

 Simple... Asset storage for Sydney's Capsone project, an AR application



## Tech

- [Blender] - Blender is used to created 3d objects
- [Unity] - App is built in unity with AR Core
- [visual studio community 2019] - For c# script edditing

### Roadmap
Roadman for first semester
- [x] Set up initial VC
- [x] Place Object in 3d space (general)
- [x] Add lightweight VC laternative
- [x] Create Menue to set object in place
- [x] Implament Plae detection alternative
- [x] Implament plane detection alternitive
    - [x] AR plane alternative
    -  [x] Plane Garbage collection
- [x] Remove Objects
- [x] Research custom lighting options
- [x] Researching built in lighting options  
- [x] manipulate objects placed
- [x] Research and testing of recoloring walls
- [x] Source sample with object scale
- [x] Create first custom sample object
- [x] Link Furniture to external webstore
- [x] Filter assets by type and color
-  [x] Take picture of furniture and store file on device
## Versions
The version of everything we are running our unity project in
| Name | Version # |
| ------ | ------ |
| Unity Hub  | 3.1.1  |
| Platform | Anrdoid (adjust in build settings) |
|Anroid ETC2 Fallback  |32-bit (default)  |
| Compression Method | LZ4 |
| Texture Compression | Don't Override |
| AR Foundation | 4.1.7 |
| AR Core XR Plugin | 4.1.7  |
| Input System  | 1.2.0 |
| Active Input Handling | Both |
| Android  | Nugat (API 24)  |
| Vulkan  | Dissabled --- correct? | 
| TextMeshPro |  TMP Essential Resources |
|2D Animation | 5.0.10 |
|2D Pxiel Perfect | 4.0.1 |
|2D PSD Importer | 4.1.3 |
|2D Sprite | 1.0.0 |
|2D Sprite Shape | 5.1.7 |
|2D Timemap editor | 1.0.0 |
|Adaptive Preformance | 2.2.3 |
| Adaptive Preformance Samsung androoid | 2.2.2 |
| Addresssables | 1.18.19  |
| Advertisement | 3.7.5 |
| Alembic | 1.0.7 |
| Analytics Library | 3.6.12 |
| Android Logcat | 1.2.3 |
| Animation Rigging | 1.0.3 |
| Burst | 1.4.11 |
|Cinemachine | 2.6.11 |
|Code Coverage | 1.1.1 |
|Core RP Library | 10.7.0 |
|DOTween (HOTween v2) | 1.2.632 |
|Editor Coroutines | 1.0.0 |
| FBX Exporter | 4.1.2 |
|High Definition RP | 10.7.0 |
|In App Purchasing | 4.0.3 |
|JetBrains Rider Editor |2.0.7  |
|Magic Leap XR Plugin |6.2.2  |
|Mathematics | 1.2.5  |
|ML Agents | 1.0.8 |
|Mobile Notifications | 1.4.2 |
|Multiplayer HLAPI | 1.1.1  |
|Polybrush | 1.0.2  |
|Post Processing | 3.2.1 |
|ProBuilder | 4.5.2 |
|Profile Analyzer | 1.1.1 |
|Quick Search | 2.0.2 |
|Remote Config |1.4.0  |
|Scriptable Build Pipeline | 1.19.6  |
|Serialized Dictionary Lite | 2.6.9.4 |
|Shader Graph | 10.7.0 |
|Test Framework | 1.1.29  |
|TextMeshPro | 3.0.6 |
| Timeline| 1.4.8 |
|Tutorial Framework |1.2.3  |
|Unity Distribution Portal | 2.0.0 |
|Unity Recorder | 2.5.7 |
|Unity UI | 1.0.0 |
|Universal RP | 10.7.0 |
|Visual Effect Graph | 10.7.0 |
|Visual Studio Code Editor | 1.2.5 |
|Visual Studio Editor | 2.0.14 |
|WebGL Publisher | 4.2.3 |
| Windows XR Plugin|  4.6.1|
|Xiaomi SDK | 1.0.3 |
|XR Interaction Toolkit | 2.0.1 |
|XR Plugin Management | 4.2.0 |



## Installation

download the asset file. 
Upload it to your unity AR dev enviorment with the specifed version (outlined above)
verify scripts are linekd: [NOTE TO DEV'S ADD WHERE AND HOW YOUR SCRIPT SHOULD BE LINEKD, UNITY ASSET FILE IMPORT WONT ALWAYS LINK THE SCRIPT]

#### For file assets_juan_march29.unitypackage 

This file is the official file we are going to build the first iteration of the capstone project. There are placeholder buttons and screens in which I will mention below.
I will also mention where and how each script is implemented. For the most part, it follows the textbook on how the scene is structured.

| Object | Script | Notes |
| ------ | ------ | ---------------------------------------------------------------------------------------------------------------- |
|AR Session Origin |AR Session Origin, AR Plane Manager, AR Raycast Manager |Plane prefab set to ARPlane and detection Mode Everything |
|UI Canvas |UI Controller |A dictionary of id's of the canvas groups (i.e. screens) |
|Main UI (under UI Canvas) |OnClick |Using the Interaction Controller object and selecting InteractionController.EnableMode, the text box should say SelectObject |
|Select Object UI |OnClick |The buttons under this UI should have two onclick actions. The first one is using the placeobject mode game object from scene and using PlaceObjectMode.SetPlacedPrefab. The asset is the corresponding asset for that button. The second onlcick action is the same as previous but wil PlaceObject in the text box. |
|Interaction Controller|Interaction Controller Script |Dictionary of id's of the game object modes found within the Interaction Controller |
|All the modes under Interaction Controller| Matched with their corresponding script | |

If you have any questions or problems, let me know and I can clear things up.

Placeholder objects are the buttons to select which furniture item to place.
There is a package called 'Toon Furniture' that is just a placeholder for furniture assets to use. If you find better assets, please import those assets instead.

## Development
 Currently in closed development for duration of capstone project.
## License

MIT

[Unity]: <https://unity.com/>
[Blender]: <https://www.blender.org/download/>
[visual studio community 2019]: <https://visualstudio.microsoft.com/downloads/>

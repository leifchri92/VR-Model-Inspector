# Virtual Reality Model Inspector (VRMI) #
This repository contains code accompanying the publication:
	[Citation or link to publication](www.google.com)

## How To Use ##

### Requirements: ###
* VR Headset with controllers (HTC Vive or Oculus Rift)
* [Unity](https://unity3d.com/)
* [SteamVR](https://store.steampowered.com/steamvr)

### Running ###
Download the git repository and open the root folder with Unity.

To add a model to the app:
1. [Import the 3D model into Unity.](https://docs.unity3d.com/540/Documentation/Manual/HOWTO-importObject.html)
2. Drag the model into the scene, scale and rotate it accordingly, and apply any materials.
	* [In the case of .obj files, textures may be applied with the .mtl file](Make sure to apply any textures and materials. [This can be done with an .mtl file.](https://www.youtube.com/watch?v=uoxSUFdkv7Y))
3. Set the tag on the model GameObject, and all of its children, to "Transformable".
4. Create a prefab from the model GameObject and place it in the Resources/Models folder.
	* To create a prefab, drag the GameObject from the [Hierarchy window](https://docs.unity3d.com/Manual/Hierarchy.html) inspector into the [Project window](https://docs.unity3d.com/Manual/ProjectView.html).
5. Run the app and all prefabs in the Resources/Models will be loaded automatically.

### Interaction ###

## Building the App ##
Once models have been added to the scene, you may build the project as a standalone executable.

A sample builds are available in the "Builds" folder.

## Improvements ##

# Virtual Reality Model Inspector (VRMI) #
This repository contains code accompanying the publication:

[M. Brennan and L. Christiansen, *Virtual Materiality: A Virtual Reality Framework for the Analysis and Visualization of Cultural Heritage 3D Models*, in The Proceedings of Digital Heritage 2018, forthcoming.](https://github.com/leifchri92/VR-Model-Inspector/blob/master/Brennan_Christiansen_DH18.pdf)

## How To Use ##

### Requirements: ###
* [HTC Vive](https://www.vive.com/eu/)
* [Unity](https://unity3d.com/)
* [SteamVR](https://store.steampowered.com/steamvr)

### Running ###
Download the git repository and open the root folder with Unity.

To add a model to the app:
1. [Import the 3D model into Unity.](https://docs.unity3d.com/540/Documentation/Manual/HOWTO-importObject.html)
2. Drag the model into the scene, scale and rotate it accordingly, and apply any materials.
	* [In the case of .obj files, textures may be applied with the .mtl file](https://www.youtube.com/watch?v=uoxSUFdkv7Y))
3. Set the tag on the model GameObject, and all of its children, to "Transformable".
4. Create a prefab from the model GameObject and place it in the Resources/Models folder.
	* To create a prefab, drag the GameObject from the [Hierarchy window](https://docs.unity3d.com/Manual/Hierarchy.html) inspector into the [Project window](https://docs.unity3d.com/Manual/ProjectView.html).
5. Run the app and all prefabs in the Resources/Models will be loaded automatically.

### Interaction ###
To interact with the menu connected to your left hand, using the right controller, touch the touch pad with your thumb to begin interaction and pull the trigger to select.

#### Add Models and Lights ####
Click "Add" in the "Models" menu to add models and lights. Click a model or light thumbnail to add it to the scene. Once a model is in the scene, you may set the scale of the model using the set scale button.

#### Set Scale ####
Select two points on the object. Then using the numbpad on the left, enter the real world scale, in meters, of the selected distance. Finally, select "Rescale" to resize the object.

#### Transform ####
Select models to translate and rotate using the appropriate gizmos.

#### Properties ####
With "Properties" selected, you may change the materials of models and properties of the color, range, intensity, and angle of lights.

## Building the App ##
Once models have been added to the scene, you may build the project as a standalone executable for any number of platforms supported by Unity. Interaction has only been tested for the HTC Vive.

A sample builds are available in the "Builds" folder.

## Improvements ##
- [ ] Gizmo scaling
- [ ] Gestural scaling
- [ ] Saving model transformations
- [ ] Mirroring model transformations
- [ ] Additional headset support

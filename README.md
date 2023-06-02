# Unity-HDRP-Vioso-Template-Presenter
Unity HDRP template with Vioso integration for the Lablab studio.
Extended with a Presenter template with basic slide show, 360 player and 3D scene capability.

## Requirements
A powerful Windows PC is required to play the project.

For Mac: The Projection Setup system doesn't compile on Mac, but technically there's nothing keeping you from working in the project, as long as a Windows PC is the one that test it.

## Installation

1. Download or clone this project on your computer.

2. Download the Vioso calibration file [here](http://gofile.me/67omf/z4MSltLGp) and add it to the Assets/Plugins/Vioso/ folder.


## Testing the presenter template

Inside Assets/_Presenter/_Your Project there’s a scene file.

If you open and play that you should be able to use left/right arrow keys to go forward/backwards in 3 small chapters. Each chapter demos a simple use case:

1. Chapter 1: A basic slideshow on a black background. Use down/up arrows to go forward/backwards in the slides. There should also be general ambient sound playing. One of the slides should be a video with sound source. The source should somewhat sound like it comes from the position of the slide.

2. Chapter 2: A simple 360 player. Should have some sound playing too.

3. Chapter 3: A 3D world with a timeline that should automatically animate the camera rig to first fly forward, then sideways and then forward and vertically up. It also contains volumetric clouds.


## Working with the presenter template
1. Open the "Presenter Scene" file inside Assets/_Presenter/_Your Project.

2. Unfold the "---SETTINGS---" and "---SCENE---" objects in the scene hierarchy.

3. To create a new chapter, add a Chapter prefab from "Assets/_Presenter/Prefabs" and assign it to the Chapter List in the "Presenter Settings" object. The order in "Presenter Settings" defines the order the chapters will play in when using the Left/Right arrows. Anything nested under a Chapter prefab will be toggled on/off. You are not limited to slides or 360 videos. You can place anything there.

4. Whatever you do, the main rule to folllow is: Everything should be nested underneath a Chapter prefab. Nothing outside!



### Add a Slideshow
_Look in Chapter 1 for inspiration_

The slideshow system is simple. It's either a 16:9 image texture or a 16:9 video.

1. From Assets/_Presenter/Prefabs, nest a "Slideshow" prefab under a "Chapter" prefab in your scene.

2. Add Image and Video slides under the "Add slides under this" element. The order of slides in the hierarchy defines the order the slides will appear when using the Up/Down arrows while the slideshow is visible.

**To add an image slide:**
1. Import a 16:9 image somewhere into Assets/_Presenter/_Your Project

2. From Assets/_Presenter/Prefabs, nest a "SlideShow ImageSlide" prefab under the "Add slides under this" element in a "Slideshow" prefab.

3. Assign the imported image to the "SlideShow ImageSlide" texture field in the inspector.

**To add a video slide:**
1. Place a 16:9 video in the Assets/StreamingAssets folder.

2. Open Assets/_Presenter/_Your Project/Video and duplicate the "Mandalorian Video" media reference and rename it. Then while having it selected, in the inspector change the Media Reference to be the exact same name of the video file in the streamingAssets folder.

3. From Assets/_Presenter/Prefabs, nest a "SlideShow VideoSlide" prefab under the "Add slides under this" element in a "Slideshow" prefab.

4. In the inspector for the VideoSlide assign the Media Reference you created before under Settings > Source > Media Reference.


### Add a 360 image
_Look in Chapter 2 for inspiration_

1. Optional: Generate a 360 image using skybox.blockadelabs.com. Download it to your computer.

2. Import a 360 image somewhere into Assets/_Presenter/_Your Project.

3. In the image settings, change the Max Size to 8192.

4. From Assets/_Presenter/Prefabs, nest a "360 Image" prefab under a "Chapter" prefab in your scene.

5. In the inspector for the 360 Image scroll to the bottom and unfold the Material and assign the 360 image to the texture field.


### Add a 360 video player
_Look in Chapter 3 for inspiration_

1. Place a 360 video in the Assets/StreamingAssets folder.

2. Open Assets/_Presenter/_Your Project/Video and duplicate the "Mandalorian Video" media reference and rename it. Then while having it selected, in the inspector change the Media Reference to be the exact same name of the video file in the streamingAssets folder.

3. If your 360 video is in stereo, change the Stereo Packing setting to Top Bottom (It's usually this packing).

4. From Assets/_Presenter/Prefabs, nest a "360 Player" prefab under a "Chapter" prefab in your scene.

5. In the inspector for the 360 Player assign the Media Reference you created before under Settings > Source > Media Reference.


### Add custom objects to a chapter
As mentioned earlier, anything can be placed inside a Chapter prefab and will be toggled On/Off when using the Left/Right arrows. That said we made a few tools:

**To add ambient sound to a chapter**

1. Import a stereo sound somewhere into Assets/_Presenter/_Your Project.

2. From Assets/_Presenter/Prefabs nest the "Ambient Sound" prefab under a "Chapter" prefab in your scene.

3. In the inspector, assign your imported sound to the Audio Source. The sound should sound like it's coming from all around.

**To add positional sound to a scene**

1. Import a mono sound somewhere into Assets/_Presenter/_Your Project.

2. From Assets/_Presenter/Prefabs nest the "Positional Sound" prefab under a "Chapter" prefab. Place it where you would like the sound to come from.

3. In the inspector, assign your imported sound to the Audio Source. The sound should sound like it's coming from a specific position.

**To animate the camera movement**

_Look in Chapter 4 for inspiration_

1. From Assets/_Presenter/Prefabs, nest a "Camera Positioner" prefab under a "Chapter" prefab in your scene.

2. Animate the "Camera Positioner" position and rotation using whatever method you prefer, fx the build in Timeline system.

3. When the "Camera Positioner" changes position or rotation, it will automatically update the Projection Setup's camera rig. It will reset back to its default position when changing chapter.

**To change cloud and ambience**

_Look in Chapter 4 for inspiration_

1. Each "Chapter" prefab contains a "Volume" component in the inspector.

2. By default they are all assigned the same "Ambience Disabled" profile, but if you look inside Assets/_Presenter_Your Project/Ambience you will see another profile called "Clouds and Ambience".

3. In any Chapter, if you replace the "Ambience Disabled" profile with "Clouds and Ambience" that chapter will get natural looking clouds.

4. If you want to change the clouds, it's recommended to duplicate the "Clouds and Ambience" file and rename it to something else and then assign that. That way you can have many different clouds and ambience looks without running into problems with overwriting other chapters ambience.


### To debug the projection walls ###
By default, when you press play, the projection walls are disabled.

If you want to preview them while the scene plays, for debug purposes, select the "Presenter Settings" object in the hierarchy and toggle on "Render Debug Screens"





## Manual Projection Setup Usage
This should not be necessary for participants to follow, but if you need it, it's here.

### ProjectionSetup prefab

The projection setup for the Lablab studio is created in the ProjectionSetup prefab located in the ProjectionSetup/Lablab/Prefab/ folder.

![](https://github.com/Theoriz/Unity-HDRP-Vioso-Template/blob/main/Resources/Documentation/Screenshots/ProjectionSetupPrefab.jpg)

Add this prefab to your scene and disable other cameras in order to setup your scene for projection in the Lablab studio.

For example in the SampleScene, this projection setup as been added to the First person controller to replace the default camera of the First person controller.

![](https://github.com/Theoriz/Unity-HDRP-Vioso-Template/blob/main/Resources/Documentation/Screenshots/ProjectionSetupInSampleScene.jpg)

### Game View setup

To work with the Lablab video projectors setup, the Unity application creates 3 full screen windows. The window on display 1 is for the wall outputs, the window on display 2 is empty as it is the monitoring display, the window on display 3 is for the floor outputs.

To previsualize this in Unity, you need to set your game view(s) to render the display 1 (for the walls) and 3 (for the floor), at a 3840x2400 resolution.

With this setup, you should see the following output in the sample scene :

![](https://github.com/Theoriz/Unity-HDRP-Vioso-Template/blob/main/Resources/Documentation/Screenshots/OutputsMire.jpg)

### Using the studio model

In the ProjectionSetup prefab, the Lablab object is a 3D model of the studio for debugging purposes. It is enabled to help you visualize the physical space of the studio in your 3D world and validate the outputs. Once it is setup correctly, you can disable the Lablab component of the ProjectionSetup to see the final output of your scene.

![](https://github.com/Theoriz/Unity-HDRP-Vioso-Template/blob/main/Resources/Documentation/Screenshots/ProjectionSetupInSampleSceneMireDisabled.jpg)
![](https://github.com/Theoriz/Unity-HDRP-Vioso-Template/blob/main/Resources/Documentation/Screenshots/Outputs.jpg)

### Merging into your own project (optional)

1. Copy the Plugins, ProjectionSetup and Resources folders from this project to your own project Assets.

2. Add the ViosoWarpBlendPP and TextureBlitPostProcess to the After Post Process section of the HDRP Global Settings.

![](https://github.com/Theoriz/Unity-HDRP-Vioso-Template/blob/main/Resources/Documentation/Screenshots/HDRPGlobalSettings.jpg)

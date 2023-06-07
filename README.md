# Unity-HDRP-Vioso-Template-Presenter
Unity HDRP template with Vioso integration for the Lablab studio.
Extended with a Presenter template with basic slide show, 360 player and 3D scene capability.

- [Requirements](#requirements)
- [Installation](#installation)
- [Testing the presenter template](#testing-the-presenter-template)
- [Working with the presenter template](#working-with-the-presenter-template)
  * [Add a Chapter](#add-a-chapter)
  * [Add a Slideshow](#add-a-slideshow)
    + [To add an image slide](#to-add-an-image-slide)
    + [To add a video slide](#to-add-a-video-slide)
  * [Add a 360 image](#add-a-360-image)
  * [Add a 360 video player](#add-a-360-video-player)
  * [Add custom objects to a chapter](#add-custom-objects-to-a-chapter)
    + [To add ambient sound to a chapter](#to-add-ambient-sound-to-a-chapter)
    + [To add positional sound to a scene](#to-add-positional-sound-to-a-scene)
    + [To animate an objects position and rotation](#to-animate-an-objects-position-and-rotation)
    + [To animate the camera movement](#to-animate-the-camera-movement)
    + [To change cloud and ambience](#to-change-cloud-and-ambience)
    + [To import Mocap animations to a character](#to-import-mocap-animations-to-a-character)
  * [To debug the projection walls](#to-debug-the-projection-walls)
- [Manual Projection Setup Usage](#manual-projection-setup-usage)
  * [ProjectionSetup prefab](#projectionsetup-prefab)
  * [Game View setup](#game-view-setup)
  * [Using the studio model](#using-the-studio-model)
  * [Merging into your own project (optional)](#merging-into-your-own-project--optional-)

## Requirements
A powerful Windows PC is required to play the project.

For Mac: The Projection Setup system doesn't compile on Mac, but technically there's nothing keeping you from working in the project, as long as a Windows PC is the one that test it.

## Installation

1. Download or clone this project on your computer.

2. Download the Vioso calibration file [here](http://gofile.me/67omf/z4MSltLGp) and add it to the Assets/Plugins/Vioso/ folder.

3. To configure your window layout to an optimal one for this cave setup: In the top right corner of Unity click the dropdown click "Load Layout from File..." and select the "EUCL default.wtl" file. This should make it easy to see a first person camera view when you press play + see the cave projection cameras + sets a Timeline, Animation and Animator window.


## Testing the presenter template

Inside Assets/_Presenter/_Your Project there’s a scene file.

If you open and play that you should be able to use left/right arrow keys to go forward/backwards in through 4 small chapters with slides and timelines in them. Use up/down to skip chapters. Each chapter demos a simple use case:

1. Chapter 1: A basic slideshow on a black background. Use left/right arrows to go forward/backwards in the slides. There should also be general ambient sound playing. One of the slides should be a video with sound source. The source should somewhat sound like it comes from the position of the slide.

2. Chapter 2: A simple 360 image.

3. Chapter 3: A simple 360 player. Should have some sound playing too.

4. Chapter 4: A 3D world with 2 timelines. It starts in a paused state, but by pressing right, the first timeline plays (animates the camera position + enables a dancinc character). Press right again and the current timeline jumps to its end and the next timeline plays (a simple cube animating its position on top of a building). It also contains volumetric clouds and grading.


## Working with the presenter template
1. Open the "Presenter Scene" file inside Assets/_Presenter/_Your Project.

2. Unfold the "---SETTINGS---" and "---CHAPTERS---" objects in the scene hierarchy. Add chapters here.

### Add a Chapter

1. To create a new chapter, add a Chapter prefab from "Assets/_Presenter/Prefabs" and assign it to the Chapter List in the "Presenter Settings" object. The order in "Presenter Settings" defines the order the chapters will play in when using the Left/Right arrows. Anything nested under a Chapter prefab will be toggled on/off. You are not limited to slides or 360 videos. You can place anything there.

2. Whatever you do, the main rule to folllow is: Everything should be nested underneath a Chapter prefab. Nothing outside!

3. Using Down/Up you can skip chapters (Left/right will go through both chapters and slides/timelines)



### Add a Slideshow
_Look in Chapter 1 for inspiration_

The slideshow system is simple. It's either a 16:9 image texture or a 16:9 video.

1. From Assets/_Presenter/Prefabs, nest a "Slideshow" prefab under a "Chapter" prefab in your scene.

2. Add Image and Video slides under the "Add slides under this" element. The order of slides in the hierarchy defines the order the slides will appear when using the Left/Right arrows while the slideshow is visible.

#### To add an image slide
1. Import a 16:9 image somewhere into Assets/_Presenter/_Your Project

2. From Assets/_Presenter/Prefabs, nest a "SlideShow ImageSlide" prefab under the "Add slides under this" element in a "Slideshow" prefab.

3. Assign the imported image to the "SlideShow ImageSlide" texture field in the inspector.

#### To add a video slide
1. Place a 16:9 video in the Assets/_Presenter/_Your Project/Video folder.

2. From Assets/_Presenter/Prefabs, nest a "SlideShow VideoSlide" prefab under the "Add slides under this" element in a "Slideshow" prefab.

3. In the inspector for the VideoSlide, in the Media Player section click the little folder icon and select Browse and select your imported video.


### Add a 360 image
_Look in Chapter 2 for inspiration_

1. Optional: Generate a 360 image using skybox.blockadelabs.com. Download it to your computer.

2. Import a 360 image in the Assets/_Presenter/_Your Project/Images folder.

3. In the image settings for the imported image, change the Max Size to 8192.

4. From Assets/_Presenter/Prefabs, nest a "360 Image" prefab under a "Chapter" prefab in your scene.

5. In the inspector for the "360 Image" prefab assign the image you imported to the "Texture 360" field.

6. Optional: If you would like the 360 image to spin slowly, you can set a Rotation Speed in the inspector. Set i to 0 to disable it. By default it rotates horizontally around the Y axis, but feel free to pick a different axis.

Tip: If you want to show many 360 images after each other, like a "360 slideshow", simply add them to each of their own chapter.


### Add a 360 video player
_Look in Chapter 3 for inspiration_

1. Place a 360 video in the Assets/_Presenter/_Your Project/Video folder.

2. From Assets/_Presenter/Prefabs, nest a "360 Player" prefab under a "Chapter" prefab in your scene.

3. In the inspector for the 360 Player, in the Media Player section click the little folder icon and select Browse and select your imported video.


### Add custom objects to a chapter
As mentioned earlier, anything can be placed inside a Chapter prefab and will be toggled On/Off when using the Left/Right arrows. That said we made a few tools:

#### To add ambient sound to a chapter

1. Import a stereo sound somewhere into Assets/_Presenter/_Your Project.

2. From Assets/_Presenter/Prefabs nest the "Ambient Sound" prefab under a "Chapter" prefab in your scene.

3. In the inspector, assign your imported sound to the Audio Source. The sound should sound like it's coming from all around.

#### To add positional sound to a scene

1. Import a mono sound somewhere into Assets/_Presenter/_Your Project.

2. From Assets/_Presenter/Prefabs nest the "Positional Sound" prefab under a "Chapter" prefab. Place it where you would like the sound to come from.

3. In the inspector, assign your imported sound to the Audio Source. The sound should sound like it's coming from a specific position.

#### To animate an objects position and rotation

_Look in Chapter 4 for inspiration_

1. Add the object you  to the scene. Fx a cube.

2. From Assets/_Presenter/Prefabs, nest a "Timeline Collection" prefab under a "Chapter" prefab in your scene.

3. Right click the prefab and select "Create Empty"

4. Open the "Timeline" window fromt the top toolbar: Window > Sequencing > Timeline

5. The timeline window should have a "Create" button. Click it and save your new timeline inside Assets/_Presenter/_Your Project/Timelines

6. With the timeline window open, drag the object you want to animate into the left field and select "Add Animation Track"

7. Enable the red recorder button and move and rotate your object to animate its position

8. Move the timeline cursor to a different position and move your object to where you'd want it at this time.

Tip: You can create and add as many timelines as you want underneath the Timeline Collection. It will automatically let the user go through them using left/right keys.

Tip: You when you dragged in your object you could also have chosen "Add Activation Track". This would allow you to turn objects on/off at any given point in the timeline.

#### To animate the camera movement

_Look in Chapter 4 for inspiration_

1. From Assets/_Presenter/Prefabs, nest a "Camera Positioner" prefab under a "Chapter" prefab in your scene.

2. Animate the "Camera Positioner" like you'd animate any other object (see chapter above)

#### To change cloud and ambience

_Look in Chapter 4 for inspiration_

1. Each "Chapter" prefab contains a "Volume" component in the inspector.

2. By default they are all not assigned a profile, but if you look inside Assets/_Presenter/_Your Project/Ambience you will see another profile called "Clouds and Ambience".

3. Duplicate the "Clouds and Ambience" file every time you would like to have ambience in a Chapter

4. In any Chapter, if you replace set the profile to your "Clouds and Ambience" duplicate that chapter will get natural looking clouds and you can now adjust settings that will only affect this chapter.

#### To import Mocap animations to a character

_Look in Chapter 4 for inspiration_

This is quite a niche need with a few places things can go wrong, so you might have to troubleshoot some things on the way, but this could be one way to assign a Mocap recording:

1. You need two things: A recording (.fbx) and a rigged character (.fbx).

2. The recording can come from many places. Custom or generic. You can find generic ones to download for free from Mixamo.com.

3. The Character model needs a rigged skeleton. It's recommended to use a generic one from fx. Mixamo.com.

4. When you have your model and animation fbx files import both into Assets/_Presenter/_Your Project/Mocap

5. In the inspector for both model and animation, set the Rig > Animation Type to "Humanoid" and apply.

6. In the mocap folder, right click > Create > Animator Controller. Rename it.

7. Double click the Animation Controller file and right click in the canvas area > Create State > Empty

8. Select the New State and in the inspector where it says "Motion" assign the animation file (Note: it might be named something else than the animation you downloaded. If you unfold the animation fbx in the Mocap folder you can see the real name of the animation file)

9. Drag the Character into the scene view underneath a chapter.

10. In the inspector, it should have an Animator component already. In the "Controller" field assign your newly created Animator Controller to it.

Now your character should be animating with your custom mocap recording.



### To debug the projection walls
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

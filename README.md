UnityDomemaster
===============

Domemaster package for Unity. 
Updated for Unity 5. Now works with free version.


**Option #1 - 240 Degree Field of View**

This uses 5 cameras to project a 240 degree circular fisheye projection. The DomeCamera script automatically links to the camera which has the default tag "MainCamera". Alternatively, you can link the camera by assigning the "Target" property of the DomeCamera script. The Domemaster object can be positioned anywhere. Sprite-based particles and other effects do not render correctly.

To use:  
1. Import the "Domemaster" package.  
2. Open up the "5 Camera Rig" folder in the Assets tab.  
3. Drag the "Domemaster" prefab to the scene.  
4. Drag the "DomeCamera" prefab to the scene.  


**Option #2 - Camera Shader**

This applies a fisheye distortion and circular mask to a normal camera. It does not provide a wider field of view.  

To use:  
1. Import the "Domemaster" package.  
2. Open up the "Camera shader" folder in the Assets tab.  
3. Drag the "DomemasterFisheye.cs" script the camera in your scene.  
4. Drag the "DomemasterFisheyeShader.shader" to the "DomemasterFisheye.cs" script.  
5. Make sure the "DomemasterFisheye.cs" script is active.

Based on previous version by Paul Bourke:
http://paulbourke.net/dome/unity3d/



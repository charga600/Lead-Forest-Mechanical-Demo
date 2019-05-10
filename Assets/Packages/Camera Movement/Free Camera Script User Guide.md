# Free Camera Movement User Guide

This document describes the intended use of the CameraController.cs script as well as it's test scene

## Camera Controller

This script controls the lateral and vertical movement as well as y axis rotation of a free movement camera inside a game world. This script makes use of 3 standard Unity 3D ['input'] axes, Horizontal, Vertical and Mouse ScrollWheel, along with one custom axis Rotation which is designed to be bound to Q and E as the negative and positive input keys respectively. The value of these axes are read and stored each frame. There are also two public floats which act as modifiers for the movement speed of the camera, latMove and vertMove, and one for the rotational movement, rotMod.

Then the vector 3 values for each of the camera's directions are read and stored to later be multiplied by their respective directional modifiers. Firstly the camera's forward and right vectors have their Y value zeroed to prevent unwanted vertical movement. The forward vector is then multiplied by the the horizontal input axis value and the latMove modifier. The same multiplication is performed on the right vector but using the horizontal value instead of the vertical. Lastly the camera's up vector has it's x and z values zeroed as this will only control the camera's vertical movement. In a similar fashion to the previous two this is then  multiplied by it's respective input axis, Mouse ScrollWheel, and the vertical movement modifier, vertMove. These three vector three's are then added and applied to the camera using transform.Translate and applied in world space.

Lastly the rotation of the camera is modified by taking the current rotation of the camera as a vector 3 and adding the current input for the custom rotation input axis multiplied by the rotational modifier, rotMod. This adjusted value for the y rotation of the camera is then check to ensure it is within the bounds of 0 to 360 degrees and adjusted accordingly. Finally this modified rotation is applied to the camera.

**Intended use**: Free camera movement in a game world using player input and physics ['colliders'].

## Camera Scene

In this scene there is a large plane with a checkered material to provide a visual reference for the movement of the camera. There are also 8 Large cubes with colliders, positioned in a roughly octagonal pattern. All of these objects have physics colliders and are there to simulate a game world that might be countered by the the free movement camera.

['input']: https://docs.unity3d.com/ScriptReference/Input.html
['colliders']: https://docs.unity3d.com/Manual/CollidersOverview.html
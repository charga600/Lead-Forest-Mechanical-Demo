# Build Controller Package

This document explains how to use the scripts in this package as well as how they interact with each other.

## Scripts

['BuildController']
['GameController']
['ZoneCheckCon']

### BuildController

BuildController.cs is the primary part of this package. When build mode is activated (triggered by the ['GameController'].cs script) a ['raycast'] is sent out which tests if an area is suitable for building the a ['prefab'] ['object']. It moves a ['capsule'] collider to the where the mouse is point to in the game world and checks for a physics interaction between itself and objects not on the buildable ['layer']. If building is possible a alternative version of the model is displayed in the game world to give a review of where the object will be spawned. Then once the left mouse button is clicked a new instance of that object is ['instantiated'] in the game world.

**Intended use**: To check the viability of, review and then instantiate prefabs into the game world

### GameController

GameController.cs is a multifunction script which is designed to be used as the primary means of control over other scripts in the game world. While it primarily handles any pause game functions required by other scripts, in this instance it manages the activation of build mode. When the B key is pressed ths will activate build mode and allow the ['BuildController'].cs script to perform it's actions.

**Intended use**: Handle activation and deactivation of build mode for the '[BuildController'].cs script.

### ZoneCheckCon

ZoneCheckController or ZoneCheckCon.cs is a simple script which is placed on the placement detector object and is used to detect physics interactions between itself and other non-buildable objects in the game world.

**Intended use**: Be attached to the placement detector object to detect physics interactions

## Build Controller Scene

In this scene there is a large plane with a checkered material. There are also 8 Large cubes with colliders, positioned in a roughly octagonal pattern. All of these objects have physics colliders and are there to simulate a game world that might be countered by the the ['BuildController'].
There is also the placement detector object which has the ['ZoneCheckCon'].cs script and a capsule collider. The ['camera'] in the scene houses both the ['BuildController'] and['GameController'] scripts.

['BuildController']: #BuildController
['GameController']: #GameController
['ZoneCheckCon']: #ZoneCheckCon
['camera']: https://docs.unity3d.com/ScriptReference/Camera.html
['capsule']: https://docs.unity3d.com/Manual/class-CapsuleCollider.html
['instantiated']: https://docs.unity3d.com/ScriptReference/Object.Instantiate.html
['layer']: https://docs.unity3d.com/Manual/Layers.html
['raycast']: https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
['prefab']: https://docs.unity3d.com/Manual/Prefabs.html
['object']: https://docs.unity3d.com/ScriptReference/Object.html
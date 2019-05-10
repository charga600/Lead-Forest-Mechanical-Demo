# Node Navigator Package

This document explain how to correctly use the scripts in this package.

## Scripts

['NodeNavigator']
['HostileNode']
['StartEndNodeController']

### NodeNavigator

This Script forms the bulk of this package and is responsible for moving an unity across the node network. It is attached to a unity that you want to navigate around the node network. It requires two public variable to be set, a transform that will be it's starting node and a float defining it's speed. During runtime the object will then start moving towards the start node and upon impact with the node it will then retrieve the array from the nodes ['HostileNode'] script holding all the node that this node links to and randomly choose one of them move to next. The object is then orientated to look at the next node using ['LookAt']. The movement is handled in the ['FixedUpdate'] function. It retrieves the ['normalised'] vector for that transforms forward direction and then move the object in that direction relative to world space using the ['Translate'] function.

**Intended use**: Move an object through a node network in a random path.

### HostileNode

The HostileNode.cs script is placed on an object with a physics collider that will then function as a potential node in the navigation network. In gameplay terms, all it does is hold a public array of ['Transform']s that it links forward to. For ease of editing the node network it also has both ['OnDrawGizmos'] and ['OnDrawGizmosSelected'] which are used to display the forward connection of this node within the Unity Editor.

**Intended Use**: Hold and display the forward connection of a node in the navigator network.

### StartEndNodeController

A very short script which is to be placed on the last node in a node network (if an end node is needed) and will teleport a unity back to the start of the node network. Therefore it has one public transform which is to be set to th start node of the network.

**Intended Use**: Teleport an object of the network back to the start of said network.

### GameController

GameController.cs is a multifunction script which is designed to be used as the primary means of control over other scripts in the game world. While it primarily handles any pause game functions required by other scripts, in this instance it manages the the toggling of view the entire forward connections of the node network or just selected nodes by toggling of the public variable connectionModeOnly.

**Intended Use**: Toggle the visibility of all or selected forward node connections.

## Demo Scene

In this scene there is a large plane with a checkered material. There are also 8 Large cubes with colliders, positioned in a roughly octagonal pattern. There is also the node network itself, consisting of 11 nodes that make up the network, including a start and end node. Lastly there is the light attack vehicle with will be navigating the node.
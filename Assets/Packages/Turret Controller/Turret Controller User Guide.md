# Turret Controller Package

]Tis document explains how to correctly use and script in this package and how the interact with each other

## Scripts

['TCV2']
['TurretData']
['ShotLifetime']
['RaycastForward']
['GameController']

### TCV2

Turret Controller is the bulk of this package and handles a multitude of things. Primarily it moves a two part turret look at the nearest hostile to itself. This is done by taking the the targets position, calculating the lead point need to hit the target with data from the ['TurretData'].cs script, creating two ['planes'], one for each turret axis, and then calculating the point each of the turret parts needs to look at along it's respective plane to aim at the target. Each component is then rotated accordingly to hit the correct target.

The script also identifies the nearest target by testing the distance to each of the available targets and then targeting the closest one that it has a line of sight to. If it then has a firing solution of the target it will then fire a shot according to the type of shot it is firing. The script is told which type of turret it is by accessing the ['TurretData'].cs script which holds all of the possible turret types as well as their shot information.

**Intended Use**: Be places on a two part turret and be used to target another game object.

### TurretData

A simple, two part script which has a public array for the TurretType class which is also defined in the script and has 4 public variables, 1 string for the name of a turret, two floats for the cool-down between shots and the shot velocity and a ['Rigidbody'] for the shot prefab. These are all set in the editor for ['TCV2'] scripts to access.

**Intended Use**: Hold data for each turret to access and determine which type of turret they are.

### ShotLifetime

Another simple script attached to each shot prefab which destroys them after a set amount of time from their instantiation.

**Intended Use**: Destroy a shot prefab after a certain amount of time.

## Raycast Forward

The last simple script which renders a line from it's parent object out in said objects forward vector to a distance of 100 units.

**Intended Use**: Draw a line for 100 units to display the objects forward vector.

### GameController

GameController.cs is a multifunction script which is designed to be used as the primary means of control over other scripts in the game world. While it primarily handles any pause game functions required by other scripts, in this instance it collects and stores all of the objects tagged as hostile in the scene which can then be access by instances of ['TCV2'] and used for targeting information.

**Intended Use**: Find and store information about all objects tagged hostile for the turret controllers to access.

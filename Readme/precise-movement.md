# Precise Movement Project
Project that contains two kinds of spawner and customizable targets for objects movement.

This is a basic spawner that uses `transform.localPosition` to move and directly uses  `Time.deltaTime` to calculate when to spawn and to go to the next target.
This spawner only works with the `Time.deltaTime` with no more calculation, so it doesn't work well when FPS changes.

![Basic Spawner](https://media.giphy.com/media/NKFaRvc8WiQFfdXqZn/giphy.gif)

This is a more elaborate spawner that also uses `transform.localPosition` for positioning, but it saves the time offset (when spawning and changing directions) to calculate a better precision for the objects.

![Precise Spawner](https://media.giphy.com/media/NkzKYnqixUcdGanLpz/giphy.gif)

## How it works

For example when you spawn an object with a rate of 20 objects per second (50 milliseconds per object) at 30 FPS or calling the Unity `Update` method each 34 ms, with the Basic Spawner an object should spawn each 68 ms or 2 frames at 30 FPS, but it won’t be accurate because the rate desired is 50 ms, there would be a 18 ms of difference in time, that increases each time an object is spawned.

![image](https://user-images.githubusercontent.com/5108925/187817225-8e28c27c-bf0a-4964-b7b5-7795b7a99078.png)

![image](https://user-images.githubusercontent.com/5108925/187817702-ecdaf973-40dd-47ab-8be0-3d464ebd010a.png)

Using the Precise Spawner, the objects are spawned in a similar way as the previous spawner but the time for spawn is saved in a `List<float> _timeoffset` that will save how much time has passed after a frame, and we can move the object to a more accurate position. The same logic is used when the object change directions to another target.

![Spawner Precise](https://user-images.githubusercontent.com/5108925/187822397-436960f1-3829-4120-ad97-9832f48f09fe.png)

## How to use the project

The project is located in `Gameplay/Helper/PreciseMovement/PreciseMovement.unity`

![image](https://user-images.githubusercontent.com/5108925/187824565-ef68ee59-6aa0-4cd5-bb6c-d8edccd5f643.png)

When the scene is opened, you can play and test the project. The buttons **Basic Spawner** and **Precise Spawner** toggles between the Spawners system.

The buttons 15, 30 and 60 FPS change the Frames per second of the project, so you can check the performance of each spawner.

![Play and Buttons](https://media.giphy.com/media/XT7CHZvk9ECYv4mowE/giphy.gif)

To set up the parameters of each spawner:

![Configuration 1](https://media.giphy.com/media/mTqLqGNUJASqAxSMeL/giphy.gif)

To set up the targets of each spawner, you can modify positions, add and remove targets. They are detected by the position order in their parent container.

![Configuration 2](https://media.giphy.com/media/W0RVp3lfqXzFuZY3ji/giphy.gif)

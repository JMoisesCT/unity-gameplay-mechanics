# Precise Movement Project
Project that contains two kinds of spawner and customizable targets for objects movement.

This is a basic spawner that uses `transform.localPosition` to move and uses directly `Time.deltaTime` to calculate when to spawn and to go to the next target.
This spawner only works with the `Time.deltaTime` with no more calculation, so it doesn't work well when FPS changes.

![Basic Spawner](https://media.giphy.com/media/NKFaRvc8WiQFfdXqZn/giphy.gif)

This is a more elaborate spawner that uses also `transform.localPosition` for positioning, but it saves the time offset (when spawning and changing directions) to calculate a better precision for the objects.

![Precise Spawner](https://media.giphy.com/media/NkzKYnqixUcdGanLpz/giphy.gif)

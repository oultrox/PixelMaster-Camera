# Pixel Perfect Camera
## Instructions
Simply drag the camera prefab into your scene or add the PixelCamera component to your main camera, all image effects are supported but may be processed at native resolution before downscaling.

- Set `Reference Width` and `Reference Height` your target resolution for following it's aspect ratio (example: 320x180 is 16:9 so game will display in 16:9 aspect ratio). After this, you'll be able to just set `Native Resolution` to your game via `Player Settings` and it'll follow the true aspect ratio of stated reference resolution in letterbox mode (if it doesn't fit, it'll add bars or whatever you would like to show as background).
- Toggle `Run Every Tick` if you want this executing in-game and you would like to resize viewpor or window size automatically.

![Camera Component] (https://i.imgur.com/3eyuav4.png)

## Pixel perfect movement
Recommended: If you wish to add pixel perfect movement to your existing camera alongside the rendering then add a SnapToPixel component to your camera's parent GameObject.

## Known Issues
Known Issues: To prevent shimmering required that we add a 1px border to the render image to account for a possible fraction of a pixel overlap. This can't be fixed however I do enjoy the aesthetic it creates.


*Special thanks to https://github.com/wolv-interactive/Pixel-Perfect-Retro-Camera since it was based on it's system.*

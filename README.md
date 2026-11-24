<p align="center">
  <img width="384" height="128" alt="Overboard Logo" src="https://github.com/user-attachments/assets/7efb8637-e350-4ecb-9227-e87f86e9fa8d" />
</p>

Overboard is a simple 3D skateboarding game where you ride around, and explore skate parks.

## Features

- Keyboard navigation
- 3D character movement with directional animations
- URP 3D rendering

## Requirements

- Unity **6000.6.7f1** (Unity 6)
- A desktop build target supported by Unity

The Unity project is configured for 3D URP and uses the Unity Input System package.

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/Asim-Tahir/overboard.git
   cd overboard
   ```

2. Open the repository folder in Unity Hub.
3. Select **Unity 6000.6.7f1**.
4. Open `Assets/Scenes/GameScene.unity`.
5. Press **Play** in the Unity Editor.

## Controls

| Action        | Control                          |
| ------------- | -------------------------------- |
| Move          | `W`, `A`, `S`, `D` or arrow keys |
| Brake         | `Space`                          |
| Back / Cancel | `Escape`                         |

## Project Structure

```text
Assets/
├── Animations/   Character and animation assets
├── Fonts/        Custom fonts
├── GameData/     Scriptable object definitions (skateboard items, game data configuration)
├── Materials/    Material assets
├── Meshes/       Mesh and model assets
├── Prefabs/      Reusable UI and game objects
├── Scenes/       Main menu and game scenes
├── Scripts/      C# gameplay and UI scripts
├── Settings/     URP and input settings
├── Sounds/       Background music and SFX
├── Textures/     Texture images
└── Vendor/       Third-party assets (Full skateboard asset pack)
```

## Scenes

The build scenes are configured in `ProjectSettings/EditorBuildSettings.asset`:

1. `Assets/Scenes/GameScene.unity`

## Credit

- Skateboard Animated (Cartoonic) by SR Studios Kerala
  - Link: https://assetstore.unity.com/packages/3d/vehicles/skateboard-animated-cartoonic-225277
- Lostar by Riyadh Rahman
  - Link: https://www.dafont.com/lostar.font

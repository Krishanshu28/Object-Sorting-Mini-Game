# 🧠 Object Sorting Mini-Game

A Unity mini-game where players sort falling objects into matching colored bins by dragging and dropping. Designed to test motor skills and categorization — useful for cognitive exercises or early dementia screening prototypes.

---

## 🎮 Gameplay Overview

- Randomly colored objects (Cube, Sphere, Capsule) fall from above.
- Player must **drag and drop** them into the correct color-matching bin.
- If dropped correctly → ✅ Score increases.
- If dropped incorrectly or object hits the ground → ❌ Lose a life.
- Game ends when lives reach 0.
- Option to restart the game at any time.

---

## 🚀 Features

-  Object sorting via **drag-and-drop**
-  Animated **rotation** of falling objects
-  Efficient **object pooling** system for performance
-  Visual **glow effect** on bins for correct match 
-  Modular C# scripts (separated by logic and system)
-  UI system with **score, lives counter, and restart functionality**
-  Scene reload and object reset on Game Over

---

## 📂 Project Structure

- `Scripts/`
  - `ObjectFalling/`
    - `ObjectSpawner.cs`
    - `ObjectPooler.cs`
    - `FallingObjects.cs`
  - `Bin.cs`
  - `DraggableObject.cs`
  - `GameManager.cs`
  - `GlowFeedBack.cs`

- `Prefabs/`
  - `Objects/`
    - RedCube, GreenSphere, BlueCapsule
  - `Bins/`
    - RedBin, GreenBin, BlueBin

- `Materials/`
  - `BinGlowMat` (emission enabled for glow)
  - `Red`, `Green`, `Blue` (color materials for objects and bins)

- `Animation/`
  - `Action.anim`, `ActionText.controller`

- `Scenes/`
  - `MainScene.unity`


---

## ▶️ How to Play

1. Launch the scene.
2. Wait for objects to spawn and fall.
3. **Drag** each falling object to the bin that matches its color.
4. Avoid letting them fall on the wrong bin or to the ground.
5. Game ends after 3 incorrect attempts (lives = 0).
6. Press Restart to try again.

---

## 🛠 Unity Version
 `Unity 2022.3.13f1 LTS`  


---



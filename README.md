#** FPS First Person Controller

This project serves as an example of developing a First Person Controller (FPC) in Unity. This README file includes instructions on how to use the project, installation steps, and important information.

## Content
- **FSM (Finite State Machine):** Character movements and animations are managed using an FSM.
- **Character Movements:** Basic movements include walking, jumping, crouching, and mouse-based rotation.
- **Animations:** Full body animations are integrated.

## Requirements
- **Unity Version:** 2022.3.13f1
- **Input Manager Package:** You need to download this package for the project to function.
- **FBX File:** A large FBX file is used in the project. To ensure it works properly, it needs to be pulled using Git LFS.

## Installation

1. **Unity Installation:** Download and install Unity 2022.3.13f1.

2. **Clone the Project:**
    ```sh
    git clone <repo-url>
    ```

3. **Install Required Packages:**
    - Download the Input Manager package through Unity’s Package Manager.

4. **Pull the FBX File:**
    - Use Git LFS to pull the large FBX file.
    ```sh
    git lfs install
    git lfs pull
    ```

## Usage

- **Controls:**
  - **W, A, S, D:** Move the character forward, backward, left, and right.
  - **Mouse:** Controls the character’s rotation.
  - **Left Ctrl:** Triggers the crouch action.
  - **Space:** Performs the jump action.
  - **Left Shift:** Enables sprinting (increases movement speed).

- **FSM-Based Character Control:** Character walking, jumping, crouching, and mouse-based rotation are managed using FSM.

- **Animations:** All full-body animations are fully applied.

## License

This project is licensed under the MIT License.

## Support

If you encounter any issues or have suggestions regarding the project, please contact us via the issue tracker.

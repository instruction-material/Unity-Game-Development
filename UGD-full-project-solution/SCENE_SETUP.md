# RelicRunner scene setup

The supplied project contains C# scripts and test sources. Build and save the scene described here before playing or exporting a desktop build.

## Open and verify the project

Open one project root with Unity 6000.3.15f1. Let Package Manager restore its existing manifest and lock. Runtime scripts belong to the Course.UnityGameDevelopment assembly; Edit Mode and Play Mode tests belong to their separate test assemblies.

The initial PlayerController uses UnityEngine.Input.GetAxisRaw("Horizontal"). Set Player > Other Settings > Active Input Handling to Both, then restart the editor if requested. A/D or the left/right arrows control horizontal motion. The installed Input System package supplies the later action-map exercise; Move, Jump and Pause actions are learner additions.

## Build one small 2D scene

1. Create and save Assets/Scenes/RelicRunner.unity. Keep this scene open while setting up the objects.
2. Set the Main Camera to Orthographic, position (0, 0, -10), size 5. Keep gameplay objects at z=0.
3. Create an empty GameManager object and attach GameManager.
4. Create a visible square Player at (-4, 0, 0), tag it Player, and add PlayerController, Rigidbody2D and BoxCollider2D. Set gravity scale to 0 and freeze Z rotation. A sprite or other self-created visible shape supplies the appearance.
5. Make five visible coin objects at x=-2,-1,0,1,2 with y=0. Give each a BoxCollider2D with Is Trigger enabled and attach Collectible. Keep the Player's Rigidbody2D dynamic; coin objects do not need their own body.
6. Make a visible hazard at (3.5, 0, 0), add a trigger BoxCollider2D and Hazard. The Player tag and 2D collider types must match the scripts' checks.
7. Add a Canvas, EventSystem and UI Start button. Use a Standalone Input Module with the Both input setting. In the button's On Click list, drag the GameManager object and select GameManager.StartGame().
8. Add a Restart button and create a scene-reload callback using the example below. Save the scene and include it in the desktop Build Profile scene list.

The starter's GameSession requires three coins; the solution requires five. Keep five coins in the scene so either rule can finish. The starter Start method also permits a state transition that the reference guards; compare those two methods as a state-machine exercise.

## Restart the whole scene

GameManager.ResetRun() resets the rules object only. Disabled coins, position and other scene objects need a complete reset too. Create Assets/Scripts/SceneRestart.cs with this component:

~~~csharp
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class SceneRestart : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
~~~

Attach SceneRestart to GameManager. Connect the Restart button to SceneRestart.Reload(). Add the saved RelicRunner scene to the active Build Profile before checking this callback in a standalone player.

## Observe and test

Before Start, walking into a coin must leave it available with score zero. After Start, the same contact increments score once and disables that coin. A non-player collider has no effect. Inspect the GameManager Score and State properties through a temporary log or a separate HUD script; these properties are values, so they do not appear as serialized Inspector fields.

The starter wins on its third accepted pickup; the reference wins on its fifth. A hazard during Playing changes State to Failed. After Restart the Player and all coins return to their saved scene state.

Open Test Runner and run the existing Edit Mode and Play Mode assemblies. These component tests cover rule and callback behavior. Separately play the saved scene, check every button, collect coins, encounter the hazard and restart. A component test that creates a GameObject does not establish that a scene loads or that its buttons and colliders are wired correctly.

Finish the UI in UGD4 by displaying score and state, limiting movement outside Playing, and providing visible success/failure feedback. The initial source controller moves before Start; gating movement is part of that exercise. Record one complete start, win or failure, and restart route before capstone work.

using UnityEngine;
using UnityEngine.SceneManagement;
     
public class SaveAndRestorePosition : MonoBehaviour
{
    void Start() // Check if we've saved a position for this scene; if so, go there.
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex))
        {
            transform.position = SavedPositionManager.savedPositions[sceneIndex];
        }
    }
     
    void OnDestroy() // Unloading scene, so save position.
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SavedPositionManager.savedPositions[sceneIndex] = transform.position;
    }
}

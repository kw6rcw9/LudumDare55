using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    public void ToLevelSelection() {
        SceneManager.LoadScene("LevelSelection");
    }
}
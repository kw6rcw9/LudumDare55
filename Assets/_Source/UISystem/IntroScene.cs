using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    [SerializeField] private GameObject prompt;

    public void Start() {
        Invoke("promptOn", 1.0f);
    }
    public void ToLevelSelection() {
        SceneManager.LoadScene("LevelSelection");
    }
    public void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Invoke("promptOff", 1.0f);
        }
    }
    
    private void promptOn() {
        prompt.SetActive(true);
    }
    private void promptOff() {
        prompt.SetActive(false);
    }
}
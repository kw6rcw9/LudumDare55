using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    
    private void promptOn()
    {
        prompt.GetComponent<Image>().DOFade(1, 1);
    }
    private void promptOff() {
        prompt.GetComponent<Image>().DOFade(0, 3);
    }
}
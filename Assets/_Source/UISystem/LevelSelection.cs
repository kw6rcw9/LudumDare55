using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

namespace UISystem
{
    public class LevelSelection : MonoBehaviour
    {
        [SerializeField] private TMP_Text dayCounterField;
        [SerializeField] private Sprite rowOffSprite;
        [SerializeField] private List<Button> buttons;
        [SerializeField] private List<GameObject> images;

        private string days;
        private int dayCounter;
        public void Awake()
        {
            dayCounter = PlayerPrefs.GetInt("DayCounter");
            days = PlayerPrefs.GetString("Days");
            for (int i = 0; i < 5; i++)
            {
                Debug.Log(i + days);
                if (days[i] == '1')
                {
                    images[i].SetActive(true);
                    images[i].GetComponent<Image>().sprite = rowOffSprite;
                    buttons[i].GetComponent<Image>().color = new Color32(255, 255, 225, 0);
                }
                else
                {
                    int levelID = i;
                    buttons[i].onClick.AddListener(delegate { chooseLevel(levelID); });
                    Debug.Log("chooseLevel AddedListener LevelID: " + levelID);
                }
            }

            dayCounterField.text = dayCounter.ToString();
        }

        public void chooseLevel(int levelID)
        {
            Debug.Log("chooseLevel LevelID: " + levelID);
            PlayerPrefs.SetInt("CurrentLevel", levelID);
            PlayerPrefs.Save();
            string sceneName = "";
            switch (levelID) {
                case 0:
                    sceneName = "LuxuriaScene";
                break;
                case 1:
                    sceneName = "GulaScene";
                break;
                case 2:
                    sceneName = "AraScene";
                break;
                case 3:
                    sceneName = "InvidiaScene";
                break;
                case 4:
                    sceneName = "SuperbiaScene";
                break;
            }

            SceneManager.LoadScene(sceneName);
        }
    }
}

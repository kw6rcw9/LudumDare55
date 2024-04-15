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
        private int dayCounter = 1;
        public void Awake() {
            dayCounter = PlayerPrefs.GetInt("DayCounter");
            days = PlayerPrefs.GetString("Days");
            for (int i = 0; i < 7; i++) {
                if (days[i] == '1') {
                    images[i].SetActive(true);
                    images[i].GetComponent<Image>().sprite = rowOffSprite;
                    buttons[i].GetComponent<Image>().color = new Color32(255,255,225,0);
                } else {
                    int levelID = i;
                    buttons[i].onClick.AddListener(delegate {chooseLevel(levelID);});
                }
            }

            dayCounterField.text = dayCounter.ToString();   
        }

        public void chooseLevel(int levelID) {
        }
    }
}

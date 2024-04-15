using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UISystem
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject menuPanel;
        [SerializeField] private GameObject settingsPanel;
        [SerializeField] private Button continueButton;
                          
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider sliderEffects;
        [SerializeField] private Slider sliderMusics;
        [SerializeField] private Button buttonMusic;
        [SerializeField] private Button buttonEffects;
        [SerializeField] private Sprite buttonMusicSprite;
        [SerializeField] private Sprite buttonMusicOffSprite;
        [SerializeField] private Sprite buttonEffectsSprite;
        [SerializeField] private Sprite buttonEffectsOffSprite;

        private UserData userData;
        private bool settingsFlag = false;

        void Awake() {
            userData = new UserData();
            if (PlayerPrefs.HasKey("Days") &&  continueButton != null)
            {
                continueButton.onClick.AddListener(Continue);
            } else if (continueButton != null) {
                continueButton.gameObject.SetActive(false);
            }
        }   

        void Start()
        {
            AwakeMusicUI();
            AwakeEffectsUI();
        }

        public void ToggleSettings()
        {
            if (settingsFlag) {
                menuPanel.SetActive(true);
                settingsPanel.SetActive(false);
                //Debug.Log(settingsPanel.activeSelf);
                settingsFlag = !settingsFlag;
            } else {
                menuPanel.SetActive(false);
                settingsPanel.SetActive(true);
                settingsFlag = !settingsFlag;
            }
        }

        void AwakeEffectsUI() {
            if (PlayerPrefs.HasKey("Effects"))
            {
                sliderEffects.value = PlayerPrefs.GetFloat("Effects");
                sliderEffects.onValueChanged.AddListener(delegate {ChangeEffects();});
            }
            else
            {
                PlayerPrefs.SetFloat("Effects", sliderEffects.value);
            }

            // EffectsToggle button
            if (PlayerPrefs.HasKey("IsEffects") && PlayerPrefs.GetInt("IsEffects") == 1)
            {
                EffectsOff();
            }
            else
            {
                EffectsOn();
            }
        }

        void AwakeMusicUI() {
            if (PlayerPrefs.HasKey("Music"))
            {
                sliderMusics.value = PlayerPrefs.GetFloat("Music");
                sliderMusics.onValueChanged.AddListener(delegate {ChangeMusic();});
            }
            else
            {
                PlayerPrefs.SetFloat("Music", sliderMusics.value);
            }

            // MusicToggle button
            if (PlayerPrefs.HasKey("IsMusic") && PlayerPrefs.GetInt("IsMusic") == 1)
            {
                MusicOff();
            }
            else
            {
                MusicOn();
            }
        }

        public void Play()
        {
            PlayerPrefs.SetString("Days", "0000000");
            PlayerPrefs.SetInt("DayCounter", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("IntroScene");
        }

        public void Continue()
        {
            SceneManager.LoadScene("LevelSelection");
        }

        public void ChangeEffects()
        {
            audioMixer.SetFloat("Effects", sliderEffects.value);
            PlayerPrefs.SetFloat("Effects", sliderEffects.value);
            if (PlayerPrefs.GetInt("IsEffects") == 1) {
                EffectsOn();
            }
        }

        public void EffectsOff()
        {
            audioMixer.SetFloat("Effects", -80f);
            PlayerPrefs.SetInt("IsEffects", 1);
            buttonEffects.GetComponent<Image>().sprite = buttonEffectsOffSprite;
            buttonEffects.onClick.RemoveListener(EffectsOff);
            buttonEffects.onClick.AddListener(EffectsOn);
        }

        private void EffectsOn()
        {
            audioMixer.SetFloat("Effects", sliderEffects.value);
            PlayerPrefs.SetInt("IsEffects", 0);
            buttonEffects.GetComponent<Image>().sprite = buttonEffectsSprite;
            buttonEffects.onClick.RemoveListener(EffectsOn);
            buttonEffects.onClick.AddListener(EffectsOff);
        }

        public void ChangeMusic()
        {
            audioMixer.SetFloat("Music", sliderMusics.value);
            PlayerPrefs.SetFloat("Music", sliderMusics.value);
            if (PlayerPrefs.GetInt("IsMusic") == 1) {
                MusicOn();
            }
        }

        public void MusicOff()
        {
            audioMixer.SetFloat("Music", -80f);
            PlayerPrefs.SetInt("IsMusic", 1);
            buttonMusic.GetComponent<Image>().sprite = buttonMusicOffSprite;
            buttonMusic.onClick.RemoveListener(MusicOff);
            buttonMusic.onClick.AddListener(MusicOn);
        }

        private void MusicOn()
        {
            audioMixer.SetFloat("Music", sliderMusics.value);
            PlayerPrefs.SetInt("IsMusic", 0);
            buttonMusic.GetComponent<Image>().sprite = buttonMusicSprite;
            buttonMusic.onClick.RemoveListener(MusicOn);
            buttonMusic.onClick.AddListener(MusicOff);
        }
    }
}

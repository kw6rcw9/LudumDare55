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
        [SerializeField] private AudioMixer audioMixer;
        [SerializeField] private Slider sliderEffects;
        [SerializeField] private Slider sliderMusics;
        [SerializeField] private Button buttonMusic;
        [SerializeField] private Button buttonEffects;

        void Awake()
        {
            AwakeMusicUI();
            AwakeEffectsUI();
        }

        void AwakeEffectsUI() {
            if (PlayerPrefs.HasKey("Effects"))
            {
                sliderEffects.value = PlayerPrefs.GetFloat("Effects");
            }
            else
            {
                PlayerPrefs.SetFloat("Effects", sliderEffects.value);
            }

            // EffectsToggle button
            if (PlayerPrefs.HasKey("IsEffects") && PlayerPrefs.GetInt("IsEffects") == 0)
            {
                EffectsOff();
                buttonEffects.onClick.AddListener(EffectsOn);
            }
            else
            {
                buttonEffects.onClick.AddListener(EffectsOff);
            }
        }

        void AwakeMusicUI() {
            if (PlayerPrefs.HasKey("Music"))
            {
                sliderMusics.value = PlayerPrefs.GetFloat("Music");
            }
            else
            {
                PlayerPrefs.SetFloat("Music", sliderMusics.value);
            }


            // MusicToggle button
            if (PlayerPrefs.HasKey("IsMusic") && PlayerPrefs.GetInt("IsMusic") == 0)
            {
                MusicOff();
                buttonMusic.onClick.AddListener(MusicOn);
            }
            else
            {
                buttonMusic.onClick.AddListener(MusicOff);
            }
        }

        public void Play()
        {
            PlayerPrefs.Save();
            SceneManager.LoadScene(1);
        }

        public void Settings()
        {
            menuPanel.SetActive(false);
            settingsPanel.SetActive(true);
        }

        public void Back()
        {
            menuPanel.SetActive(true);
            settingsPanel.SetActive(false);
        }

        public void ChangeEffects()
        {
            audioMixer.SetFloat("Effects", sliderEffects.value);
            PlayerPrefs.SetFloat("Effects", sliderEffects.value);

        }

        public void EffectsOff()
        {
            audioMixer.SetFloat("Effects", -80f);
            PlayerPrefs.SetFloat("EffectsOff", sliderEffects.value);
            PlayerPrefs.SetInt("IsEffects", 0);
            buttonEffects.onClick.RemoveListener(EffectsOff);
            buttonEffects.onClick.AddListener(EffectsOn);
        }

        private void EffectsOn()
        {
            sliderEffects.value = PlayerPrefs.GetFloat("EffectsOff");
            PlayerPrefs.SetInt("IsEffects", 1);
            buttonEffects.onClick.AddListener(EffectsOff);
            buttonEffects.onClick.RemoveListener(EffectsOn);
        }

        public void ChangeMusic()
        {
            audioMixer.SetFloat("Music", sliderMusics.value);
            PlayerPrefs.SetFloat("Music", sliderMusics.value);

        }

        public void MusicOff()
        {
            audioMixer.SetFloat("Music", -80f);
            PlayerPrefs.SetFloat("MusicOff", sliderMusics.value);
            PlayerPrefs.SetInt("IsMusic", 0);
            buttonMusic.onClick.RemoveListener(MusicOff);
            buttonMusic.onClick.AddListener(MusicOn);
        }

        private void MusicOn()
        {
            sliderMusics.value = PlayerPrefs.GetFloat("MusicOff");
            PlayerPrefs.SetInt("IsMusic", 1);
            buttonMusic.onClick.RemoveListener(MusicOn);
            buttonMusic.onClick.AddListener(MusicOff);
        }
    }
}

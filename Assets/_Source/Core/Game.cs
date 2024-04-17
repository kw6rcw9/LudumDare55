﻿using UnityEngine.SceneManagement;
using UnityEngine;

namespace Core
{
    public class Game
    {
        public static void Win()
        {
            SceneManager.LoadScene("FinalScene");
        }

        public static void Lose()
        {
            
            int dayCounter = PlayerPrefs.GetInt("DayCounter") + 1;
            PlayerPrefs.SetInt("DayCounter", dayCounter);
            PlayerPrefs.Save();
            SceneManager.LoadScene("LevelSelection");
        }

        public static void NextLevel()
        {
            int dayCounter = PlayerPrefs.GetInt("DayCounter") + 1;
            PlayerPrefs.SetInt("DayCounter", dayCounter);
            int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
            string days = PlayerPrefs.GetString("Days");
            if (days == "11111") {
                Win();
            }
            string newDays = "";
            for (int i = 0; i < currentLevel; i++) {
                newDays += days[i];
            }
            newDays += "1";
            for (int i = currentLevel + 1; i < 5; i++) {
                newDays += days[i];
            }

            PlayerPrefs.SetString("Days", newDays);
            PlayerPrefs.Save();
            SceneManager.LoadScene("LevelSelection");
        }
    }
}
﻿using System;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.System;
using TMPro;
using UnityEngine;

namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Daily reward popup
    /// </summary>
    public class DailyReward : MonoBehaviour
    {
        public DayReward[] days;
        public TextMeshProUGUI description;
        int currentDay;
        void OnEnable()
        {
            if (ServerTime.THIS.dateReceived)
                CheckDaily();
            else
                ServerTime.OnDateReceived += CheckDaily;
            var count = int.Parse(days[currentDay].count.text);
            description.text = "You got " + "20" + " " + " " + " " + "" + "" + "  " + " " + " coins";
        }

        private void CheckDaily()
        {
            var previousDay = PlayerPrefs.GetInt("LatestDay", -1);
            var DateReward = PlayerPrefs.GetString("DateReward", ServerTime.THIS.serverTime.ToString());
            var timePassedDaily = (int)DateTime.Parse(DateReward).DayOfWeek;
            /*if (timePassedDaily > ((int) ServerTime.THIS.serverTime.DayOfWeek + 1) % 7 || previousDay == 6)
            {
                previousDay = -1;
            }*/

            if (previousDay == 6)
            {
                previousDay = -1;
            }

            for (var day = 0; day < days.Length; day++)
            {
                if (day <= previousDay)
                    days[day].SetPassedDay();
                if (day == previousDay + 1)
                {
                    days[day].SetCurrentDay();
                    currentDay = day;
                }

                if (day > previousDay + 1)
                    days[day].SetDayAhead();
            }
        }

        public void Ok()
        {
            PlayerPrefs.SetInt("LatestDay", currentDay);
            PlayerPrefs.SetString("DateReward", ServerTime.THIS.serverTime.ToString());
            PlayerPrefs.Save();
            var count = int.Parse(days[currentDay].count.text);
            InitScript.Instance.AddGems(20);
            description.text = "You got " + "20" + " coins";
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            ServerTime.OnDateReceived -= CheckDaily;

        }
    }
}

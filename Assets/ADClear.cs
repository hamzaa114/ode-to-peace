using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADClear : MonoBehaviour
{
    private void OnEnable ()
    {
		if (PlayerPrefs.GetInt("ADC") >= 2)
		{
			Advertisements.Instance.ShowInterstitial();
			PlayerPrefs.SetInt("ADC", 0);
		}
		else
		{
			PlayerPrefs.SetInt("ADC", PlayerPrefs.GetInt("ADC") + 1);
		}
	}
}

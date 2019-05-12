using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public HangulGenerator hangulGenerator;
    public Text hangulSpeedText;
    public Slider hangulSpeedSlider;
    public GameObject hangulKeyboard;
    public bool isPaused = false;

	void Start ()
    {
        hangulSpeedSlider.value = hangulGenerator.hangulSpeed;
	}
	
	void Update ()
    {
        hangulGenerator.hangulSpeed = hangulSpeedSlider.value;
        hangulSpeedText.text = hangulSpeedSlider.value.ToString("00");

        if (!hangulKeyboard.activeInHierarchy && Input.GetKeyDown(KeyCode.Tab))
        {
            hangulGenerator.enabled = false;
            isPaused = true;
            hangulKeyboard.SetActive(true);
        }
        else if (hangulKeyboard.activeInHierarchy && Input.GetKeyDown(KeyCode.Tab))
        {
            hangulGenerator.enabled = true;
            isPaused = false;
            hangulKeyboard.SetActive(false);
        }
	}
}

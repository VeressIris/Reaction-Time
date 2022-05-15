using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject timerTextObj;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private GameObject loseText;

    private ChangeColor changeColorScript;

    private SpriteRenderer sr;

    private float time = 0f;

    void Start()
    {
        changeColorScript = GetComponent<ChangeColor>();
        
        sr = GetComponent<SpriteRenderer>();

        menu.SetActive(false);
        timerTextObj.SetActive(false);
        loseText.SetActive(false);
    }

    void Update()
    {
        if (changeColorScript.startTimer == false && Input.GetMouseButtonDown(0))
        {
            Lose();
        }

        if (changeColorScript.startTimer == true)
        {
            time += Time.deltaTime;

            if (Input.GetMouseButtonDown(0))
            {
                changeColorScript.startTimer = false;

                ShowWinText();
            }
        }
    }

    void ShowWinText()
    {
        TimeSpan currentTime = TimeSpan.FromSeconds(time);
        timerText.text = currentTime.Seconds.ToString() + "." + currentTime.Milliseconds.ToString();
        
        menu.SetActive(true);
        timerTextObj.SetActive(true);
    }

    void Lose()
    {
        sr.color = Color.red;
        
        menu.SetActive(true);
        loseText.SetActive(true);

        Destroy(changeColorScript);
    }
}

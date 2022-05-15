using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private SpriteRenderer sr;

    private float randomTime;

    public bool startTimer = false;
    public bool colorChanged = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        randomTime = Random.Range(1.5f, 10f);

        Invoke("ColorChange", randomTime);
    }

    void ColorChange()
    {
        sr.color = Color.green;   
        startTimer = true;
        colorChanged = true;
    }
}

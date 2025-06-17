using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    float saniye = 0;
    float dakika = 0;
    void Update()
    {
        saniye += Time.deltaTime;

        if (saniye > 60)
        {
            dakika++;
            saniye = 0;
        }
        GetComponent<TextMeshProUGUI>().text = String.Format("Time - {0:00}:{1:00}", dakika, saniye);
    }
}

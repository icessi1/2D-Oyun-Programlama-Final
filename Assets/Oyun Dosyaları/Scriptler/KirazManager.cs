using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KirazManager : MonoBehaviour
{
    public static KirazManager instance;

    private int kirazSayaci = 0;
    [SerializeField] private Text kirazText;

    private void Awake()
    {
        // Singleton Pattern: Bu scriptin tek bir örneðini tutar
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateKirazText();
    }

    public void KirazArttir()
    {
        kirazSayaci++;
        UpdateKirazText();
    }

    private void UpdateKirazText()
    {
        if (kirazText != null)
        {
            kirazText.text = "Kirazlar: " + kirazSayaci.ToString();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SesManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    private static SesManager instance;

    void Awake()
    {
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

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Muzik Ses Ayar�"))
        {
            PlayerPrefs.SetFloat("Muzik Ses Ayar�", 1);
            Load();
        }
        else
        {
            Load();
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Muzik Ses Ayar�");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("Muzik Ses Ayar�", volumeSlider.value);
    }
}

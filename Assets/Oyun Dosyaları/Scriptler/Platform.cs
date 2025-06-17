using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform platform1;
    public Transform platform2;
    public float hareketMesafesi = 5f;
    public float hareketHizi = 2f;

    private Vector3 baslangicPozisyonu1;
    private Vector3 baslangicPozisyonu2;
    private bool sagaHareket1 = true;
    private bool sagaHareket2 = true;

    void Start()
    {
        baslangicPozisyonu1 = platform1.position;
        baslangicPozisyonu2 = platform2.position;
    }

    void Update()
    {
        HareketEt(platform1, ref sagaHareket1, baslangicPozisyonu1);
        HareketEt(platform2, ref sagaHareket2, baslangicPozisyonu2);
    }

    void HareketEt(Transform platform, ref bool sagaHareket, Vector3 baslangicPozisyonu)
    {
        if (sagaHareket)
        {
            platform.Translate(Vector3.right * hareketHizi * Time.deltaTime);
        }
        else
        {
            platform.Translate(Vector3.left * hareketHizi * Time.deltaTime);
        }

        float uzaklik = Vector3.Distance(baslangicPozisyonu, platform.position);

        if (uzaklik >= hareketMesafesi)
        {
            sagaHareket = !sagaHareket;
        }
    }
}

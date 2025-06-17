using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]

public class PowerUp : MonoBehaviour
{
    public enum PowerType
    {
        Health,
        Speed,
        JumpingPower,
    }

    public float arttir;

    public int kiraz=0;
   
    public PowerType Type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            arttirplayerspeed(collision);
            kiraz++;
            Debug.Log(kiraz);
        }
    }

    public void arttirplayerspeed(Collider2D other)
    {
        Player PL = other.GetComponent<Player>();

        if (PL != null)
        {
            switch (Type)
            {
                case PowerType.Health:
                    Debug.Log("Kiraz al�nd�, can artt�");
                    PL.HealthPowerUp(arttir); 
                    Destroy(gameObject);
                    break;
                case PowerType.Speed:
                    Debug.Log("H�z artt�");
                    PL.SpeedPowerUp(arttir);
                    Destroy(gameObject);
                    break;
                case PowerType.JumpingPower:
                    Debug.Log("Z�plama g�c� artt�");
                    PL.JumpPowerUp(arttir);
                    Destroy(gameObject);
                    break;
                default:
                    Debug.Log("Ge�ersiz g��lendirme t�r�");
                    break;
            }
        }
    }
}

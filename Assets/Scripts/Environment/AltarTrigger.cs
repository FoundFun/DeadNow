using System;
using UnityEngine;

public class AltarTrigger : MonoBehaviour
{
    public EnemyTrigger Wizard1;
    public EnemyTrigger Wizard2;
    public EnemyTrigger Monah;
    public GameObject Fire;
    public GameObject Fire1;
    public GameObject Fire2;
    public AudioSource FireDeath;
    public AudioSource DeathExplosion;

    public event Action BadFireGameOver;
    public event Action GoodGameOver;

    public bool AltarComplete { get; private set; }

    private void OnTriggerStay2D(Collider2D other)
    {
        /*if (Wizard1.IsDead && !AltarComplete)
        {
            Fire1.SetActive(false);
        }

        if (Wizard2.IsDead && !AltarComplete)
        {
            Fire2.SetActive(false);
        }*/

        /*if (other.GetComponent<HeroTransfer>().IsTransfer && !AltarComplete)
        {
            AltarComplete = true;
                
            other.GetComponent<Player>().enabled = false;

            if (!Monah.IsDead && Wizard1.IsDead && Wizard2.IsDead)
            {
                Fire.SetActive(false);
                FireDeath.Play();
                GoodGameOver?.Invoke();
            }
            else
            {
                DeathExplosion.Play();
                BadFireGameOver?.Invoke();
            }
        }*/
    }

    public void Reset()
    {
        AltarComplete = false;
        Fire.SetActive(false);
    }
}

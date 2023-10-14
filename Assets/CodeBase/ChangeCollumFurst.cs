using CodeBase.Hero;
using UnityEngine;

public class ChangeCollumFurst : MonoBehaviour
{
    public GameObject CollumTarget;
    public GameObject Collum;
    public GameObject Ship;
    public HeroSpeaker Speaker;

    private AudioSource _explosionAudio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HeroAnimator>())
        {
            Collum.SetActive(false);
            CollumTarget.SetActive(false);
            
            if (Ship != null)
                Ship.SetActive(true);

            Speaker.ShowText(Speaker.MapsChange);

            enabled = false;
        }
    }
}
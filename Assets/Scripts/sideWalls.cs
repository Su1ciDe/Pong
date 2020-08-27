using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sideWalls : MonoBehaviour
{
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        // Çarpıştığı şeyin top olup olmadığını soruyoruz
        if (col.name == "Ball")
        {
            string wallName = transform.name;
            // GameManager içindeki "Score" metodunu çağırıyoruz. 
            // Parametre olarak duvar ismini gönderiyoruz.
            GameManager.Score(wallName);

            PlayAudio();
            // Topu sıfırlamak için Top scriptinin içindeki "ResetBall" metodunu çağırıyoruz.
            col.gameObject.SendMessage("ResetBall");
        }
    }

    void PlayAudio()
    {
        audio.Play();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float ballSpeed = 100f;
    Rigidbody2D rbBall;
    AudioSource audio;

    void Start()
    {
        rbBall = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
        // Oyun başladığında topun rastgele bir yöne fırlatılması için
        StartCoroutine(KickstartBall());
    }

    void Update()
    {
        Ball_SpeedCheck();
    }

    //Top, Oyuncunun köşelerine çarptığında yavaşlamaması için yapılan kontrol
    void Ball_SpeedCheck()
    {
        float velX = rbBall.velocity.x;

        if (velX < 18 && velX > -18 && velX != 0)
        {
            if (velX > 0)
            {
                rbBall.velocity = new Vector2(20f, rbBall.velocity.y);
            }
            else
            {
                rbBall.velocity = new Vector2(-20f, rbBall.velocity.y);
            }
        }
    }

    IEnumerator KickstartBall()
    {
        var r = Random.Range(0, 2);
        // Fonksiyon 2 saniye bekler.
        yield return new WaitForSeconds(2);
        // Eğer random sayı 0.5'ten küçükse sağa gider
        if (r <= 0.5f)
        {
            rbBall.AddForce(new Vector2(ballSpeed, 10f));
        }
        // Eğer random sayı 0.5'ten büyükse sola gider
        else
        {
            rbBall.AddForce(new Vector2(ballSpeed * (-1), -10f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Collider'ın çarptığı şeyin tag'i player mı?
        // Oyuncuların Inspector altındaki "tag"den Player seçilmiş olmalı.
        if (collision.collider.CompareTag("Player"))
        {
            float velY = rbBall.velocity.y;
            // Topa çarptığı anda istenilen yönde ivme verilebilmesi için 
            // oyuncunun ivme hesabı
            velY = velY / 2 + collision.collider.attachedRigidbody.velocity.y / 3;
            rbBall.velocity = new Vector2(rbBall.velocity.x, velY);

            PlayAudio();
        }
    }

    void ResetBall()
    {
        // Bir oyuncu gol yaptığında topu resetlemek için
        // Farklı bir script'ten çağrılacak
        rbBall.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);

        StartCoroutine(KickstartBall());
    }

    void PlayAudio()
    {
        // Sesin her oynadığında farklı bir perdeden oynaması için
        audio.pitch = Random.Range(0.8f, 1.2f);
        audio.Play();
    }

   
}

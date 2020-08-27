using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    // Oyuncuyu yukarı aşağı hareket ettirmek için kullanacağımız tuşları tanımlıyoruz.
    // Inspector kısmından değiştirebilmek için "public" yapıyoruz.
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    // Oyuncunun hızı.
    public float speed = 10f;
    // Oyuncu objemizdeki Rigidbody'ye ulaşmak için değişken tanımlıyoruz.
    Rigidbody2D rb;

    void Start()
    {
        // Oyun açıldığında Rigidbody'yi değişkenimizin içinde atmak için...
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            // Yukarı hareket etmek için ivme veriyoruz.
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
        else if (Input.GetKey(moveDown))
        {
            // Aşağı hareket etmek için ivme veriyoruz.
            rb.velocity = new Vector2(rb.velocity.x, speed * (-1));
        }
        else
        {
            //Hiçbir tuşa basılmıyorsa durması için...
            rb.velocity = new Vector2(0, 0);
        }

    }
}

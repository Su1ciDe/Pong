using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static int player1Score = 0;
    static int player2Score = 0;

    Transform top;

    public GUISkin layout;

    private void Start()
    {
        // "Ball" objesini bulup "top" değişkenimize atıyoruz.
        top = GameObject.FindGameObjectWithTag("Ball").transform;
    }
    // Duvarlar için oluşturacağımız scriptin içinde bu metodu çağıracağız.
    static public void Score(string wallName)
    {
        // Sağdaki duvardan gol olursa puanı soldaki oyuncuya yaz.
        if (wallName == "rightWall")
        {
            player1Score += 1;
        }
        // Soldaki duvardan gol olursa puanı sağdaki oyuncuya yaz.
        else if (wallName == "leftWall")
        {
            player2Score += 1;
        }
    }

    private void OnGUI()
    {
        GUI.skin = layout;
        // Skorları ekranda göstermek için ekranda label oluşturuyoruz.
        GUI.Label(new Rect(Screen.width / 2 - 150 - 12.5f, 25, 100, 100), player1Score.ToString());
        GUI.Label(new Rect(Screen.width / 2 + 150 - 12.5f, 25, 100, 100), player2Score.ToString());

        if (GUI.Button(new Rect(Screen.width / 2 - 60, 35, 120, 50), "RESET"))
        {
            // Oyunculuarın skorlarını sıfırlıyoruz.
            player1Score = 0;
            player2Score = 0;
            // Top'un scriptindeki "ResetBall" metodunu çağırıyoruz.
            top.gameObject.SendMessage("ResetBall");
        }
    }
}

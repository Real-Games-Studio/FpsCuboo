using UnityEngine;
using TMPro; // Inclua esta biblioteca para manipular o componente de texto

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText; // Variável para armazenar o componente de texto que mostrará o tempo
    private float startTime;
    private float countdownTime = 600; // 600 segundos para 10 minutos

    public bool startCount = false;

    public GameObject telaGameOver;

    public GameManager gm;

    public AudioSource theme;

    void Update()
    {
        if(startCount) {
            float t = countdownTime - (Time.time - startTime);

            if (t <= 0)
            {
                t = 0;
                telaGameOver.SetActive(true);
                theme.Stop();
                //gm.DisableMobile();
            }

            string minutes = ((int) t / 60).ToString();
            string seconds = ((int) t % 60).ToString("00"); // Usa "00" para formatar com dois dígitos
            timerText.text = minutes + ":" + seconds;
        } 
    }

    public void StartCount() {
        startTime = Time.time;
        startCount = true;
    }
}

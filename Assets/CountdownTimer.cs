using UnityEngine;
using TMPro; // Inclua esta biblioteca para manipular o componente de texto

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text timerText; // Variável para armazenar o componente de texto que mostrará o tempo
    private float startTime;
    private float countdownTime = 300; // 300 segundos para 5 minutos

    public bool startCount = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if(startCount) {
            float t = countdownTime - (Time.time - startTime);

            if (t <= 0)
            {
                t = 0;
                // Opcional: adicione aqui qualquer ação que você deseja executar ao fim do contador
            }

            string minutes = ((int) t / 60).ToString();
            string seconds = (t % 60).ToString("f0");
            timerText.text = minutes + ":" + seconds;
        } 
    }

    public void StartCount() {
        startCount = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrastarGame : MonoBehaviour
{
    public RectTransform[] imagesTransform;
    public RectTransform[] targets;

    public bool[] conf;

    public int val = 0;

    public Image background;
    public GameObject layout01, layout02;
    public GameObject botao;

    public bool finalizou = false;
    

    void Update()
    {
        if (imagesTransform[0] != null && targets[0] != null && conf[0] == false)
        {
            float d1 = Vector2.Distance(imagesTransform[0].anchoredPosition, targets[0].anchoredPosition);
            if (d1 < 100)
            {
                targets[0].GetComponent<Image>().enabled = true;
                Debug.Log("A distância entre os elementos é menor que 1");
                // Aqui você pode adicionar o que desejar para quando a condição for verdadeira
                val += 1;
                conf[0] = true;
            } else {
                targets[0].GetComponent<Image>().enabled = false;
            }
        }

        if (imagesTransform[1] != null && targets[1] != null && conf[1] == false)
        {
            float d2 = Vector2.Distance(imagesTransform[1].anchoredPosition, targets[1].anchoredPosition);
            if (d2 < 100)
            {
                targets[1].GetComponent<Image>().enabled = true;
                Debug.Log("A distância entre os elementos é menor que 1");
                // Aqui você pode adicionar o que desejar para quando a condição for verdadeira
                val += 1;
                conf[1] = true;
            } else {
                targets[1].GetComponent<Image>().enabled = false;
            }
        }

        if (imagesTransform[2] != null && targets[2] != null && conf[2] == false)
        {
            float d3 = Vector2.Distance(imagesTransform[2].anchoredPosition, targets[2].anchoredPosition);
            if (d3 < 100)
            {
                targets[2].GetComponent<Image>().enabled = true;
                Debug.Log("A distância entre os elementos é menor que 1");
                // Aqui você pode adicionar o que desejar para quando a condição for verdadeira
                val += 1;
                conf[2] = true;
            } else {
                targets[2].GetComponent<Image>().enabled = false;
            }
        }

        if (imagesTransform[3] != null && targets[3] != null && conf[3] == false)
        {
            float d4 = Vector2.Distance(imagesTransform[3].anchoredPosition, targets[3].anchoredPosition);
            if (d4 < 100)
            {
                targets[3].GetComponent<Image>().enabled = true;
                Debug.Log("A distância entre os elementos é menor que 1");
                // Aqui você pode adicionar o que desejar para quando a condição for verdadeira
                val += 1;
                conf[3] = true;
            } else {
                targets[3].GetComponent<Image>().enabled = false;
            }
        }

        if(val >= 4 && finalizou == false) {
            Finalizou();
        }
        
    }

    void Finalizou() {
        layout01.SetActive(false);
        layout02.SetActive(true);
        //botao.SetActive(true);
        finalizou = true;
    }
}

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

    public int checkVal = 0;
    

    void Update()
    {
        
        if(checkVal >= 4 && finalizou == false) {
            Finalizou();
        }
        
    }

    void Finalizou() {
        layout01.SetActive(false);
        layout02.SetActive(true);
        //botao.SetActive(true);
        finalizou = true;
    }

    public void Check() {
        checkVal += 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUp : MonoBehaviour
{
    public Image img;
    public TMP_Text text;
    
    public void SetUp(Item item) {
        text.text = "" + item.nome;
        img.sprite = item.icone;
        gameObject.SetActive(true);
    }
}

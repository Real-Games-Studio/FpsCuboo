using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Image img;
    public Button botao;
    public GameManager gm;
    public Item item;

    void Start() {
        gm = FindObjectOfType<GameManager>();
    }
    
    public void SetUp(Item item) {
        img.sprite = item.icone;
        this.item = item;
        if(item.isFinalPapel == true) {
            botao.onClick.AddListener(PaperClicked);
        } else {
            botao.onClick.AddListener(ButtonClicked);
        }
        
    }

    void PaperClicked()
    {
       gm.ShowPopUp(item);
    }

    void ButtonClicked()
    {
       gm.AdicionarNaCaixa(item);
    }
}

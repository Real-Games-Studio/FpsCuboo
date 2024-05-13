using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaixaController : MonoBehaviour
{

    public TMP_Text senhaCaixa;
    public string senha = "", senhaComparar;

    public Animator caixaAnim;
    public GameObject item;
    public GameManager gm;

    public GameObject trigger;

    public void AddNumber(int i) {
        senha = senha + "" + i;
        senhaCaixa.text = senha;
    }

    public void Clear() {
        senha = "";
        senhaCaixa.text = senha;
    }

    public void Confirm() {
        if(senha == senhaComparar) {
            caixaAnim.SetTrigger("open");
            item.SetActive(true);
            gameObject.SetActive(false);
            gm.isMontar = true;
            gm.montarBase.SetActive(true);
            trigger.SetActive(true);
        } else {

        }
    }
    
}

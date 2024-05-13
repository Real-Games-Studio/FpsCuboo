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

    public GameObject telaErro;

    public void AddNumber(int i) {
        // Verifica se o comprimento da senha já alcançou 5 caracteres
        if (senha.Length < 5) {
            senha += i; // Concatena o número à senha atual
            senhaCaixa.text = senha; // Atualiza o texto na UI
        }
    }

    public void Clear() {
        senha = ""; // Limpa a senha
        senhaCaixa.text = senha; // Atualiza o texto na UI
    }

    public void Confirm() {
        if (senha == senhaComparar) {
            caixaAnim.SetTrigger("open"); // Aciona a animação de abrir
            item.SetActive(true); // Ativa o item
            gameObject.SetActive(false); // Desativa o gameObject atual
            gm.isMontar = true; // Configura o estado no GameManager
            gm.montarBase.SetActive(true); // Ativa a base para montar
            trigger.SetActive(true); // Ativa o trigger
        } else {
            telaErro.SetActive(true); // Mostra a tela de erro
        }
    }
}

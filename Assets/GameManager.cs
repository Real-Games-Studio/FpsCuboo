using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Item> inventario = new List<Item>(new Item[8]); // Define o inventário com 8 espaços nulos.
    public GameObject botaoInventario, botaoItem, panelPapel;
    public Transform inventarioPanel;
    public int papelCount = 0;

    public List<Item> papel = new List<Item>();

    public PopUp popUp;

    public Item papelCompleto;

    public GameObject caixa;

    public Transform targetMontar;

    public Transform[] targetsMontarLimpar;

    public bool isMontar = false;

    public GameObject montarBase;

    public string sequenciaCorreta = "", sequenciaJogador = "";
    public int countCapsula = 0;

    public GameObject carinha;

    public GameObject painelSequenciaErrada;

    void Start() {
        UpdateInventarioBar();
    }

    public void AddInventario(Item item) {
        int index = inventario.FindIndex(i => i == null);
        if (index != -1) {
            inventario[index] = item;
           
            ShowPopUp(item);
            UpdateInventarioBar();
            if(item.isPapel == true) {
                verificaPapel(item);
            }
        } else {
            Debug.Log("Inventário cheio!");
        }
    }

    public void RemoveInventario(Item item) {
        int index = inventario.IndexOf(item);
        if (index != -1) {
            inventario[index] = null;
            UpdateInventarioBar();  // Atualiza a interface do usuário após remover um item
        }
    }

    void UpdateInventarioBar() {
        // Limpa os filhos do painel do inventário
        foreach (Transform child in inventarioPanel) {
            Destroy(child.gameObject);
        }

        // Cria botões de acordo com os itens no inventário
        for (int i = 0; i < inventario.Count; i++) {
            GameObject obj;
            if (inventario[i] == null) {
                obj = Instantiate(botaoInventario, inventarioPanel.position, Quaternion.identity);
            } else {
                obj = Instantiate(botaoItem, inventarioPanel.position, Quaternion.identity);
                obj.GetComponent<ButtonController>().SetUp(inventario[i]);
            }
            obj.transform.SetParent(inventarioPanel);
        }
    }

    void ShowPopUp(Item item) {
        if(item.isPapel == true && papelCount >= 1) { 

        } else {
            popUp.SetUp(item);
        }
        
    }

    void verificaPapel(Item item) {
        papel.Add(item);
        papelCount += 1;

        if(papelCount >= 2) {
            //panelPapel.SetActive(true);
            RemoveInventario(papel[0]);
            RemoveInventario(papel[1]);
            AddInventario(papelCompleto);
        }
    }

    public void OpenCaixa() {
        caixa.SetActive(true);
    }

    public void ColocarCapsula(Transform t) {
        targetMontar = t;
    }

    public void AdicionarNaCaixa(Item item) {
        if(isMontar == true){
            countCapsula += 1;
            sequenciaJogador = sequenciaJogador + "" + item.id;
            GameObject obj = Instantiate(item.model, targetMontar.position, Quaternion.identity);
            obj.transform.SetParent(targetMontar);

            if(countCapsula >= 5) {
                if(sequenciaJogador == sequenciaCorreta) {
                    carinha.SetActive(true);
                } else {
                    painelSequenciaErrada.SetActive(true);
                }
            }
        }
    }

    public void RecomecarSequencia() {
        foreach (Transform parent in targetsMontarLimpar)
        {
            if (parent.childCount > 0) // Verifica se o objeto tem ao menos um filho
            {
                Transform firstChild = parent.GetChild(0); // Obtém o primeiro filho
                Destroy(firstChild.gameObject); // Destroi o objeto do primeiro filho
            }
        }
        painelSequenciaErrada.SetActive(false);

        countCapsula = 0;
        sequenciaJogador = "";
    }
}

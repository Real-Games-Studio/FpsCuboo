using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Item> inventario = new List<Item>(new Item[6]); // Define o inventário com 8 espaços nulos.
    public GameObject botaoInventario, botaoItem, panelPapel;
    public Transform inventarioPanel;
    public int papelCount = 0;

    public List<Item> papel = new List<Item>();

    public PopUp popUp, popUpMapa;

    public Item papelCompleto;

    public GameObject caixa;

    public Transform targetMontar;

    public Transform[] targetsMontarLimpar;

    public bool isMontar = false;

    public GameObject montarBase;

    public string sequenciaCorreta = "", sequenciaJogadorString = "";
    public int[] sequenciaJogador;

    public int countCapsula = 0;

    public GameObject carinha;

    public GameObject painelSequenciaErrada, telaFinalGame;

    public GameObject UI;

    public Animator finalAnim;

    public GameObject mobileInput;

    public GameObject gameUI;

    public CountdownTimer timer;

    public AudioSource theme, final;

    void Start() {
        UpdateInventarioBar();
    }

   public void AddInventario(Item item, Transform t) {
        // Verifica se o item já existe no inventário
        if (inventario.Contains(item)) {
            TirarDaCaixa(item, t);
        } else {
            // Procura por um espaço null para adicionar o item
            int index = inventario.FindIndex(i => i == null);
            if (index != -1) {
                inventario[index] = item;

                ShowPopUp(item);
                UpdateInventarioBar();
                if (item.isPapel) { // Simplificado a verificação de booleano
                    verificaPapel(item);
                }
            } else {
                Debug.Log("Inventário cheio!");
            }
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

    public void ShowPopUp(Item item) {
        if(item.isPapel == true && papelCount >= 1) { 

        } else if(item.id == 7) {
            popUpMapa.SetUp(item);
        }
            else {
            popUp.SetUp(item);
            DisableMobile();
        }
        
    }

    void verificaPapel(Item item) {
        papel.Add(item);
        papelCount += 1;

        if(papelCount >= 2) {
            //panelPapel.SetActive(true);
            RemoveInventario(papel[0]);
            RemoveInventario(papel[1]);
            AddInventario(papelCompleto, transform);
        }
    }

    public void OpenCaixa() {
        caixa.SetActive(true);
        DisableMobile();
        
    }

    public void ColocarCapsula(Transform t) {
        pintarSequenciaBranco();
        targetMontar = t;
        targetMontar.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }

    public void AdicionarNaCaixa(Item item, GameObject botao) {
        if(isMontar == true && targetMontar != null){
            countCapsula += 1;
            //sequenciaJogador = sequenciaJogador + "" + item.id;
            if(targetMontar.tag == "01"){
                sequenciaJogador[0] = item.id;
            }
            if(targetMontar.tag == "02"){
                sequenciaJogador[1] = item.id;
            }
            if(targetMontar.tag == "03"){
                sequenciaJogador[2] = item.id;
            }
            if(targetMontar.tag == "04"){
                sequenciaJogador[3] = item.id;
            }
            if(targetMontar.tag == "05"){
                sequenciaJogador[4] = item.id;
            }
            GameObject obj = Instantiate(item.model, targetMontar.position, Quaternion.identity);
            obj.transform.SetParent(targetMontar);
            targetMontar.gameObject.GetComponent<MeshRenderer>().enabled = false;
            //obj.tag = "null";
            targetMontar = null;
            botao.GetComponent<ButtonController>().Colocou();

            if(countCapsula >= 5) {
                foreach (int num in sequenciaJogador)
                {
                    sequenciaJogadorString += num.ToString();
                }
                DisableMobile();
                if(sequenciaJogadorString == sequenciaCorreta) {
                    finalAnim.SetTrigger("Play");
                    UI.SetActive(false);
                    theme.Stop();
                    final.Play();
                    StartCoroutine(StartTelaCarinha());
                } else {
                    painelSequenciaErrada.SetActive(true);
                }
            }
        }
    }

    public void RecomecarSequencia() {
        foreach (Transform parent in targetsMontarLimpar)
        {
            parent.gameObject.GetComponent<MeshRenderer>().enabled = true;
            if (parent.childCount > 0) // Verifica se o objeto tem ao menos um filho
            {
                
                Transform firstChild = parent.GetChild(0); // Obtém o primeiro filho
                Destroy(firstChild.gameObject); // Destroi o objeto do primeiro filho
            }
        }
        painelSequenciaErrada.SetActive(false);

        countCapsula = 0;
        sequenciaJogadorString = "";
        for (int i = 0; i < sequenciaJogador.Length; i++)
        {
            sequenciaJogador[i] = 0;  // Atribuindo 0 a cada elemento do array
        }
        UpdateInventarioBar();
    }

    public void ReiniciarGame()
    {
        SceneManager.LoadScene(0);
    }

    public void EnableMobile() {
        mobileInput.SetActive(true);
    }

    public void DisableMobile() {
        mobileInput.SetActive(false);
    }

    public void pintarSequenciaBranco() {
        targetsMontarLimpar[0].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        targetsMontarLimpar[1].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        targetsMontarLimpar[2].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        targetsMontarLimpar[3].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        targetsMontarLimpar[4].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
    }

    public void StartGame() {
        gameUI.SetActive(true);
        timer.StartCount();
        theme.Play();
    }   

    IEnumerator StartTelaCarinha() {

        yield return new WaitForSeconds(3);
        telaFinalGame.SetActive(true);
    }

    public void TirarDaCaixa(Item item, Transform t) {
        int index = inventario.IndexOf(item);
        if (index != -1) {
            inventario[index] = null;
            inventario[index] = item;

            for (int i = 0; i < inventarioPanel.childCount; i++)
            {
                Transform child = inventarioPanel.GetChild(i);
                if(child.gameObject.GetComponent<ButtonController>()) {
                    if(child.gameObject.GetComponent<ButtonController>().item == item) {
                        child.gameObject.GetComponent<ButtonController>().Tirou();
                    }
                }
            }
        }

        Transform parentTransform = t.parent;

        // Verifica se o GameObject tem um pai
        if (parentTransform != null)
        {
            countCapsula -= 1;
            parentTransform.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }
    }
}

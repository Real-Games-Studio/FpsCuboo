using UnityEngine;

public class CameraFinder : MonoBehaviour
{
    public GameManager gm;
    void Update()
    {
        // Verifica se o botão esquerdo do mouse foi pressionado
        if (Input.GetMouseButtonDown(0))
        {
            // Cria um raio que parte da câmera até a posição do mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Realiza o raycast
            if (Physics.Raycast(ray, out hit))
            {
                // Verifica se o objeto clicado é este objeto
                if (hit.collider.gameObject.tag == "Item")
                {
                    // Debuga o nome do objeto
                    Debug.Log("Clicked on " + hit.collider.gameObject.name);
                    gm.AddInventario(hit.collider.gameObject.GetComponent<ItemController>().item);
                    Destroy(hit.collider.gameObject, 0.5f);
                }

                if (hit.collider.gameObject.tag == "Caixa")
                {
                    gm.OpenCaixa();
                }
            }
        }
    }
}

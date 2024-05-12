using UnityEngine;

public class CameraFinder : MonoBehaviour
{
    public GameManager gm;

    void Update()
    {
        // Verifica cliques do mouse
        if (Input.GetMouseButtonDown(0))
        {
            CheckRaycast(Input.mousePosition);
        }

        // Verifica toques na tela
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                CheckRaycast(touch.position);
            }
        }
    }

    void CheckRaycast(Vector3 position)
    {
        // Cria um raio que parte da câmera até a posição do clique ou toque
        Ray ray = Camera.main.ScreenPointToRay(position);
        RaycastHit hit;

        // Realiza o raycast
        if (Physics.Raycast(ray, out hit))
        {
            // Verifica se o objeto tocado/clicado é um dos objetos desejados
            switch (hit.collider.gameObject.tag)
            {
                case "Item":
                    Debug.Log("Clicked on " + hit.collider.gameObject.name);
                    gm.AddInventario(hit.collider.gameObject.GetComponent<ItemController>().item);
                    Destroy(hit.collider.gameObject);
                    break;
                case "Caixa":
                    gm.OpenCaixa();
                    break;
                case "01":
                case "02":
                case "03":
                case "04":
                case "05":
                    gm.ColocarCapsula(hit.collider.gameObject.transform);
                    break;
            }
        }
    }
}

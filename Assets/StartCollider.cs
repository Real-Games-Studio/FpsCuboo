using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCollider : MonoBehaviour
{
    public GameManager gm;
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player") {
            gm.StartGame();
        }
    }
}

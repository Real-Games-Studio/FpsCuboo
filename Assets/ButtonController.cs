using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Image img;
    
    public void SetUp(Item item) {
        img.sprite = item.icone;
    }
}

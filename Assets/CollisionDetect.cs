using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollisionDetectorMultiple : MonoBehaviour
{
    public List<Image> targetImages; // Lista de Images que podem colidir com este objeto
    public string target01, target02;
    private Image myImage;
    private RectTransform myRect;

    public ArrastarGame ag;

    public bool foi = false;

    void Start()
    {
        myImage = GetComponent<Image>();
        myRect = myImage.rectTransform;
    }

    void Update()
    {
        if(foi == false) {
            bool foundOverlap = false;

            foreach (var targetImage in targetImages)
            {
                RectTransform targetRect = targetImage.rectTransform;
                if (RectOverlaps(myRect, targetRect))
                {
                    foundOverlap = true;
                    // Verifica a tag do objeto targetImage
                    if (targetImage.tag == target01 || targetImage.tag == target02)
                    check(targetImage); 
                    else
                        myImage.color = Color.red;

                    break; // Sai do loop se uma sobreposição for encontrada
                }
            }

            if (!foundOverlap)
            {
                if(foi == false) {
                    myImage.color = Color.white;
                }
            }
        }
    }

    bool RectOverlaps(RectTransform rectA, RectTransform rectB)
    {
        // Calcula a sobreposição dos retângulos no espaço global
        return RectTransformUtility.RectangleContainsScreenPoint(rectA, rectB.position, null) ||
               RectTransformUtility.RectangleContainsScreenPoint(rectB, rectA.position, null);
    }

    void check(Image targetImage) {
        if(foi == false) {
            foi = true;
            targetImage.gameObject.GetComponent<Drag>().BlockOnTarget(gameObject.transform);
            myImage.color = Color.green;
            ag.Check();
        }
        
    }
}

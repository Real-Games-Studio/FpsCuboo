using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "gameObjects/Item")]
public class Item : ScriptableObject
{
    public int id;
    public string nome;
    public Sprite icone;
    public GameObject model;
    public bool isPapel = false;
}

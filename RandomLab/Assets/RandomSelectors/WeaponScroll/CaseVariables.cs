using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CaseVariables : MonoBehaviour
{

    public Weapons weapons;
    public void Start()
    {
        Setup();
    }
    public void Setup()
    {
        GetComponent<Image>().sprite = weapons.items[Random.Range(0, weapons.items.Length)].sprites;
    }
}

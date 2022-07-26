using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapons", menuName = "WeaponList/Create Weapon List")]
public class Weapons : ScriptableObject
{
    public ScrollItems[] items;

    [System.Serializable]
    public struct ScrollItems
    {
        public GameObject weaponPrefab;
        public string itemName;
        public Sprite sprites;
    }
}

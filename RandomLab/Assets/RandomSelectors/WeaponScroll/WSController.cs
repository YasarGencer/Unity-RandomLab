using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WSController : MonoBehaviour
{

    public Weapons weapons;

    public GameObject selectedScreen;
    public Image selectedImage;
    public TextMeshProUGUI selectedText;

    public GameObject ButtonSound;
    public GameObject next;
    void Start()
    {
    }

    public void SelectWeapon()
    {
        int a = Random.Range(0, weapons.items.Length);
        selectedImage.sprite = weapons.items[a].sprites;
        selectedText.text = weapons.items[a].itemName;
        PlayerPrefs.SetInt("Weapon", a);

    }

    public void Next()
    {
        Destroy(Instantiate(ButtonSound),1f);
        Time.timeScale = 1;
        Instantiate(next, GameObject.Find("Canvas").transform);
        Destroy(gameObject);
    }
    public void Select()
    {
        StartCoroutine(Selectt());
    }
    IEnumerator Selectt()
    {
        SelectWeapon();
        yield return new WaitForSeconds(2); 
        selectedScreen.SetActive(true);
    }
}

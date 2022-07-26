using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ECController : MonoBehaviour
{
    public Animator dice;
    public GameObject rolled;
    public TextMeshProUGUI CountText;

    public GameObject next;
    GameCreator gameCreator;


    public GameObject ButtonSound, DiceSound;
    public void Roll()
    {
        StartCoroutine(Rolll());
    }

    IEnumerator Rolll()
    {
        //Destroy(Instantiate(ButtonSound), 1f);
        Destroy(Instantiate(DiceSound), 1f);
        int roll = Random.Range(15, 21);
        dice.SetInteger("Dice", roll);
        yield return new WaitForSeconds(2);
        CountText.text = roll.ToString();
        gameCreator = GameObject.Find("GameCreator").GetComponent<GameCreator>();
        gameCreator.maxEnemyCount = roll;
        rolled.SetActive(true);
    }
    public void Next()
    {
        Destroy(Instantiate(ButtonSound), 1f);
        Time.timeScale = 1;
        Instantiate(next, GameObject.Find("Canvas").transform);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapCreator : MonoBehaviour
{
    public TextMeshProUGUI text;


    public GameObject[] rooms;

    private int rollCount = 0;
    private GameCreator gameCreator;
    public GameObject RollSound, parent;

    public void Start()
    {
        gameCreator = GameObject.Find("GameCreator").GetComponent<GameCreator>();
    }
    public void RollDice(int choosen)
    {
        Camera.main.gameObject.GetComponent<Cam>().MaxIn();
        if (rollCount < 15)
            StartCoroutine(Dice());
        else
            StartCoroutine(Stop(choosen));
    }
    IEnumerator Dice()
    {
        rollCount++;
        int random = Random.Range(0, 6);
        text.text = (random + 1).ToString();
        yield return new WaitForSeconds(0.1f);
        RollDice(random);
    }
    IEnumerator Stop(int choosen)
    {
        gameCreator.rooms.Add(Instantiate(rooms[choosen], GameObject.Find("Grid").transform));
        yield return new WaitForSeconds(0.5f);
        if (parent)
        {
            Destroy(parent);
            gameCreator.WeaponSet();
        }
        Destroy(gameObject);
    }
    public void Sound()
    {
        Destroy(Instantiate(RollSound), 2f);
    }
}

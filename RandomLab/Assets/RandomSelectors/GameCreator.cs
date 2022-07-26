using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameCreator : MonoBehaviour
{
    public GameObject player;
    public Cam cam;
    public Weapons weapons;
    public Transform weaponTransform;
    [HideInInspector] public GameObject currentWeapon;
    public int maxEnemyCount;

    public GameObject selector;
    public Transform canvas;

    public List<GameObject> rooms;
    public List<GameObject> enemies;

    int waveCount = 1;
    public Animator waveAnimator;
    public TextMeshProUGUI waveText;


    bool inGame = false;

    public GameObject gameScene;
    public void Start()
    {
        GameStart();
    }
    private void Update()
    {
        if (enemies.Count <= 0 && inGame)
            GameStart();
        if (enemies.Count > 0)
            inGame = true;
    }

    public void GameStart()
    {
        gameScene.SetActive(false);
        inGame = false;
        waveAnimator.SetTrigger("NewWave");
        waveText.text = "WAVE " + waveCount;
        waveCount++;
        cam.MaxOut();
        Invoke("Selector", 1f);

        foreach (var room in rooms)
        {
            Destroy(room);
        }
        foreach (var enemy in enemies)
        {
            enemies.Remove(enemy);
        }
    }
    public void Selector()
    {
        Instantiate(selector, canvas);
    }
    public void WeaponSet()
    {
        player.transform.position = this.transform.position;
        if (weaponTransform)
        {
            if (currentWeapon != null)
                Destroy(currentWeapon);

            currentWeapon = Instantiate(weapons.items[PlayerPrefs.GetInt("Weapon")].weaponPrefab, weaponTransform);
        }
        gameScene.SetActive(true);
    }
    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}

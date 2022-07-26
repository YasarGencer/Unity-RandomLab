using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject bloodParticle;


    public int maxHealth;
    int currentHealth;
    GameCreator gameCreator;

    Color defaultColor;

    private void Start()
    {
        currentHealth = maxHealth;
        gameCreator = GameObject.Find("GameCreator").GetComponent<GameCreator>();
        defaultColor = GetComponent<EnemyMovement>().animator.gameObject.GetComponent<SpriteRenderer>().color;
    }
    public void GetDamage(int damage)
    {
        GameObject particle = Instantiate(bloodParticle, transform.position, Quaternion.identity);
        particle.transform.parent = gameObject.transform;
        Destroy(particle.gameObject, 2f);

        if (currentHealth > damage)
            currentHealth -= damage;
        else
            EnemyDeath();
        StartCoroutine(ChangeColor(GetComponent<EnemyMovement>().animator.gameObject.GetComponent<SpriteRenderer>()));

        Debug.Log(currentHealth);
    }
    void EnemyDeath()
    {
        gameCreator.RemoveEnemy(gameObject);
        Destroy(gameObject);
    }

    IEnumerator ChangeColor(SpriteRenderer sprite)
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(.3f);
        sprite.color = defaultColor;
    }
}

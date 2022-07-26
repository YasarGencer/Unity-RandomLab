using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    public int maxHealth;
    int cHealth;
    public GameObject bloodParticle;
    public SpriteRenderer Sprite;
    public Slider health;
    private void Start()
    {
        cHealth = maxHealth;
        health.maxValue = maxHealth;
        health.value = maxHealth;
    }
    private void Update()
    {
        health.value = cHealth;
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GetDamage(int damage)
    {
        GameObject particle = Instantiate(bloodParticle, transform.position, Quaternion.identity);
        particle.transform.parent = gameObject.transform;
        Destroy(particle.gameObject, 2f);

        if (cHealth > damage)
            cHealth -= damage;
        else
            Die();
        StartCoroutine(ChangeColor(Sprite));
    }

    IEnumerator ChangeColor(SpriteRenderer sprite)
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(.3f);
        sprite.color = Color.white;
    }
}

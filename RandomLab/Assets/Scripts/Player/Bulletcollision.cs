using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcollision : MonoBehaviour
{
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().GetDamage(damage);
        }

        Destroy(gameObject);
    }
}

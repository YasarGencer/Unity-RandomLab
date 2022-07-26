using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    [Header("Stats")]
    public int speed; 
    public float range;
    public GameObject bulletP;

    [Header("Background")]
    public Transform rayStarter;
    public LayerMask ground;
    int destination = 1;
    bool ableToAttack = true;

    [Space(3f)]
    public Animator animator;
    public enum Gun
    {
        Rifle,
        Pistol,
        Machine,
    }
    public Gun gun;

    private void Update()
    {
        Move(); Attack();
    }
    public void Move()
    {
        //inputs
        RaycastHit2D hit1 = Physics2D.Raycast(rayStarter.position, Vector3.down, 2f, ground);
        if (hit1.collider == null)
            destination *= -1;
        RaycastHit2D hit2 = Physics2D.Raycast(rayStarter.position, new Vector2(destination,0), .5f, ground);
        if (hit2.collider != null)
            destination *= -1;
        //movement
        transform.Translate(transform.right * speed * destination* Time.deltaTime);
        //turning
        transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * destination, transform.localScale.y);

        //animation
        animator.SetBool("Walk", true);
    }
    private void OnDrawGizmos()
    {
        //GROUND
        Debug.DrawLine(rayStarter.position, rayStarter.position + new Vector3(0, -2f, 0), Color.green);
        Debug.DrawLine(rayStarter.position, rayStarter.position + new Vector3(destination * .5f, 0, 0), Color.green);
        Debug.DrawLine(rayStarter.position, rayStarter.position + new Vector3(destination * range, 0, 0), Color.red);
    }
    public void Attack()
    {
        RaycastHit2D attack = Physics2D.Raycast(rayStarter.position, new Vector2(destination, 0), range);
        if (attack.collider != null)
            if (attack.collider.gameObject.name == "Player")
                if(range != 1)
                    StartCoroutine(RangedAttack());
    }
    IEnumerator RangedAttack()
    {
        if (ableToAttack)
        {
            ableToAttack = false;

            speed = speed / 2;

            if(gun == Gun.Rifle)
            {
                GameObject bullet = Instantiate(bulletP, rayStarter.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * 500f * this.transform.localScale.x);
                yield return new WaitForSeconds(.5f);
                GameObject bullet1 = Instantiate(bulletP, rayStarter.position, Quaternion.identity);
                bullet1.GetComponent<Rigidbody2D>().AddForce(bullet1.transform.right * 500f * this.transform.localScale.x);
                yield return new WaitForSeconds(.5f);
                GameObject bullet2 = Instantiate(bulletP, rayStarter.position, Quaternion.identity);
                bullet2.GetComponent<Rigidbody2D>().AddForce(bullet2.transform.right * 500f * this.transform.localScale.x);
                yield return new WaitForSeconds(.5f);
            }
            else if(gun == Gun.Pistol)
            {
                GameObject bullet = Instantiate(bulletP, rayStarter.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * 500f * this.transform.localScale.x);
            }
            else if (gun == Gun.Machine)
            {
                GameObject bullet = Instantiate(bulletP, rayStarter.position, Quaternion.identity);
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * 500f * this.transform.localScale.x);
                yield return new WaitForSeconds(.4f);
                GameObject bullet1 = Instantiate(bulletP, rayStarter.position, Quaternion.identity);
                bullet1.GetComponent<Rigidbody2D>().AddForce(bullet1.transform.right * 500f * this.transform.localScale.x);
                yield return new WaitForSeconds(.4f);
                GameObject bullet2 = Instantiate(bulletP, rayStarter.position, Quaternion.identity);
                bullet2.GetComponent<Rigidbody2D>().AddForce(bullet2.transform.right * 500f * this.transform.localScale.x);
                yield return new WaitForSeconds(.4f);
                GameObject bullet3 = Instantiate(bulletP, rayStarter.position, Quaternion.identity);
                bullet3.GetComponent<Rigidbody2D>().AddForce(bullet3.transform.right * 500f * this.transform.localScale.x);
                yield return new WaitForSeconds(.4f);
                GameObject bullet4 = Instantiate(bulletP, rayStarter.position, Quaternion.identity);
                bullet4.GetComponent<Rigidbody2D>().AddForce(bullet4.transform.right * 500f * this.transform.localScale.x);
                yield return new WaitForSeconds(.4f);
            }

            yield return new WaitForSeconds(1f);

            ableToAttack = true;

            speed = speed * 2;
        }
    }
}
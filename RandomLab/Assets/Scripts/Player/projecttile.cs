using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projecttile : MonoBehaviour
{
    [SerializeField] float lifetime;
    [SerializeField] float force;
    private Camera mainCam;
    private Rigidbody2D rg;
    private Vector3 mousePos;



    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rg = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position-mousePos;
        rg.velocity = new Vector2(direction.x, direction.y).normalized*force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot-180);

       
    }
    
}

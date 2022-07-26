using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Camera cam;
    GameObject player;
    bool follow = false;
    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if(follow)
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        else
            transform.position = new Vector3(0, 0, -10);

    }
    public void MaxOut()
    {
        cam.orthographicSize = 25;
        follow = false;
    }
    public void MaxIn()
    {
        Invoke("MaxInn", 3.5f);
    }
    void MaxInn()
    {
        cam.orthographicSize = 10;
        follow = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistol : MonoBehaviour
{
    private Vector3 localScale;
    public float offset;
    bool isAble = true;
    [SerializeField] Transform shotPoint;
    [SerializeField] GameObject projectTile;

    private void Start()
    {
        localScale = transform.localScale;
    }
    void Update()
    {
        Vector3 diffarence = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(diffarence.y, diffarence.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + offset);


        if (Camera.main.ScreenToViewportPoint(Input.mousePosition).x > 0.5f)
        {
            transform.localScale = new Vector3(-1, 1, localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(1, -1, localScale.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isAble)
            {
                StartCoroutine(atýsbekle());
            }
        }
    }




    IEnumerator atýsbekle()
    {
        isAble = false;
        Instantiate(projectTile, shotPoint.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        isAble = true;

    }
}

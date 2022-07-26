using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    public int distance, speed;
    private float _speed;
    private bool _isScrolling;

    public WSController wSController;

    public GameObject ButtonSound, SpinSound;

    public void StartScroll()
    {
        if (_isScrolling)
            return;

        Destroy(Instantiate(ButtonSound), 1f);
        Destroy(Instantiate(SpinSound), 4f);

        _speed = Random.Range(4, 5);
        _isScrolling = true;

        for (int i = 0; i < 100; i++)
            Instantiate(_prefab, transform);

        wSController.Select();

    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.left * speed, _speed * Time.deltaTime * distance);

        if (_speed > 0)
            _speed -= Time.deltaTime;
        else
        {
            _speed = 0;
            _isScrolling = false;
        }


    }
}

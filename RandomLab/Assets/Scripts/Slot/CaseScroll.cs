using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaseScroll : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;

    private float _speed;
    private bool _isScrolling;

    private List<CaseCell> _cells = new List<CaseCell>();
    
    public void Scroll()
    {
        if (_isScrolling)
            return;

        _speed = Random.Range(4, 5);
        _isScrolling = true;

        if (_cells.Count == 0)
            for (int i = 0; i < 100; i++)
                _cells.Add(Instantiate(_prefab, transform).GetComponentInChildren<CaseCell>());
       
        foreach (var cell in _cells)
            cell.Setup();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + Vector3.left * 100, _speed * Time.deltaTime * 1500);

        if (_speed > 0)
            _speed -= Time.deltaTime;
        else
        {
            _speed = 0;
            _isScrolling = false;
        }
    
    
    }
}

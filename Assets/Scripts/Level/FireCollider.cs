using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCollider : MonoBehaviour
{
    [Header("Fire References")]
    [SerializeField] private Collider2D _fire2DCollider;

    [Header("Objects in Contact")]
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private GameObject _enemyObject;
    [SerializeField] private GameObject _itemObject;
    [SerializeField] private GameObject _burnableObject;
    

    private void Start()
    {
        _fire2DCollider = this.gameObject.GetComponent<EdgeCollider2D>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {

        }

        if (collision.gameObject.CompareTag("Item"))
        {

        }

        if (collision.gameObject.CompareTag("Burnable"))
        {
            _burnableObject = collision.gameObject;
            //_burnableObject.Burn(1f);
        }
    }
}

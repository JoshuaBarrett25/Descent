using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [Header("Detection")]
    //Target will always be player unless changed due to a summon
    [SerializeField] private Collider2D _detectionRadius;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Transform _sight;

    [SerializeField] private Transform _parentGO;
    [Tooltip("Target will always be player unless changed due to a summon")]
    public Transform target;

    private bool playerFound = false;

    public bool GetFoundState()
    {
        return playerFound;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (FindPlayer())
            {
                Debug.Log("Player detected!");
                playerFound = true;
            }

            else
            {
                Debug.Log("Looking around...");
                playerFound = false;
            }
        }
    }

    public void FacePlayer()
    {
        if (playerFound)
        {
            if (target.position.x <= _parentGO.position.x)
            {
                _parentGO.Rotate(0f, 180f, 0f);
            }

            else if (target.position.x > _parentGO.position.x)
            {
                _parentGO.Rotate(0f, 0f, 0f);
            }
        }
    }

    private bool FindPlayer()
    {
        RaycastHit2D hit = Physics2D.Linecast(transform.position, target.position, LayerMask.GetMask("Ground", "Wall", "Player"));
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == LayerMask.GetMask("Ground", "Walls"))
            {
                return false;
            }
            if (hit.collider.gameObject.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }

}



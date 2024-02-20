using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    public bool playerFound { get; private set; }
    public bool playerLost { get; private set; }

    [Header("Detection")]
    //Target will always be player unless changed due to a summon
    [SerializeField] private Collider2D _detectionRadius;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Transform _sight;

    public bool facingRight;

    public Transform _parentGO;
    [Tooltip("Target will always be player unless changed due to a summon")]
    public Transform target;

    [SerializeField] private float _losingPlayerTimer;

    private float timerWS;


    private void FixedUpdate()
    {
        if (transform.rotation.y < 0)
        {
            facingRight = false;
        }

        else
        {
            facingRight = true;
        }

        Debug.Log(facingRight);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (FindPlayer())
            {
                StopAllCoroutines();
                Debug.Log("Player detected!");
                playerFound = true;
            }

            if (!FindPlayer() && playerFound)
            {
                StartCoroutine(LookingTimer());
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && playerFound)
        {
            StartCoroutine(LookingTimer());
        }
    }

    private IEnumerator LookingTimer()
    {
        while (timerWS <= _losingPlayerTimer)
        {
            timerWS += Time.deltaTime;
            Debug.Log(timerWS);
            yield return null;
        }
        playerFound = false;
        playerLost = true;
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



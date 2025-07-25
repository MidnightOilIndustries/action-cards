using UnityEngine;
using System.Collections.Generic;

[DisallowMultipleComponent]
public class Enemy : MonoBehaviour
{
    //Perhaps a character base script. 

    public bool isAware, canAttack;
    public int health, energy = 100;
    public float attackDistance = 2;
    public float speed = 5;
    private Animator _animator;

    public GameObject attackHitbox, playerGO;
    public PlayerPrefs player;

    public List<CardSO> enemyCards;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        TryGetComponent(out _animator);
        playerGO = GameObject.FindGameObjectsWithTag("Player")[0];
        canAttack = true;


    }
    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(playerGO.transform.position, transform.position);
        if ((dist <= attackDistance) && canAttack)
        {
            //canAttack = false;
            PlayCard(enemyCards[Random.Range(0, enemyCards.Count)]);
        }
        else
        {
            var step = speed * Time.deltaTime; // calculate distance to move
            _animator.SetFloat("MotionSpeed", speed);

            transform.LookAt(playerGO.transform);
            transform.position = Vector3.MoveTowards(transform.position, playerGO.transform.position, step);
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerHitbox"))
        {
            Debug.Log("Hit by Player Weapon");
            TakeDamage(10);
        }
    }

    private void TakeDamage(int DamageAmount)
    {
        health -= DamageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void PlayCard(CardSO cardData)
    {
        if (isAware)
        {
            if (energy >= cardData.energy)
            {
                if (cardData.animationIndex == 0)
                {
                    Debug.LogWarning("Card Had animationIndex 0");
                }
                energy -= cardData.energy;
                attackHitbox.SetActive(true); //This should create an object instead
                _animator.SetInteger("Attack", cardData.animationIndex);
            }
            else
            {
                //Debug.Log("Enemy Out of Energy");
            }
        }
    }

    public void AttackStart()
    {
        //This is called by the animator
        Debug.Log("Attack Start: " + energy);
        attackHitbox.SetActive(true);
        _animator.SetInteger("Attack", 0);
    }
}

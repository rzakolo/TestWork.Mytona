using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Warrior : MonoBehaviour
{
    [SerializeField] private Animator weaponAnimator;
    [SerializeField] private ParticleSystem deathParticle;
    private GameObject target;
    protected int health;
    private float viewDistance = 3.0f;
    protected Vector3 viewPoint;
    private NavMeshAgent navMeshAgent;
    protected string enemyTag;

    protected virtual void StartSettings()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.stoppingDistance = 1.0f;
        InvokeRepeating(nameof(CheckRadious), 1, 1);
    }

    protected void CheckEnemys()
    {
        if (target)
        {
            if (Vector3.Distance(transform.position, target.transform.position) > viewDistance)
            {
                navMeshAgent.SetDestination(viewPoint);
                weaponAnimator.gameObject.SetActive(false);
                target = null;
            }
            else
            {
                Attack();
            }
        }
        else
        {
            weaponAnimator.gameObject.SetActive(false);
        }
    }
    protected void CheckRadious()
    {
        Collider[] hits = Physics.OverlapSphere(viewPoint, viewDistance);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].CompareTag(enemyTag))
            {
                MoveTo(hits[i].transform.position);
                target = hits[i].gameObject;
                return;
            }
        }
    }
    private void Attack()
    {
        weaponAnimator.gameObject.SetActive(true);
        weaponAnimator.Play("Attack");
    }
    public void MoveTo(Vector3 enemy)
    {
        navMeshAgent.SetDestination(enemy);
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
            Death();
    }

    private void Death()
    {
        deathParticle.transform.position = transform.position;
        Instantiate(deathParticle);
        Destroy(gameObject);
    }
}

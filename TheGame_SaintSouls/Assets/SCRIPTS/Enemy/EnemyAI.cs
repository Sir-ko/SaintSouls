using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerMovement player;
    public float viewAngle;
    public float timeToScream;
    public float speedToScream;
    public float distanceToScream;
    public AudioSource Music;
    public AudioClip StepSound;
    public AudioClip FightSound;
    public GameObject image;


    public Animator animator;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private bool isScreaming = false;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        isScreaming = false;
        Music.Play();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPatrolPoint();
    }

    void Update()
    {
        NoticePlayerUpdate();
        ChaseUpdate();
        PatrolUpdate();
        ShouldScream();
    }

    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }

    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }

    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }

    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }

    private void ShouldScream()
    {
        if(isScreaming) return;
        if(Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position) <= distanceToScream)
        {
            Screamer();
        }
    }

    private void Screamer()
    {
        isScreaming = true;
        player.GetComponentInChildren<CameraRotation>().enabled = false;
        player.transform.LookAt(gameObject.transform);
        _navMeshAgent.isStopped = true;
        //transform.LookAt(player.transform);
        Camera.main.transform.LookAt(gameObject.transform.position + new Vector3(0, 1, 0));
        player.enabled = false;
        animator.SetTrigger("Attack");
        player.GetComponent<HeadBobController>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        Invoke("Delay", 2.7f);
        Invoke("ChangeScene", 1.8f);
    }
    private void Delay()
    {
        SceneManager.LoadScene(5);
    }
    public void ChangeScene()
    {
        image.SetActive(true);
    }
    public void PlaySoundOfAttack()
    {
        Music.PlayOneShot(FightSound);
    }
}

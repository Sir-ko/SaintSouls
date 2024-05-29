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
    public AudioClip ScreamSound;
    public AudioClip CryForHelp;
    public GameObject image;


    public Animator animator;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayerNoticed;
    private bool isScreaming = false;

    bool hasCryed = false;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        isScreaming = false;
        if(Music.enabled)
            Music.Play();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        PickNewPatrolPoint();
    }

    void Update()
    {
        if (_navMeshAgent.enabled == true)
        {
            NoticePlayerUpdate();
            ChaseUpdate();
            PatrolUpdate();
        }
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
                hasCryed = false;
                player.StopHeartRate();
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
                    if (!hasCryed)
                    {
                        Music.PlayOneShot(CryForHelp);
                        hasCryed = true;
                    }
                    player.StartHeartRate();
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
        if(Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position) <= distanceToScream && _isPlayerNoticed)
        {
            Screamer();
        }
    }

    private void Screamer()
    {
        StartCoroutine(changePosition());
        Music.PlayOneShot(ScreamSound);
        player.StopHeartRate();
        isScreaming = true;
        player.GetComponentInChildren<CameraRotation>().enabled = false;
        _navMeshAgent.enabled = false;
        transform.LookAt(player.transform.position);
        _navMeshAgent.isStopped = true;
        Camera.main.transform.LookAt(gameObject.transform.position + new Vector3(0, 1, 0));
        player.enabled = false;
        player.GetComponent<HeadBobController>().enabled = false;
        player.GetComponent<AudioSource>().enabled = false;
        animator.SetTrigger("Attack");
        Invoke("Delay", 2.7f);
        Invoke("ChangeScene", 1.8f);
    }
    public IEnumerator changePosition()
    {
        var direction = player.transform.position - transform.position;
        float newTime = 0f;
        while (newTime <= 0.5f)
        {
            newTime += Time.deltaTime;
            transform.position += direction * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
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

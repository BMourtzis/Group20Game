using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    float DamangePoints;
    [SerializeField]
    float step;
    [SerializeField]
    Transform[] PatrolPoints;

    private Vector3 LastKnownPosition;
    bool onAlert;
    GameObject player;
    private int patrolPoint;
    float timeToAttack;

    // Use this for initialization
    void Start ()
    {
        patrolPoint = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        onAlert = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void FixedUpdate()
    {
        if (onAlert)
        {
            MoveToLKP();
        }
        else
        {
            Patrol();
        }

        if(transform.position.y < -25)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject == player)
        {
            LastKnownPosition = other.gameObject.transform.position;
            onAlert = true;
        }
    }

    void MoveToLKP()
    {
        float playDist = Vector2.Distance(transform.position, player.transform.position);
        if (playDist <= 0.7*transform.lossyScale.x && Time.time > timeToAttack)
        {
            if(transform.position.x < player.transform.position.x)
            {
                Attack(true);
            }
            else
            {
                Attack(false);
            }
        }
        else
        {
            Move(LastKnownPosition);
            float dist = Vector2.Distance(transform.position, LastKnownPosition);
            if (Mathf.Abs(dist) < step)
            {
                onAlert = false;
            }
        }
    }

    void Attack(bool right)
    {
        PlayerHealthScript playerHealth = player.GetComponent<PlayerHealthScript>();
        playerHealth.TakeDamage(DamangePoints, right);
        timeToAttack = Time.time + 0.5f;
    }

    void Patrol()
    {
        Vector3 patPoint = PatrolPoints[patrolPoint].position;
        float dist = Vector2.Distance(transform.position, patPoint);

        if(Mathf.Abs(dist) < 1f* transform.lossyScale.x)
        {
            patrolPoint++;
            if(patrolPoint >= PatrolPoints.Length)
            {
                patrolPoint = 0;
            }
        }

        Move(patPoint);
    }

    void Move(Vector3 newPos)
    {
        Vector3 movePos = new Vector3(step * Time.deltaTime, 0f);
        float dist = transform.position.x - newPos.x;

        if (dist > 0)
        {
            movePos *= -1;
        }

        transform.position += movePos;
    }
}

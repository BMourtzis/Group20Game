using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    float DamangePoints;
    [SerializeField]
    float step;

    private Vector3 LastKnownPosition;
    bool onAlert;
    GameObject player;

    // Use this for initialization
    void Start ()
    {
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
            Destroy(gameObject);
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
        if (Vector2.Distance(transform.position, player.transform.position) <= 0.7)
        {
            Attack();
        }
        else
        {
            Vector3 newPos = new Vector3(step * Time.deltaTime, 0f);
            float dist = transform.position.x - LastKnownPosition.x;

            if (dist > 0)
            {
                newPos *= -1;
            }

            transform.position += newPos;


            if (Mathf.Abs(dist) < step)
            {
                onAlert = false;
            }
        }
    }

    void Attack()
    {
        HealthScript playerHealth = player.GetComponent<HealthScript>();
        playerHealth.TakeDamage(DamangePoints);
    }

    void Patrol()
    {

    }
}

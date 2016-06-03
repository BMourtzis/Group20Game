using UnityEngine;
using System.Collections;

public class KillBillEnemyAI : MonoBehaviour {

	public float stepDistance;
	public float DamangePoints;

	float timeToAttack;
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		MoveToPlayer ();
		fallDeath ();
	}



	void MoveToPlayer()
	{
		float playDist = Vector2.Distance (transform.position, player.transform.position);
		if (playDist <= 0.7 && Time.time > timeToAttack) {
			if (transform.position.x < player.transform.position.x) {
				Attack (true);
			} else {
				Attack (false);
			}
		} 
		else {
			Move (new Vector3(player.transform.position.x, player.transform.position.y, 0));
		}
	}

	void Move(Vector3 newPos)
	{
		Vector3 movePos = new Vector3(stepDistance * Time.deltaTime, 0f);
		float dist = transform.position.x - newPos.x;

		if (dist > 0)
		{
			movePos *= -1;
		}

		transform.position += movePos;
	}

	void Attack(bool right)
	{
		PlayerHealthScript playerHealth = player.GetComponent<PlayerHealthScript>();
		playerHealth.TakeDamage(DamangePoints, right);
		timeToAttack = Time.time + 0.5f;
	}

	void fallDeath() {
		if (transform.position.y < -25) {
			Destroy (gameObject);
		}
	}
}

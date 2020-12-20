using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	public float lookRadius = 50f;

	// Who the enemy wants to attack
	Transform target;

	// Reference to enemy so we can move it
	NavMeshAgent agent;

	float curDir = 0f; // compass indicating direction
	float vertSpeed = 0f; // vertical speed (see note)
	Vector3 curNormal = Vector3.up; // smoothed terrain normal

	// Start is called before the first frame update
	void Start() {
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update() {
		if(!agent.SetDestination(new Vector3(263, 82, 261))) {
			Debug.Log("Failed!");
		}

		float turn = Input.GetAxis("Horizontal") * 2 * 100 * Time.deltaTime;
		curDir = (curDir + turn) % 360; // rotate angle modulo 360 according to input
		RaycastHit hit;
		if(Physics.Raycast(transform.position, -curNormal, out hit)) {
			curNormal = Vector3.Lerp(curNormal, hit.normal, 4 * Time.deltaTime);
			Quaternion grndTilt = Quaternion.FromToRotation(Vector3.up, curNormal);
			transform.rotation = grndTilt * Quaternion.Euler(0, curDir, 0);
		}
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
}

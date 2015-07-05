using UnityEngine;
using System.Collections;

public class SalmonController : MonoBehaviour {

	private Rigidbody2D body;
    private Health myHealth;
	public float speed;
	private bool faceRight = true;
	public float frictionCoeff;
    public int score;
    public int mutationLevel;

	public AudioClip CollectPlankton;

	// Use this for initialization
	void Start () {
	    myHealth = GetComponent<Health>();
	    myHealth.Lives = 3;
		body = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.F) || Input.GetKeyDown(KeyCode.JoystickButton5) || Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Weapon weapon = GetComponent<Weapon>();
            if (weapon != null)
            {
                weapon.shootRight = faceRight;
                weapon.Attack(false); // false because WE ARE NOT an enemy
            }
        }


		//rotations
		Quaternion rotationFixed = new Quaternion (0, 0, 0,0);
		body.transform.rotation = rotationFixed;
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (moveHorizontal < 0 && faceRight) {
			Flip ();
		}
		if (moveHorizontal > 0 && !faceRight) {
			Flip ();
		}
		float frictionX = frictionCoeff * body.velocity.x;
		float frictionY = frictionCoeff * body.velocity.y;


		Vector2 force = new Vector2 (moveHorizontal-frictionX, moveVertical-frictionY);
		body.AddForce(force*speed);
	}

	void Flip(){
		transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
		faceRight = !faceRight;
	}

    void OnTriggerEnter2D(Collider2D obj)
    {
        PlanctonPoint bonus = obj.gameObject.GetComponent<PlanctonPoint>();
        if (bonus == null) return;
        score += bonus.points;
        if (score % 50 == 0)
        {
            myHealth.AddLives(1);
        }
        mutationLevel += bonus.mutation;
		AudioSource.PlayClipAtPoint (CollectPlankton, new Vector3 (0, 0, 0));
        Destroy(bonus.gameObject);
    }
}

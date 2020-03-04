using UnityEngine;

public class EnemyControls : MonoBehaviour
{
	public float enemySpeed, horizontalMovement = 0f;
	private Rigidbody2D rb;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		horizontalMovement = Input.GetAxisRaw("Horizontal");
	}

	void FixedUpdate()
	{
		rb.velocity = new Vector2(horizontalMovement * enemySpeed, rb.velocity.y);
	}
}


using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour {

	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		RayCasting ();
		Movement ();
	}

	void RayCasting()
	{
//		Debug.DrawLine (lineStart.position, lineEnd.position, Color.green);
//		Debug.DrawLine (this.transform.position, groundedEnd.position, Color.green);
//		
//		grounded = Physics2D.Linecast (this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer ("Ground"));
//		
//		if (Physics2D.Linecast (lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer ("Enemy")))
//		{
//			whatPlayerHits = Physics2D.Linecast (lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer ("Enemy"));
//			interact = true;
//		}
//		else {
//			interact = false;
//		}
//		
//		if(Input.GetKeyDown(KeyCode.E) && interact == true)
//		{
//			Destroy(whatPlayerHits.collider.gameObject);
//		}
	}
	
	void Movement()
	{
		anim.SetFloat("HorizontalSpeed", Mathf.Abs (Input.GetAxisRaw("Horizontal")));
		//Debug.Log (anim.GetFloat("HorizontalSpeed"));
	
		if (Input.GetAxisRaw ("Vertical") > 0) {
			transform.Translate (Vector2.up * 4f * Time.deltaTime);
			//transform.eulerAngles = new Vector2 (0, 0);
			anim.SetBool ("isMovingUp", true);
		} else {
			anim.SetBool ("isMovingUp", false);
		}

		if (Input.GetAxisRaw ("Vertical") < 0) {
			transform.Translate (-Vector2.up * 4f * Time.deltaTime);
			//transform.eulerAngles = new Vector2 (0, 0);
			anim.SetBool ("isMovingDown", true);
		} else {
			anim.SetBool ("isMovingDown", false);
		}

		if(Input.GetAxisRaw("Horizontal") > 0  )
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
		}
		if(Input.GetAxisRaw("Horizontal") < 0)
		{
			transform.Translate(Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
		}
	}
}

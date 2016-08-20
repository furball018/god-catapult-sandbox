using UnityEngine;
using System.Collections;

public class impulseToMouse : MonoBehaviour {

    public float impulse;
    private Vector3 mousePos;
    private Vector3 dir;
    private Rigidbody2D rig;

	// Use this for initialization
	void Start ()
    {
        impulse = 50.0f;
        rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dir = (transform.position - mousePos) * impulse;
            rig.AddForce(new Vector2(dir.x, dir.y) * -1);
            Debug.Log(mousePos);
        }
	}
}

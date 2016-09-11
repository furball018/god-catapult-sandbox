using UnityEngine;
using System.Collections;

public class smoothCameraFollow : MonoBehaviour {

    private Vector2 vel;
    public float stx;
    public float sty;

    public GameObject target;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (target)
        {
            float posx = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref vel.x, stx);
            float posy = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref vel.y, sty);

            transform.position = new Vector3(posx, posy, transform.position.z);
        }
    }
}

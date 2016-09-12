using UnityEngine;
using System.Collections;

public class smoothCameraFollow : MonoBehaviour {

    private Vector2 vel;
    public float stx;
    public float sty;
    public float minZoom = 7;
    public float maxZoom = 16;
    public float zoomSmoothing = 0.5f;

    private GameObject[] targets;
    private GameObject target;
    private Camera cam;


	// Use this for initialization
    void Awake()
    {
        targets = GameObject.FindGameObjectsWithTag("camTarget");
        cam = GetComponent<Camera>();
    }
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        target = targets[0];
        if (target)
        {
            float posx = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref vel.x, stx);
            float posy = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref vel.y, sty);

            //float dif = target.GetComponent<Rigidbody2D>().velocity.magnitude;
            transform.position = new Vector3(posx, posy, transform.position.z);
            //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, dif, zoomSmoothing);
        }
    }
}

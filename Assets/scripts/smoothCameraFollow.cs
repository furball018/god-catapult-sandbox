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
    public GameObject target;
    private Camera cam;


	// Use this for initialization
    void Awake()
    {
        cam = GetComponent<Camera>();
    }
	void Start () {
        targets = GameObject.FindGameObjectsWithTag("camTarget");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if(target == null)
            targets = GameObject.FindGameObjectsWithTag("camTarget");
        target = targets[0];
        if (target)
        {
            float posx = Mathf.SmoothDamp(transform.position.x, target.transform.position.x, ref vel.x, stx);
            float posy = Mathf.SmoothDamp(transform.position.y, target.transform.position.y, ref vel.y, sty);
            transform.position = new Vector3(posx, posy, transform.position.z);

            float targetSize = Mathf.Lerp(minZoom, maxZoom, Mathf.InverseLerp(0.0f, 50f, target.GetComponent<Rigidbody2D>().velocity.magnitude));
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, zoomSmoothing);
        }
    }
}

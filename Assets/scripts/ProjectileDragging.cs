using UnityEngine;
using System.Collections;

public class ProjectileDragging : MonoBehaviour {

    public string pieceForm;
    public float Stretch = 3f;
    private float Stretch2;
    private bool clicked;
    
    private SpringJoint2D spring;
    private Transform catapult;
    private GameObject cam;
    private Ray mouseRay;
    private Rigidbody2D rig;
    private Vector2 oldVel;

    void Awake ()
    {
        catapult = GameObject.FindGameObjectWithTag("catapult").transform;
        spring = GetComponent<SpringJoint2D>();
        spring.connectedBody = catapult.GetComponent<Rigidbody2D>();
        Debug.Log(catapult);
        mouseRay = new Ray(catapult.position, Vector3.zero);
        Stretch2 = Stretch * Stretch;
        rig = GetComponent<Rigidbody2D>();
        
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        
    }

    void Start ()
    {
                
	}
	
	void Update ()
    {
        if (clicked)
            Drag();
        if(spring != null)
        {
            if (!rig.isKinematic && oldVel.sqrMagnitude > rig.velocity.sqrMagnitude)
            {
                //Esto sucede cuando se catapulto la pieza por el aire
                Destroy(spring);
                rig.velocity = oldVel;
                GetComponent<rotation>().enabled = false;
            }
        }
        if (!clicked)
        {
            oldVel = rig.velocity;
        }
    }

    void OnMouseDown()
    {
        spring.enabled = false;
        clicked = true;
        cam.GetComponent<smoothCameraFollow>().enabled = false;
    }
    void OnMouseUp()
    {
        
        spring.enabled = true;
        rig.isKinematic = false;
        cam.GetComponent<smoothCameraFollow>().enabled = true;
        clicked = false;
    }
    void Drag()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 slingToMouse = mousePos - catapult.position;
        if (slingToMouse.sqrMagnitude > Stretch2)
        {
            mouseRay.direction = slingToMouse;
            mousePos = mouseRay.GetPoint(Stretch);
        }
        mousePos.z = 0;
        transform.position = mousePos;

    }
}

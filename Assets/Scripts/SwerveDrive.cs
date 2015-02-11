using UnityEngine;
using System.Collections;

public class SwerveDrive : MonoBehaviour {
    public float movescale = 1;
    public float rotationscale = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float dt = Time.deltaTime;
        float bearing = Mathf.Atan2(transform.forward.x , transform.forward.z);
        float rx = Input.GetAxis("Relativex");
        float ry = Input.GetAxis("Relativey");


        Vector3 worldmotion = new Vector3(
            Input.GetAxis("Worldx"),
            0,
            Input.GetAxis("Worldy")
        );
        Vector3 localmotion = new Vector3(
            (rx * Mathf.Cos(bearing)) + (ry * Mathf.Sin(bearing)),
            0, 
            -(rx * Mathf.Sin(bearing)) + (ry * Mathf.Cos(bearing))
        );
        Vector3 motion = (worldmotion + localmotion).normalized;

        //Debug.Log(Vector3.Angle(Vector3.forward, transform.forward));
        Debug.Log(Input.GetAxis("Rotate"));
        Debug.DrawRay(transform.position, localmotion, Color.yellow);
        Debug.DrawRay(transform.position, worldmotion, Color.red);
        Debug.DrawRay(transform.position, motion);

        rigidbody.AddForce(motion * movescale, ForceMode.Acceleration);
        rigidbody.AddTorque(0,Input.GetAxis("Rotate") * rotationscale, 0, ForceMode.Acceleration);
        
	}
}

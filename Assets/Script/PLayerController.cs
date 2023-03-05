using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    public float speed;
    public float tilt;

    public GameObject bullet;
    public Transform bulletSp;
    
    public float fireRate;
    private float timeRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update(){
        if(Input.GetButton("Fire1") && Time.time>timeRate){
            timeRate = Time.time + fireRate;
            Instantiate(bullet, bulletSp.position, bulletSp.rotation);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horAxis = Input.GetAxis("Horizontal");
        float verAxis = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horAxis,0.0f, verAxis);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -13f, 13f), transform.position.y, Mathf.Clamp(transform.position.z, -1f, 8.5f));

        transform.rotation = Quaternion.Euler(new Vector3(0,0,GetComponent<Rigidbody>().velocity.x * -tilt));
    }
}

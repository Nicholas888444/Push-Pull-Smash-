using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleGun : MonoBehaviour
{
    public Rigidbody player;
    public Transform handPosition;
    public Transform cameraOrientation;
    public GameObject bullet;
    public float bulletSpeed;

    private GameObject activeBullet;
    private bool collisionFound = false;
    private LineRenderer lineRenderer;
    public float pullSpeed;
    public float range;
    private Transform grappleEnd;
    public Camera playerCam;
    public bool working;

    void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        grappleEnd = transform.GetChild(1);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = handPosition.position;
        transform.forward = cameraOrientation.forward;

        if (Input.GetButtonDown("Fire2") && working)
        {
            GameObject newBullet = Instantiate(bullet, transform.GetChild(1).position, transform.rotation);
            //newBullet.transform.LookAt(transform.forward);
            activeBullet = newBullet;
            Rigidbody rb = activeBullet.GetComponent<Rigidbody>();
            

            // create a ray from screen centre towards horizon (where we are aimning)
            Vector3 ScreenCentreCoordinates = new Vector3(0.5f, 0.5f, 0f);    
            Ray ray = playerCam.ViewportPointToRay(ScreenCentreCoordinates);
            RaycastHit hit;

            Vector3 projectileDestination;
    
            // if the raycast collides with an object, then make that our projectile target
            if (Physics.Raycast(ray, out hit))
            {
                projectileDestination = hit.point;
            }
            // if it doesn't hit anything, make our projectile target 1000 away from us (adjust this accordingly)
            else
            {
                projectileDestination = ray.GetPoint(1000f);
            }

            newBullet.transform.LookAt(projectileDestination);
            Vector3 inSpeed = player.velocity.magnitude * newBullet.transform.forward;
            rb.velocity += inSpeed;

            rb.AddForce(newBullet.transform.forward * bulletSpeed, ForceMode.Impulse);

            activeBullet.GetComponent<GrappleBullet>().SetGun(this);
            collisionFound = false;
            transform.GetChild(2).gameObject.SetActive(false);
        }

        if(Input.GetButtonUp("Fire2") && working) {
            Destroy(activeBullet);
            activeBullet = null;
            collisionFound = false;
            transform.GetChild(2).gameObject.SetActive(true);
        }

        if(activeBullet != null) {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, grappleEnd.position);
            lineRenderer.SetPosition(1, activeBullet.transform.GetChild(1).position);

            if((Vector3.Distance(activeBullet.transform.position, player.transform.position) >= range) && !collisionFound) {
                Destroy(activeBullet);
                activeBullet = null;
            }
        } else {
            lineRenderer.enabled = false;
        }

        if(collisionFound) {
            //print("Found a wall");
            Vector3 direction = activeBullet.transform.position - player.transform.position;
            float theDistance = Vector3.Distance(activeBullet.transform.position, player.transform.position);
            theDistance *= 0.5f;
            player.AddForce(direction * pullSpeed * Time.deltaTime, ForceMode.Force);
            player.GetComponent<CharacterMovement>().grappling = true;
        } else {
            player.GetComponent<CharacterMovement>().grappling = false;
        }
    }

    public void CollisionFound() {
        collisionFound = true;
    }

    private void Recoil() {

    }

    public void DeleteBullet() {
        if(activeBullet != null) {
            Destroy(activeBullet);
            activeBullet = null;
        }
    }
}

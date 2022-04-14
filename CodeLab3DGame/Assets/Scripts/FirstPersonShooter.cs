using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonShooter : MonoBehaviour
{

    public GameObject mediumCubePrefab;
    public GameObject smallCubePrefab;


    public Vector3 originalVelocity;

    public float offsetForMediumCube;

    public float offsetForSmallCube;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyePosition = transform.position; //the position of camera
        Vector3 mousePos = Input.mousePosition; // the position of mouse
        mousePos.z = Camera.main.nearClipPlane; //set mouse's z pos to the near clip plane
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);//change your mouse position from screen point to world point
        Vector3 dir = mouseWorldPos - eyePosition; // get the direction from camera to mouse
        dir.Normalize(); //get the direction and makes it keep going until it hit something

        RaycastHit hitter = new RaycastHit(); // declare the hitter
        
        if (Physics.Raycast(eyePosition, dir, out hitter)) //cast a ray and check if there's an object on the way of your ray
        {
            if (hitter.collider.gameObject.tag == "Target") // if the object's tag is Target
            {
                score++; // score+1


                originalVelocity = hitter.collider.gameObject.GetComponent<Rigidbody>().velocity; // get the velocity of this object

                
                Destroy(hitter.collider.gameObject);//destroy it

                //instantiate 4 fragments
                GameObject mediumFragment01 = Instantiate(mediumCubePrefab); 
                    mediumFragment01.transform.position = new Vector3(
                                        hitter.collider.gameObject.transform.position.x- offsetForMediumCube, //they all have slightly different position
                                        hitter.collider.gameObject.transform.position.y- offsetForMediumCube,
                                        hitter.collider.gameObject.transform.position.z);
                    mediumFragment01.GetComponent<Rigidbody>().AddForce(originalVelocity * 50); // set the velocity of the bigger object to this fragment

                GameObject mediumFragment02 = Instantiate(mediumCubePrefab);
                mediumFragment02.transform.position = new Vector3(
                                    hitter.collider.gameObject.transform.position.x - offsetForMediumCube,//they all have slightly different position
                                    hitter.collider.gameObject.transform.position.y + offsetForMediumCube,
                                    hitter.collider.gameObject.transform.position.z);
                mediumFragment02.GetComponent<Rigidbody>().AddForce(originalVelocity * 50);// set the velocity of the bigger object to this fragment

                GameObject mediumFragment03 = Instantiate(mediumCubePrefab);
                mediumFragment03.transform.position = new Vector3(
                                    hitter.collider.gameObject.transform.position.x + offsetForMediumCube,//they all have slightly different position
                                    hitter.collider.gameObject.transform.position.y - offsetForMediumCube,
                                    hitter.collider.gameObject.transform.position.z);
                mediumFragment03.GetComponent<Rigidbody>().AddForce(originalVelocity * 50);// set the velocity of the bigger object to this fragment

                GameObject mediumFragment04 = Instantiate(mediumCubePrefab);
                mediumFragment04.transform.position = new Vector3(
                                    hitter.collider.gameObject.transform.position.x + offsetForMediumCube,//they all have slightly different position
                                    hitter.collider.gameObject.transform.position.y + offsetForMediumCube,
                                    hitter.collider.gameObject.transform.position.z);
                mediumFragment04.GetComponent<Rigidbody>().AddForce(originalVelocity * 50);// set the velocity of the bigger object to this fragment
            }


            


            if (hitter.collider.gameObject.tag == "MediumTarget")
            {
                score += 4;

                originalVelocity = hitter.collider.gameObject.GetComponent<Rigidbody>().velocity;// get the velocity of this object


                Destroy(hitter.collider.gameObject);//destroy it

                //instantiate 4 fragments of this object
                GameObject smallFragment01 = Instantiate(smallCubePrefab);
                smallFragment01.transform.position = new Vector3(
                                    hitter.collider.gameObject.transform.position.x - offsetForSmallCube,//they all have slightly different position
                                    hitter.collider.gameObject.transform.position.y - offsetForSmallCube,
                                    hitter.collider.gameObject.transform.position.z);
                smallFragment01.GetComponent<Rigidbody>().AddForce(originalVelocity * 50);// set the velocity of the bigger object to this fragment

                GameObject smallFragment02 = Instantiate(smallCubePrefab);
                smallFragment02.transform.position = new Vector3(
                                    hitter.collider.gameObject.transform.position.x - offsetForSmallCube,//they all have slightly different position
                                    hitter.collider.gameObject.transform.position.y + offsetForSmallCube,
                                    hitter.collider.gameObject.transform.position.z);
                smallFragment02.GetComponent<Rigidbody>().AddForce(originalVelocity * 50);// set the velocity of the bigger object to this fragment

                GameObject smallFragment03 = Instantiate(smallCubePrefab);
                smallFragment03.transform.position = new Vector3(
                                    hitter.collider.gameObject.transform.position.x + offsetForSmallCube,//they all have slightly different position
                                    hitter.collider.gameObject.transform.position.y - offsetForSmallCube,
                                    hitter.collider.gameObject.transform.position.z);
                smallFragment03.GetComponent<Rigidbody>().AddForce(originalVelocity * 50);// set the velocity of the bigger object to this fragment

                GameObject smallFragment04 = Instantiate(smallCubePrefab);
                smallFragment04.transform.position = new Vector3(
                                    hitter.collider.gameObject.transform.position.x + offsetForSmallCube,//they all have slightly different position
                                    hitter.collider.gameObject.transform.position.y + offsetForSmallCube,
                                    hitter.collider.gameObject.transform.position.z);
                smallFragment04.GetComponent<Rigidbody>().AddForce(originalVelocity * 50);// set the velocity of the bigger object to this fragment
            }


        }


    }
}

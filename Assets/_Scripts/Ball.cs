using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioClip bounceSound;
    public float speed = 36.0f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 90, 0);
        rb = GetComponent<Rigidbody>();

        //create a random angle
        float angle = Random.value * 44 - 22; //-22 to 22

        // decide if its going left or right
        if (Random.value < .5f)
            angle += 180;

        //set the ball to that angle
        transform.eulerAngles += new Vector3(0, angle, 0);

        //give it forward speed

        rb.velocity= transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag("Floor"))
            AudioSource.PlayClipAtPoint(bounceSound, transform.position, 1.0f);
    }
}

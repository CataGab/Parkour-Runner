using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereRotator : MonoBehaviour
{
    public Transform[] target;
    public float speed;
    private int current;

    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);
       /* if (transform.position != target[current].position) {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }else current = (current + 1) % target.Length;
        */
        // this code made the tree from the sky move (the particles will constantly move) not static but it made errors I couldn't solve.

    }
}

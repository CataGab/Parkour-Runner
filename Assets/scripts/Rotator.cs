using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    private AudioSource sound;

    void OnTriggerEnter()
    {
        sound = GetComponent<AudioSource>();
        sound.Play();
    }
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime);

       
}
}

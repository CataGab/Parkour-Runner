using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemy : MonoBehaviour {
    public GameObject player;
    public AudioClip[] footsounds;
    


    private NavMeshAgent nav;
    private AudioSource sound;
    private Animator anim;
    private string state = "idle";
    private bool alive = true;

	// Use this for initialization
	void Start () {

        nav = GetComponent<NavMeshAgent>();
        sound = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        anim.speed = 3.5f;
        nav.speed = 10.5f;
        
    }

    public void footstep(int _num) {
        sound.clip = footsounds[_num];
        sound.Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            //the following code should have made the monster keep changing his place to a random point and afterwards I was going to add the cone view to him from the wikiunity3d website to make the monster see the player. When he spots the player he starts chasing him.
            /*anim.SetFloat("velocity", nav.velocity.magnitude);

            //idle
            if (state == "idle") {
                //pick a random place to walk to
                Vector3 randomPos = Random.insideUnitSphere * 20f;
                NavMeshHit navHit;
                NavMesh.SamplePosition(transform.position + randomPos, out navHit, 20f, NavMesh.AllAreas);
                nav.SetDestination(navHit.position);
                state = "breathing";
            }
            //Walk
            if (state == "walk") {
                if (nav.remainingDistance <= nav.stoppingDistance && !nav.pathPending) {
                    state = "idle";
                }
            }*/
            anim.SetFloat("velocity", nav.velocity.magnitude);
            nav.SetDestination(player.transform.position);

        }
    }
    
}

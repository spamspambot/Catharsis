using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    public float pitchRange;
    public float lifetime;
    AudioSource AS;

    //public AudioClip clip1;


    // Use this for initialization
    void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.pitch = Random.Range(1 - pitchRange, 1 + pitchRange);
        StartCoroutine("DestroySelf");
    }

    // Update is called once per frame
    void Update()
    {

    }

       IEnumerator DestroySelf() {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}

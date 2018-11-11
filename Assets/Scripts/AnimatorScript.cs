using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour {
    public Animator anim;
    public float animatorTime;
	// Use this for initialization
	void Start () {
        anim.enabled = true;
        StartCoroutine("DisableAnimator");
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Arm")) StartCoroutine("DisableAnimator");
    }

    // Update is called once per frame
    IEnumerator DisableAnimator() {
        yield return new WaitForSeconds(animatorTime);
        anim.enabled = false;
    }
}

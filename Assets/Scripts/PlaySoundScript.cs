using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundScript : MonoBehaviour
{
    public GameObject soundEffect;
    public bool allTags;
    public List<string> affectedTags;

    private void OnCollisionEnter(Collision collision)
    {
        if (allTags) Instantiate(soundEffect, transform.position, Quaternion.identity);
        else
            for (int i = 0; i < affectedTags.Count; i++)
            {
                if (collision.gameObject.CompareTag(affectedTags[i]))
                    Instantiate(soundEffect, transform.position, Quaternion.identity);
            }

    }
}

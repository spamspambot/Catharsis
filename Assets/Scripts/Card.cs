using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour
    {
    private Vector3 screenPoint;
    private Vector3 offset;
    private Rigidbody rBody;
    public float moveSpeed = 2f;

    public BoxCollider collider;
    public SphereCollider bhCollider;
    public Collider expCollider;

    public GameObject glassCard;
    public GameObject normalCard;

    public float power = 2f;
    public float radius = 4f;

    public bool isGlass = false;

    public bool isExpand = false;

    private AudioSource audio;
    public AudioClip glassSound;
    public AudioClip cardSound;

    void Start()
        {
        rBody = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<BoxCollider>();
        audio = gameObject.GetComponent<AudioSource>();
        }


    // Update is called once per frame
    void Update()
        {

        }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name.ToString() == "Plane" || collision.transform.name.ToString().Contains("Table"))
        {
            audio.clip = cardSound;
            audio.Play();
        }
        
    }

    private void OnTriggerEnter(Collider other)
        {
        if (other == bhCollider)
            {
            BlackHole();
            }

        else if (other == expCollider)
            {
            isExpand = true;
            Glass(2f);            
            }
        }

    public void OnMouseDown()
        {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        rBody.useGravity = false;

        if (isGlass)
            {
            Glass(power);
            }
        }

    public void OnMouseDrag()
        {
        Vector3 cursorScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPos = Camera.main.ScreenToWorldPoint(cursorScreenPoint) + offset;

        //transform.position = cursorPos;

        
        //rb.velocity = Vector3.Lerp(rb.velocity, cursorPos - transform.position, drag * Time.deltaTime);
        rBody.velocity = (cursorPos - transform.position) * moveSpeed;
        }

    public void OnMouseUp()
        {
        rBody.useGravity = true;
        }

    public void Glass(float force)
        {
        glassCard.SetActive(true);
        glassCard.transform.SetParent(null);

        if (transform.parent.parent.name.ToString() == "Scene 4" || transform.parent.parent.name.ToString() == "Scene 5")
            {
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

            foreach (Collider hit in colliders)
                {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    {
                    if (rb.gameObject.name.ToString().Contains("Shard"))
                        {
                        Debug.Log("hit");
                        if (isExpand)
                        {
                            rb.useGravity = false;
                            
                        }
                        rb.AddExplosionForce(force, explosionPos, radius, 0f, ForceMode.Impulse);
                        audio.clip = glassSound;
                        audio.Play();
                        }
                    }
                }
            }
        

        normalCard.SetActive(false);
        //gameObject.SetActive(false);
        collider.enabled = false;
    }

    public void BlackHole()
        {
        glassCard.SetActive(true);
        glassCard.transform.SetParent(null);

        normalCard.SetActive(false);
        gameObject.SetActive(false);
        }
    }

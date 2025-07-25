using UnityEngine;

public class TurnOffOnHit : MonoBehaviour
{
    public string GOtag;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision hit)
    {
        //Debug.Log("Character Collision with " + hit.gameObject.tag);
        if (hit.gameObject.CompareTag(GOtag))
        {
            Debug.Log("Character Collision with " + hit.gameObject.tag);
            gameObject.SetActive(false);
        }
    }
}

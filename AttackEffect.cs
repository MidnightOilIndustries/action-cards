using UnityEngine;
using System.Collections;

public class AttackEffect : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        StartCoroutine(AttackOver(1f));
    }
    private IEnumerator AttackOver(float wait)
    {
        yield return new WaitForSeconds(wait);
        gameObject.SetActive(false);
    }
}

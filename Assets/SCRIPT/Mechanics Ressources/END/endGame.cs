using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") /*&& GameManager.instance.player.GetComponent<Rigidbody>().velocity.magnitude > .7f*/)
        {
            transform.position += new Vector3(1000, 1000, 1000);
            StartCoroutine(TheEnd());
        }

    }

    private IEnumerator TheEnd()
    {
        GameManager.instance.player.GetComponent<FPC>().animator.SetTrigger("triggerDeath");
        yield return new WaitForSeconds(3);

        GameManager.instance.player.GetComponent<FPC>().animator.SetTrigger("triggerFade");
        yield return new WaitForSeconds(3);


        SceneManager.LoadScene("END");
        yield return null;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BinControl : MonoBehaviour {
    public GameObject player;
    public bool binTouched = false;

	void OnTriggerEnter(Collider other)
    {
        
        binTouched = true;
        Destroy(this.gameObject);
        player.GetComponent<Movement>().enabled = false;
        player.GetComponent<Animator>().SetBool("Win", true);

        if (other.tag == "PBot")
        {
           SceneManager.LoadScene(4);
        }

        if (other.tag == "GBot")
        {
            SceneManager.LoadScene(5);
        }

        if (other.tag == "MBot")
        {
            SceneManager.LoadScene(6);
        }

        if (other.tag == "PPBot")
        {
            SceneManager.LoadScene(7);
        }
       
    }
}

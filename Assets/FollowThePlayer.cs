using UnityEngine;
using System.Collections;


public class FollowThePlayer : MonoBehaviour
{
    public GameObject player;
    int teste;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if(gameObject.transform.position.x < (player.transform.position.x - 0.5f))
        {
            gameObject.transform.Translate(new Vector3(5f, 0, 0) * Time.deltaTime);
        }
        else
        {
            if (gameObject.transform.position.x > (player.transform.position.x + 0.5f))
            {
                gameObject.transform.Translate(new Vector3(-5f, 0, 0) * Time.deltaTime);
            }
            
        }
        
	}
}

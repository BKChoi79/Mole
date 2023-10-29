using UnityEngine;
using System.Collections;
using Scenes;
using Common.Utils.Pool;

public class Done_DestroyByContact : MonoBehaviour
{
	public int scoreValue;

	void Start ()
	{

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" )
			return;

		if (tag == "Enemy" && other.tag == "Enemy_Bullet")
			return;

        if (tag == "Enemy_Bullet" && other.tag == "Enemy")
            return;

        if (tag == "Enemy" && other.tag == "Enemy")
            return;


        var explosion = PoolManager.Instance.GetObject("done_explosion_asteroid");
        explosion.position = transform.position;
        explosion.rotation = transform.rotation;

   
		if (other.tag == "Player")
		{
            var explosionPlayer = PoolManager.Instance.GetObject("done_explosion_asteroid");
            explosionPlayer.position = transform.position;
            explosionPlayer.rotation = transform.rotation;
		}

        PoolManager.Instance.ReturnObject(other.transform);
        PoolManager.Instance.ReturnObject(transform);
        //Destroy (other.gameObject);
        //Destroy (gameObject);
    }
}
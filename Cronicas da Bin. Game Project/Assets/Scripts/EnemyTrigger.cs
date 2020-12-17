using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyTrigger : MonoBehaviour
{
	IsometricCharacterRenderer isoRenderer;

	protected virtual void Awake()
    {
        isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();        
    }

    public void OnTriggerStay2D(Collider2D plyr)
    {
        if (plyr.gameObject.tag == "Player")
        {
            StartCoroutine(Attack());
        }
    }

    private IEnumerator Attack()
    {
        isoRenderer.isAttacking = true;
        yield return new WaitForSeconds(0.4f);
        //Debug.Log("done casting");
        isoRenderer.isAttacking = false;
    }
}

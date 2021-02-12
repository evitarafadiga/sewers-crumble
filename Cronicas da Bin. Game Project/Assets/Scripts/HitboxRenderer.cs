using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxRenderer : MonoBehaviour
{
    public static readonly string[] states = { "A","B","C","D","DeathEffect" };

    protected Animator animator;
    private static float maxHealth = 150;
    int lastState;

    private void Awake()
    {
        //cache the animator component
        animator = GetComponent<Animator>();
    }

    public void SetState(int health)
    {
    	string[] statesArray = null;

    	lastState = StateToIndex(health);

    	animator.Play(statesArray[lastState]);
    }

    public static int StateToIndex (int health) 
    {
    	float ratio = health / maxHealth;

    	if (ratio*100 >= 80)
    	return 0;
    	else if (ratio*100 >= 60)
    	return 1;
    	else if (ratio*100 >= 40)
    	return 2;
    	else if (ratio*100 >= 20)
    	return 3;
    	else if (health <= 0)
    	return 4;
    	else
    	return 0;
    }

    public static int[] AnimatorStringArrayToHashArray(string[] animationArray)
    {
        //allocate the same array length for our hash array
        int[] hashArray = new int[animationArray.Length];
        //loop through the string array
        for (int i = 0; i < animationArray.Length; i++)
        {
            //do the hash and save it to our hash array
            hashArray[i] = Animator.StringToHash(animationArray[i]);
        }
        //we're done!
        return hashArray;
    }
}

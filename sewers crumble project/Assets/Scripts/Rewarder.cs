using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Rewarder : MonoBehaviour
 {
    [SerializeField]
    private int minimumCount = 2;
    [SerializeField]
    private int maximumCount = 5;
    [SerializeField]
    private GameObject prefab = null;
 
    public int MinimumCount 
    {
        get { return this.minimumCount; }
        set { this.minimumCount= value; }
    }
    public int MaximumCount 
    {
        get { return this.maximumCount ; }
        set { this.maximumCount = value; }
    }
    public GameObject Prefab
    {
        get { return this.prefab; }
        set { this.prefab= value; }
    }

    public void RewardItems()
    {
    	//int count = Random.Range(this.MinimumCount, this.MaximumCount );
        int count = 1;

        for (int i = 0; i < count; ++i) {
            Instantiate(this.prefab, this.gameObject.transform.position, Quaternion.identity);
        }
    }
}
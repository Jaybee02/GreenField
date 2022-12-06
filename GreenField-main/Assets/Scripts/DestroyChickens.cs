using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyChickens : MonoBehaviour
{
    public bool ToSpawn = true;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyPest());
    }

    IEnumerator DestroyPest()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}

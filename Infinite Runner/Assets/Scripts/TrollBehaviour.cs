using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollBehaviour : MonoBehaviour
{
    public float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {

        transform.localScale = new Vector3(transform.localScale.x *-1,transform.localScale.y,transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

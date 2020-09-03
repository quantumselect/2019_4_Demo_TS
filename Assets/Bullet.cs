using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody rbody;
    public float lifeTime;
    
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate(Vector3 position, Vector3 velocity)
    {
        transform.position = position;
        rbody.velocity = velocity;

        gameObject.SetActive(true);
        StartCoroutine("Decay");
    }
    private IEnumerator Decay()
    {
        yield return new WaitForSeconds(lifeTime);
        Deactivate();
    }

    public void Deactivate()
    {
        BulletPool.main.AddToPool(this);

        StopAllCoroutines();

        gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("A bullet hit something!");

        Deactivate();
    }
}

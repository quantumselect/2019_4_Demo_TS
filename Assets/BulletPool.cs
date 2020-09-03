using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletPool : MonoBehaviour
{
    //Singleton Reference
    public static BulletPool main;

    //Settings
    public GameObject bulletPrefab;
    public int poolSize = 100;

    private List<Bullet> availableBullets;

    // Start is called before the first frame update
    void Start()
    {
        availableBullets = new List<Bullet>();
        for (int i = 0; i < poolSize; i++)
        {
            Bullet b = Instantiate(bulletPrefab, transform).GetComponent<Bullet>();
            b.gameObject.SetActive(false);

            availableBullets.Add(b);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        main = this;
    }

    public void PickFromPool(Vector3 position, Vector3 velocity)
    {
        //Prevent Errors
        if (availableBullets.Count < 1) return;

        //Activate the bullet
        availableBullets[0].Activate(position, velocity);

        //Pop it from the list
        availableBullets.RemoveAt(0);
    }
    public void AddToPool(Bullet bullet)
    {
        if (!availableBullets.Contains(bullet)) availableBullets.Add(bullet);
    }

}

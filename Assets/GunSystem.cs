using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GunSystem : MonoBehaviour
{
    public int damage;
    public float timeBetweenShooting, spread, range, realoadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold, realoding;
    int bulletLeft, bulletsShot;

    

    bool shooting, readyToShoot = true, reloading;

    public Transform fpsCam;
    public Transform attackPoint;
    public BulletParticle particle;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
   // public TextMeshProUGUI text;
    public GameObject muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
        
       // text.SetText(bulletLeft + "/" + magazineSize);
    }

    private void MyInput()
    {
        /*if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else*/ shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) &&  !reloading) Reload();

        if (shooting)
        {
            Debug.Log("Shooting");
            Shoot();
        }
       

    }
    private void Reload()
    {
        reloading = true;
        Debug.Log("Reloading");
        Invoke("ReloadFinished", realoadTime);
    }

    void ReloadFinished()
    {
        bulletLeft = magazineSize;
        reloading = false;
    }
    private void Shoot()
    {
        Debug.Log("Shots Fired");
        readyToShoot = false;

        //  float x = Random.Range(-spread, spread);
        // float y = Random.Range(-spread, spread);

        Vector3 directiom = fpsCam.transform.forward;

        Debug.DrawRay(fpsCam.transform.position, directiom * range, Color.blue, 50f, true);
        if (Physics.Raycast(fpsCam.transform.position, directiom * range, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

           // if (rayHit.collider.CompareTag("ENEMY"))
            //{
                rayHit.collider.GetComponent<EnemyAI>().TakeDamage(damage);
           // }
        }
      //  Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        bulletLeft--;
        bulletsShot--;
    

        if (bulletsShot > 0 && bulletLeft > 0)
            Invoke("ResetShot", timeBetweenShots);


    }

    private void Awake()
    {
        bulletLeft = magazineSize;
        readyToShoot = true;
    }
    void ResetShot()
    {
        readyToShoot = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(fpsCam.position, fpsCam.transform.forward * range);
    }
}


﻿using UnityEngine;
using System.Collections;

public class RayCastShoot : MonoBehaviour {
										
	public float fireRate = 0.25f;										
	public float weaponRange = 50f;																			
	public Transform gunEnd;											

	private Camera fpsCam;												
	private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);	
	private AudioSource gunAudio;										
	private LineRenderer laserLine;										
	private float nextFire;

    public CameraMovement cam = null;
	void Start () 
	{
		
		laserLine = GetComponent<LineRenderer>();

		
		gunAudio = GetComponent<AudioSource>();

		
		fpsCam = GetComponentInParent<Camera>();

        cam.GetComponent<CameraMovement>();
	}
	

	void Update () 
	{
		
		if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire) 
		{
            if (cam.Score < 20)
            {
                fireRate = 0.25f;
            }
            else
            {
                fireRate = 0.1f;
            }
			nextFire = Time.time + fireRate;

            StartCoroutine (ShotEffect());

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint (new Vector3(0.5f, 0.5f, 0.0f));
      
            RaycastHit hit;

			laserLine.SetPosition (0, gunEnd.position);

			if (Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange))
			{

				laserLine.SetPosition (1, hit.point);

				if(hit.collider.tag == "Food")
                {
					Destroy(hit.collider.gameObject);
                }

                if (hit.collider.tag == "FastFood")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
			else
			{
				
                laserLine.SetPosition (1, rayOrigin + (fpsCam.transform.forward * weaponRange));
			}
		}
	}


	private IEnumerator ShotEffect()
	{
		gunAudio.Play ();
		laserLine.enabled = true;

		yield return shotDuration;

		laserLine.enabled = false;
	}
}
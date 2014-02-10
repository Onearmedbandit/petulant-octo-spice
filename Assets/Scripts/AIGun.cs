using UnityEngine; 
using System.Collections;

public class AIGun : MonoBehaviour {

	public float reloadTime = 1f;
	public float rotationSpeed = 5f;
	public float firePauseTime = .25f;
	public Transform target = null;
	private float nextFireTime;
	private float nextMoveTime = 5f;
	public Transform BulletSpawn;
	private Quaternion desiredRotation;
	public GameObject Bullet;
	public float bulletSpeed = 5000f;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		
		if (target!=null)
			
		{
			
			if(Time.time >= nextMoveTime)
				
			{
				
				//transform.rotation = Vector3.RotateTowards; 
				
				Vector3 targetDir = target.position - transform.position;
				float step = rotationSpeed * Time.deltaTime;
				Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
				//Debug.DrawRay(transform.position, newDir, Color.red);
				transform.rotation = Quaternion.LookRotation(newDir);
				
			}
			
			
			if(Time.time >= nextFireTime)
				
			{
				
				FireProjectile ();  
				
			}
			
		}
		
		
	}
	
	
	void OnTriggerEnter(Collider other){
		
		
		if (other.gameObject.tag == "Player")
			
		{
			
			nextFireTime = Time.deltaTime + (reloadTime*0.75f);
			target = other.gameObject.transform;
			
			
		}
		
		
		
	}
	
	
	void OnTriggerExit(Collider other){
		
		
		if (other.gameObject.transform == target)
			
			
		{
			
			target = null;    
			
		}
		
		
		
	}
	
	
	//   void CalculateAimPosition(Vector3 targetPos){
	
	//    Vector3 aimPoint = new Vector3(targetPos.x, targetPos.y, targetPos.z);
	
	//   desiredRotation = Quaternion.LookRotation (aimPoint);
	
	
	//  }
	
	
	void FireProjectile(){
		
		
		
		nextFireTime = Time.time+reloadTime;
		
		nextMoveTime = Time.time+firePauseTime;
		
		GameObject go =  Instantiate (Bullet, BulletSpawn.transform.position, desiredRotation) as GameObject;
		go.rigidbody.AddForce(transform.forward * bulletSpeed);
		
		// Rigidbody clone;
		// clone = Instantiate(Bullet, transform.position, transform.rotation) as Rigidbody;
		// clone.velocity = transform.TransformDirection(Vector3.forward * 10);
	}
}
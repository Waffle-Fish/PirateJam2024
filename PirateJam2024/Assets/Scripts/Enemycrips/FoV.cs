using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class FieldOfView : MonoBehaviour
{
   public float radius;
    [Range(0,360)]
  public float angle;

   public GameObject playerRef;

   private LayerMask targetMask;
   private LayerMask obstructionMask;

   public bool canSeePlayer;
   NavMeshAgent navMeshAgent;
   Transform target;
   

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }
     
     private IEnumerator FOVRoutine()
     {
        WaitForSeconds wait = new WaitForSeconds(0.2f);
        while(true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
     }

     private void FieldOfViewCheck()
     {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);

        if(rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.position, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                  

                else 
                    canSeePlayer = false;
                     

            }
            else 
                canSeePlayer = false;
                
        }
        else if(canSeePlayer)
            canSeePlayer = false;
             
     }
 private void Fixedupdate()
 {
      navMeshAgent = transform.parent.GetComponentInChildren<NavMeshAgent>();
 }
}
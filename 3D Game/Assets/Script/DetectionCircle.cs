using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCircle : MonoBehaviour
{
    public float visionRadius;
    [Range(0,360)]
    public float visionAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    void Start() {
        StartCoroutine("FindTargetWithDelay", .2f);
    }
    IEnumerator FindTargetWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds (delay);
            findVisibleTargets();
        }
    }


    void findVisibleTargets() {
            visibleTargets.Clear ();

        Collider[] targetsInView = Physics.OverlapSphere (transform.position, visionRadius, targetMask);
        for (int i = 0; i < targetsInView.Length; i++) {
            Transform target = targetsInView[i].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, directionToTarget) < visionAngle /2) {
                float distanceToTarget = Vector3.Distance (transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstacleMask)) { //Sees a target in range
                    visibleTargets.Add(target);
                }
            }
        }
    }

    public Vector3 DirectionOfVision(float angle, bool angleIsGlobal) {
        if (!angleIsGlobal) {
            angle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }
}

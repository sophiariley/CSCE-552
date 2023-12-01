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


    public float Mesh;

    public MeshFilter viewMeshFilter;
    Mesh viewMesh;
    private int _numberOfDucklings = 3;

    void Start() {
        viewMesh = new Mesh();
        viewMesh.name = "View Mesh";
        viewMeshFilter.mesh = viewMesh;

        StartCoroutine("FindTargetWithDelay", .2f);
    }
    IEnumerator FindTargetWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds (delay);
            findVisibleTargets();
        }
    }


    void LateUpdate() {
        drawFOV();
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
                    if (transform.gameObject.tag == "Dog" && target.gameObject.tag == "Duckling") {
                        target.gameObject.GetComponent<NavigationScript>()._isFollowing = false;
                    }
                    /*if (transform.gameObject.tag == "Mother Duck" && visibleTargets.Length == _numberOfDucklings) {

                    }*/
                }
            }
        }
    }

    void drawFOV() {
        int stepCount = Mathf.RoundToInt(visionAngle * Mesh);
        float stepSize = visionAngle / stepCount;
        List<Vector3> viewPoints = new List<Vector3> ();

        for (int i = 0; i <= stepCount; i++) {
            float angle = transform.eulerAngles.y - visionAngle/2 + stepSize * i;
            ViewCastInfo newViewCast = ViewCast(angle);
            viewPoints.Add(newViewCast.point);
        }

        int vertexCount = viewPoints.Count + 1;
        Vector3[] vertices = new Vector3[vertexCount];
        int[] triangles = new int[(vertexCount - 2) * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < vertexCount - 1; i++) {
            vertices[i + 1] = transform.InverseTransformPoint(viewPoints[i]);

            if (i < vertexCount - 2) {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = i + 2;
            }
        }

        viewMesh.Clear();
        viewMesh.vertices = vertices;
        viewMesh.triangles = triangles;
        viewMesh.RecalculateNormals();
    }

    ViewCastInfo ViewCast(float globalAngle) {
        Vector3 dir = DirectionOfVision (globalAngle, true);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, dir, out hit, visionRadius, obstacleMask)) {
            return new ViewCastInfo(true, hit.point, hit.distance, globalAngle);
        }
        else {
            return new ViewCastInfo(false, transform.position + dir * visionRadius, visionRadius, globalAngle);
        }
    }

    public Vector3 DirectionOfVision(float angle, bool angleIsGlobal) {
        if (!angleIsGlobal) {
            angle += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }


    public struct ViewCastInfo {
        public bool hit;
        public Vector3 point;
        public float dst;
        public float angle;

        public ViewCastInfo( bool _hit, Vector3 _point, float _dst, float _angle) {
            hit = _hit;
            point = _point;
            dst = _dst;
            angle = _angle;
        }
    }
}

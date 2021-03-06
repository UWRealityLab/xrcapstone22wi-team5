using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stream : MonoBehaviour
{
    private LineRenderer line = null;
    private ParticleSystem splash = null;
    private Coroutine pour = null;

    private Vector3 target = Vector3.zero;

    public LiquidContainer container = null;

    void Awake() {
        line = GetComponent<LineRenderer>();
        splash = GetComponentInChildren<ParticleSystem>();

    }
    // Start is called before the first frame update
    void Start()
    {
        MoveToPosition(0, transform.position);
        MoveToPosition(1, transform.position);
        Renderer splashRender = GetComponentInChildren<ParticleSystemRenderer>();
        splashRender.material.color = line.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Begin() {
        StartCoroutine(UpdateSplash());
        pour = StartCoroutine(nameof(BeginPouring));
    }

    private IEnumerator BeginPouring() {
        while(gameObject.activeSelf) {
            target = findEndPoint();

            MoveToPosition(0, transform.position);
            AnimateToPosition(1, target);
            yield return null;
        }
    }

    private Vector3 findEndPoint() {
        RaycastHit hit;
        RaycastHit containerHit;
        Ray ray = new Ray(transform.position, Vector3.down);
        Ray containerRay = new Ray(transform.position, Vector3.down);
        int layerMask = (1 << 9) | (1 << 10); // only cast against layers 9 and 10
        layerMask = ~layerMask; // nevermind, cast against everything besides layers 9 and 10
        Physics.Raycast(ray, out hit, 10.0f);
        Physics.Raycast(containerRay, out containerHit, 10.0f, layerMask);
        // check if container ray hit a fillable
        if (containerHit.collider != null) {
            LiquidContainer f = containerHit.collider.isTrigger? containerHit.collider.GetComponentInParent<LiquidContainer>() : null;
            if (f != null && f.isFillable) {
                Debug.Log("Stream registered container " + f.tag);
                container = f;
            } else {
                container = null;
            }
        }
        Vector3 endPoint = hit.collider ? hit.point : ray.GetPoint(10.0f);
        return endPoint;
    }

    private void MoveToPosition(int index, Vector3 targetPosition) {
        line.SetPosition(index, targetPosition);
    }

    private void AnimateToPosition(int index, Vector3 targetPosition) {
        Vector3 curPoint = line.GetPosition(index);
        Vector3 newPosition = Vector3.MoveTowards(curPoint, targetPosition, Time.deltaTime * 1.75f);
        line.SetPosition(index, newPosition);
    }

    public void End() {
        StopCoroutine(pour);
        pour = StartCoroutine(EndPour());
    }

    private IEnumerator EndPour() {
        while(!HasReachedPosition(0, target)) {
            AnimateToPosition(0, target);
            AnimateToPosition(1, target);
            yield return null;
        }
        Destroy(gameObject);
    }

    private bool HasReachedPosition(int index, Vector3 targetPosition) {
        Vector3 curPoint = line.GetPosition(index);
        return curPoint == targetPosition;
    }

    private IEnumerator UpdateSplash() {
        while(gameObject.activeSelf) {
            splash.gameObject.transform.position = target;
            bool isHitting = HasReachedPosition(1, target);
            splash.gameObject.SetActive(isHitting && container == null);

            yield return null;

        }
    }
}

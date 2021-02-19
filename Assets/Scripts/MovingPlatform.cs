using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] GameObject _pointA;
    [SerializeField] GameObject _pointB;
    [SerializeField] float _movementSpeed;

    Vector3 _target;

    // Start is called before the first frame update
    void Start()
    {
        _target = _pointA.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == _pointA.transform.position && _target == _pointA.transform.position)
            _target = _pointB.transform.position;

        if (transform.position == _pointB.transform.position && _target == _pointB.transform.position)
            _target = _pointA.transform.position;

        transform.position = Vector3.MoveTowards(transform.position, _target, _movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = transform;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            other.transform.parent = null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Franco && Bortoló
public class PushableBox : MonoBehaviour
{
    [SerializeField] private float _units, _boxSpeed;
    [SerializeField] private Rigidbody _RB;
    [SerializeField] private BoxCollider _myCollider;

    [SerializeField] private Material _emissiveMat;
    [SerializeField] private Renderer _obj;

    private Vector3 _destination, _face;
    private float _time, _destinationWithBoxSize;

    public delegate void MyDelegate();
    public MyDelegate myDelegate = delegate { };

    private void Start()
    {
        _destination = transform.position;
        _emissiveMat = _obj.GetComponent<Renderer>().material;
    }

    private void Update()
    {
        myDelegate();
        _time += Time.deltaTime;
    }

    void ArtificialUpdateBox()
    {
        _destination.y = transform.position.y;
        _RB.MovePosition(Vector3.MoveTowards(transform.position, _destination, _boxSpeed * Time.deltaTime));
        _time = 0;

        if (transform.position.x == _destination.x && transform.position.z == _destination.z)
        {
            myDelegate = delegate { };
            _destination = transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PushHitbox") && _time >= .3f)
        {           
            _face = transform.position - other.transform.parent.position;

            if (Mathf.Abs(_face.x) > Mathf.Abs(_face.z))
            {
                if (_face.x < 0)      // Left
                {
                    _destination = transform.position;
                    _destination.x -= _units;
                    _destinationWithBoxSize = _units + _myCollider.size.x * 0.5f;
                }
                else                  // Right
                {
                    _destination = transform.position;
                    _destination.x += _units;
                    _destinationWithBoxSize = _units + _myCollider.size.x * 0.5f;
                }
            }
            else
            {
                if (_face.z < 0)      // Back
                {
                    _destination = transform.position;
                    _destination.z -= _units;
                    _destinationWithBoxSize = _units + _myCollider.size.z * 0.5f;
                }
                else                  // Front
                {
                    _destination = transform.position;
                    _destination.z += _units;
                    _destinationWithBoxSize = _units + _myCollider.size.z * 0.5f;
                }
            }

            if (!Physics.Raycast(transform.position, _destination - transform.position, _destinationWithBoxSize) && this.enabled)
            {
                myDelegate = ArtificialUpdateBox;
                AudioManager.instance.Play("BoxBeingPushed");
            }
            else
            {
                AudioManager.instance.Play("HittingImmovableBox");
            }           
        }

        if (other.CompareTag("Plate"))
        {
            _emissiveMat.EnableKeyword("_EMISSION");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Plate"))
        {
            _emissiveMat.DisableKeyword("_EMISSION");
        }
    }
}

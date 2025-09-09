using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Snowman : MonoBehaviour
{
    [SerializeField] private float _force = 7;
    
    private Spawner _spawner;

    private Color _color;

    private void Awake()
    {
        _color = GetComponent<MeshRenderer>().materials[0].color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Gift"))
        {
            var gift = collision.gameObject.GetComponent<Gift>();
        
            if (gift.GiftColor == _color)
            {
                Destroy(collision.gameObject);
            }
        }

        else if (collision.gameObject.CompareTag("Candy"))
        {
            var candy = collision.gameObject.GetComponent<Candy>();
            _color = candy.CandyColor;
            GetComponent<MeshRenderer>().materials[0].color = candy.CandyColor;
            Destroy(collision.gameObject);
            _spawner.InstantiateCandy();
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 50f))
            {
                var rigidbody = GetComponent<Rigidbody>();
                Vector3 direction = (hitInfo.point - transform.position).normalized;
                rigidbody.AddForce(direction * _force, ForceMode.Impulse);
            }
        }
    }

    public void SetSpawner(Spawner spawner)
    {
        _spawner = spawner;

    }
}
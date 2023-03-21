using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private Transform target;
    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out IReveal texture))
        {
            target = other.GetComponent<Transform>();
            var dist = Vector3.Distance(target.position, transform.position);

            if(dist <= 4 )
            {
                texture.Reveal();
            }

            if ( dist <= 2 )
            {
                texture.Switch();
            }

            if (dist > 4 )
            {
                texture.Hide();
            }
        }
    }
} 
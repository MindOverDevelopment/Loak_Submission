using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RainDropGame
{
    public class RainDrop : MonoBehaviour
    {
        [SerializeField] private ParticleSystem puddle;
        [SerializeField] private float destroyDelay = 3f;

        private void Start()
        {
            StartCoroutine(DestroyObjectDelayed(this.gameObject));
        }


        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Planes"))
            {
                GetComponent<MeshRenderer>().enabled = false;
                Vector3 intersectionPoint =  other.contacts[0].point;

                ParticleSystem newParticleSystem = Instantiate(puddle, intersectionPoint, Quaternion.identity);
                newParticleSystem.gameObject.transform.parent = null;
                newParticleSystem.Play();
            }
        }


        private IEnumerator DestroyObjectDelayed(GameObject obj)
        {
            yield return new WaitForSeconds(destroyDelay);
            GameObject parentObj = obj.transform.parent.gameObject;
            Destroy(parentObj);
        }

    }

}

using UnityEngine;
using UnityEngine.Playables;

namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class CinemachineTriggerController : MonoBehaviour
    {
        [SerializeField] private GameObject mainHero;
        [SerializeField] private PlayableDirector timeLine;
        ThirdPersonUserControl heroInput;
        Collider mainHeroCollider;
        Rigidbody mainHeroRigitB;

        private void Awake()
        {
            heroInput = mainHero.GetComponent<ThirdPersonUserControl>();
            mainHeroCollider = mainHero.GetComponent<Collider>();
            mainHeroRigitB = mainHero.GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other == mainHeroCollider)
            {
                heroInput.enabled = false;
                mainHeroRigitB.isKinematic = true;
                mainHeroRigitB.velocity = Vector3.zero;
                timeLine.Play();
                Destroy(gameObject);
            }
        }

        public void ReturnInputHero()
        {
            heroInput.enabled = true;
            mainHeroRigitB.isKinematic = false;
        }
    }
}

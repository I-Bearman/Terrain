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
                mainHeroRigitB.isKinematic = true;
                heroInput.enabled = false;
                mainHero.GetComponent<Animator>().SetFloat("Forward", 0);
                timeLine.Play();
            }
        }

        public void ReturnInputHero()
        {
            heroInput.enabled = true;
            mainHeroRigitB.isKinematic = false;
        }

        public void DeleteCutsceneTrigger()
        {
            Destroy(gameObject);
        }
    }
}

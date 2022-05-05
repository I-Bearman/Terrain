using UnityEngine;
using UnityEngine.Playables;

public class CinemachineTriggerController : MonoBehaviour
{
    [SerializeField] private Collider mainHeroCollider;
    [SerializeField] private PlayableDirector timeLine;

    private void OnTriggerEnter(Collider other)
    {
        if (other == mainHeroCollider)
        {
            timeLine.Play();
            Destroy(gameObject);
        }
    }
}

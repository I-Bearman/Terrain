using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class AnimationControler : MonoBehaviour
{
    private bool CanDustDiffusion;
    private PlayableDirector timeLine;
    [SerializeField] private Text StartCutSceneText;
    [SerializeField] private GameObject MisteriusDust, House;
    // Start is called before the first frame update
    void Start()
    {
        timeLine = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(StartCutSceneText);
            timeLine.Play();
        }

        if(MisteriusDust && CanDustDiffusion)
        {
            MisteriusDust.transform.localScale *= 1.01f;
        }
    }

    public void MistDustEmergence()
    {
        MisteriusDust.SetActive(true);
    }

    public void MistDustDiffusion()
    {
        CanDustDiffusion = true;
        Rigidbody DustBody = MisteriusDust.GetComponent<Rigidbody>();
        DustBody.AddForce(Vector3.up * 500, ForceMode.Acceleration);
    }

    public void DestroyMistDust()
    {
        Destroy(MisteriusDust);
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneTrigger : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutsceneTriggerDirector;

    [SerializeField] private bool isCutSceneTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        cutsceneTriggerDirector = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isCutSceneTriggered)
        {
            return;
        }

        if (other.CompareTag("Player"))
        {
            cutsceneTriggerDirector.Play();
            isCutSceneTriggered = true;
        }
        
    }
}

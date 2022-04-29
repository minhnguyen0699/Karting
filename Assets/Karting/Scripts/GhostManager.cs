using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public struct GhostTransform
{
    public Vector3 position;
    public Quaternion rotation;

    public GhostTransform(Transform transform)
    {
        this.position = transform.position;
        this.rotation = transform.rotation;
    }
}
public class GhostManager : MonoBehaviour
{
    public Transform kart;
    public Transform ghostkart;
    public Transform cameraPlaceholder;
    public bool recording;
    public bool playing;
    public bool isGhostEnd;
    private bool isRecordingStarted;
    private List<GhostTransform> recordedGhostTransforms = new List<GhostTransform>();
    private GhostTransform lastRecordedGhostTransform;
    public CinemachineVirtualCamera cinemachineCam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (recording && !isRecordingStarted)
        {
            isRecordingStarted = true;
            StartCoroutine(StartRecording());
        }

        if (playing == true)
        {
            Play();
        }
    }

    void Play()
    {
        ghostkart.gameObject.SetActive(true);
        StartCoroutine(StartGhost());
        playing = false;
        cinemachineCam.LookAt = cameraPlaceholder;
        cinemachineCam.Follow = cameraPlaceholder;
    }
    IEnumerator StartGhost()
    {
        for (int i = 0; i < recordedGhostTransforms.Count; i++)
        {
            ghostkart.position = recordedGhostTransforms[i].position;
            ghostkart.rotation = recordedGhostTransforms[i].rotation;
           
            yield return new WaitForFixedUpdate();
        }
        isGhostEnd = true;
    }
    IEnumerator StartRecording()
    {
        while (recording)
        {
            if (kart.position != lastRecordedGhostTransform.position || kart.rotation != lastRecordedGhostTransform.rotation)
            {
                var newGhostTransform = new GhostTransform(kart);
                recordedGhostTransforms.Add(newGhostTransform);

                lastRecordedGhostTransform = newGhostTransform;
            }
            yield return new WaitForSeconds(0.01F);
        }

        isRecordingStarted = false;
    }
}

using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] sandClips;
    [SerializeField]
    private AudioClip[] woodClips;
    [SerializeField]
    private AudioClip[] stoneClips;
    [SerializeField]
    private AudioClip[] otherClips;

    private AudioSource footstepAudioSource;
    private TerrainDetector terrainDetector;

    private void Awake()
    {
        footstepAudioSource = transform.Find("FootstepAudioSource").GetComponent<AudioSource>();
        terrainDetector = new TerrainDetector();
    }

    private void Step()
    {
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);
        AudioClip clip = GetRandomClip(terrainTextureIndex);
        if (clip != null)
        {
            footstepAudioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetRandomClip(int terrainTextureIndex)
    {
        switch (terrainTextureIndex)
        {
            case 0:
                return sandClips[Random.Range(0, sandClips.Length)];
            case 1:
                return woodClips[Random.Range(0, woodClips.Length)];
            case 2:
                return stoneClips[Random.Range(0, stoneClips.Length)];
            case 3:
            default:
                return otherClips[Random.Range(0, otherClips.Length)];
        }
    }
}
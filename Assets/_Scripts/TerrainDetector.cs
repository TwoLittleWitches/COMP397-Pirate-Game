using UnityEngine;

public class TerrainDetector
{
    public int GetActiveTerrainTextureIdx(Vector3 position)
    {
        RaycastHit hit;

        // Casts a ray downward from the position to detect the ground
        if (Physics.Raycast(position, Vector3.down, out hit))
        {
            // Checks the tags of the hit object to determine the ground material
            if (hit.collider.CompareTag("Sand"))
            {
                return 0;
            }
            if (hit.collider.CompareTag("Wood"))
            {
                return 1;
            }
            else if (hit.collider.CompareTag("Stone"))
            {
                return 2;
            }
        }

        // Returns the default index for other ground materials or when not hitting anything with the specified tags
        return 3;
    }
}
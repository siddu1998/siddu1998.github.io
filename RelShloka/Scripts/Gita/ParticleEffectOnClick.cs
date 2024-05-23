using UnityEngine;

public class ParticleEffectOnClick : MonoBehaviour
{
    public ParticleSystem rainParticleSystem;
    public ParticleSystem fireParticleSystem;

    private void Update()
    {
        // Check for mouse click (left mouse button)
        if (Input.GetMouseButtonDown(0))
        {
            // Play the rain particle system
            if (rainParticleSystem != null)
            {
                rainParticleSystem.Play();
            }
        }
    }

    private void LateUpdate()
    {
        // Check if rain particles collide with fire particles using 3D raycasts
        if (rainParticleSystem != null && fireParticleSystem != null)
        {
            ParticleSystem.Particle[] rainParticles = new ParticleSystem.Particle[rainParticleSystem.main.maxParticles];
            int numRainParticles = rainParticleSystem.GetParticles(rainParticles);

            for (int i = 0; i < numRainParticles; i++)
            {
                Vector3 particlePosition = rainParticles[i].position;
                Vector3 raycastOrigin = particlePosition;
                raycastOrigin.z = 0f; // Cast ray from the same Z position as the particles

                // Cast a ray from above the rain particle to check for collision with fire particles
                RaycastHit hit;
                if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, 100f))
                {
                    if (hit.collider.CompareTag("FireParticle"))
                    {
                        // Extinguish the fire particle by stopping its emission
                        fireParticleSystem.Stop();
                    }
                }
            }
        }
    }
}

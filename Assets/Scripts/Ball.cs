using UnityEngine;


namespace TestTask
{
    public class Ball : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Tile tile))
            {
                tile.Show();
            }
        }
    }
}


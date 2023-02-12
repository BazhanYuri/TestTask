using UnityEngine;


namespace TestTask
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] private TileVisualEffects _tileVisualEffects;






        public void Show()
        {
            _tileVisualEffects.Show();
        }
    }
}


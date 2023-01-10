using UnityEngine;

namespace JMoisesCT.UnityMechanics.Tools.TilemapExtrusion
{
    public class TileExtruder : MonoBehaviour
    {
        [SerializeField] private Texture2D _texture;

        // Start is called before the first frame update
        void Start()
        {
            Color[] pixels = _texture.GetPixels();
            Debug.Log($"{pixels}");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
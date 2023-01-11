using UnityEngine;

namespace JMoisesCT.UnityMechanics.Tools.TilemapExtrusion
{
    public class TileExtruder : MonoBehaviour
    {
        [SerializeField] private Texture2D _texture;

        [SerializeField] private Sprite _sprite;
        [SerializeField] private SpriteRenderer _renderer;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Color[] pixels = _texture.GetPixels();
                Debug.Log($"{pixels}");

                int width = _texture.width;
                int height = _texture.height;

                //Texture2D texture = new Texture2D(_texture.width + 2, _texture.height + 2);
                Texture2D texture = new Texture2D(width, height);
                
                for (int y = 0; y < texture.height; y++)
                {
                    for (int x = 0; x < texture.width; x++)
                    {
                        texture.SetPixel(x, y, pixels[x + y * width]);
                    }
                }

                texture.Apply();
                _sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, width, height), new Vector2(0.5f, 0.5f), 100.0f);

                _renderer.sprite = _sprite;
            }
        }
    }
}
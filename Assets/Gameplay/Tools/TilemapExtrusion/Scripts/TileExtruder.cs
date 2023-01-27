using UnityEngine;

namespace JMoisesCT.UnityMechanics.Tools.TilemapExtrusion
{
    public class TileExtruder : MonoBehaviour
    {
        [SerializeField] private Texture2D _texture;

        [SerializeField] private Sprite _sprite;
        [SerializeField] private SpriteRenderer _renderer;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Color[] pixels = _texture.GetPixels();
                Debug.Log($"{pixels}");

                int originalWidth = _texture.width;
                int originalHeight = _texture.height;
                int newWidth = originalWidth + 2;
                int newHeight = originalHeight + 2;

                Texture2D texture = new Texture2D(newWidth, newHeight);

                for (int y = 0; y < originalHeight; y++)
                {
                    for (int x = 0; x < originalWidth; x++)
                    {
                        int copyY = (y == 0) ? 0 : (y == originalHeight - 1) ? newHeight - 1 : -1;
                        if (copyY != -1)
                        {
                            texture.SetPixel(x + 1, copyY, pixels[x + y * originalWidth]);
                        }
                        int copyX = (x == 0) ? 0 : (x == originalWidth - 1) ? newWidth - 1 : -1;
                        if (copyX != -1)
                        {
                            texture.SetPixel(copyX, y + 1, pixels[x + y * originalWidth]);
                        }
                        // This code copies the texture in the center of the new texture.
                        texture.SetPixel(x + 1, y + 1, pixels[x + y * originalWidth]);
                    }
                }
                // For each corner.
                texture.SetPixel(0, 0, pixels[0]); // Bottom left
                texture.SetPixel(newWidth - 1, 0, pixels[originalWidth - 1]); // Bottom right
                texture.SetPixel(0, newHeight - 1, pixels[(originalHeight - 1) * originalWidth]); // Upper left
                texture.SetPixel(newWidth - 1, newHeight - 1, pixels[pixels.Length - 1]); // Upper right

                texture.filterMode = _texture.filterMode;
                texture.Apply();
                _sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, newWidth, newHeight), new Vector2(0.5f, 0.5f), 100.0f);

                _renderer.sprite = _sprite;
            }
        }
    }
}
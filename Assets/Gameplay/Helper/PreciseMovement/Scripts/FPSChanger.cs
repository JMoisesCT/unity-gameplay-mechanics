using UnityEngine;
using UnityEngine.UI;

namespace JMoisesCT.UnityMechanics.Helper.PreciseMovement
{
    public class FPSChanger : MonoBehaviour
    {
        [SerializeField] private Button _button24Fps;
        [SerializeField] private Button _button30Fps;
        [SerializeField] private Button _button60Fps;

        // Start is called before the first frame update
        private void Start()
        {
            _button24Fps.onClick.AddListener(PressButton24Fps);
            _button30Fps.onClick.AddListener(PressButton30Fps);
            _button60Fps.onClick.AddListener(PressButton60Fps);
        }

        private void OnDestroy()
        {
            _button24Fps.onClick.RemoveListener(PressButton24Fps);
            _button30Fps.onClick.RemoveListener(PressButton30Fps);
            _button60Fps.onClick.RemoveListener(PressButton60Fps);
        }
        private void PressButton24Fps()
        {
            Application.targetFrameRate = 24;
        }

        private void PressButton30Fps()
        {
            Application.targetFrameRate = 30;
        }

        private void PressButton60Fps()
        {
            Application.targetFrameRate = 60;
        }
    }
}
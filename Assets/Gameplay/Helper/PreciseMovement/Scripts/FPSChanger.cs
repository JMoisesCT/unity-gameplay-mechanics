using UnityEngine;
using UnityEngine.UI;

namespace JMoisesCT.UnityMechanics.Helper.PreciseMovement
{
    public class FPSChanger : MonoBehaviour
    {
        [SerializeField] private Button _button15Fps;
        [SerializeField] private Button _button30Fps;
        [SerializeField] private Button _button60Fps;

        // Start is called before the first frame update
        private void Start()
        {
            _button15Fps.onClick.AddListener(PressButton15Fps);
            _button30Fps.onClick.AddListener(PressButton30Fps);
            _button60Fps.onClick.AddListener(PressButton60Fps);
        }

        private void OnDestroy()
        {
            _button15Fps.onClick.RemoveListener(PressButton15Fps);
            _button30Fps.onClick.RemoveListener(PressButton30Fps);
            _button60Fps.onClick.RemoveListener(PressButton60Fps);
        }
        private void PressButton15Fps()
        {
            Application.targetFrameRate = 15;
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
using UnityEngine;

namespace SDB.Core
{
    public interface IMoveInput
    {
        Vector2 Move { get; }
        /// <summary>Devolve o delta de olhar acumulado desde a última chamada.</summary>
        Vector2 ConsumeLook();
    }

    public sealed class TouchInput : IMoveInput
    {
        Vector2 _look;
        public Vector2 Move { get; set; }
        public void AddLook(Vector2 delta) => _look += delta;
        public Vector2 ConsumeLook() { var l = _look; _look = Vector2.zero; return l; }
    }
}

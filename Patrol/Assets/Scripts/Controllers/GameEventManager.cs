namespace Patrol
{
    public class GameEventManager
    {
        // Singleton instance.
        private static GameEventManager instance;

        public delegate void OnPlayerEnterArea(int area);
        public static event OnPlayerEnterArea onPlayerEnterArea;

        public delegate void OnSoldierCollideWithPlayer();
        public static event OnSoldierCollideWithPlayer onSoldierCollideWithPlayer;

        // ʹ�õ���ģʽ��
        public static GameEventManager GetInstance()
        {
            return instance ?? (instance = new GameEventManager());
        }

        // ����ҽ�������
        public void PlayerEnterArea(int area)
        {
            onPlayerEnterArea?.Invoke(area);
        }

        // ��Ѳ�߱��������ײ��
        public void SoldierCollideWithPlayer()
        {
            onSoldierCollideWithPlayer?.Invoke();
        }
    }
}
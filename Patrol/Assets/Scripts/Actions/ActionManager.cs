using System.Collections.Generic;
using UnityEngine;

namespace Patrol
{
    public class ActionManager : MonoBehaviour, IActionCallback
    {
        // 存储所有动作。
        private Dictionary<int, Action> actions = new Dictionary<int, Action>();
        private List<Action> waitToAdd = new List<Action>();
        private HashSet<int> waitToDelete = new HashSet<int>();

        protected void Update()
        {
            foreach (Action action in waitToAdd)
            {
                actions[action.GetInstanceID()] = action;
            }
            waitToAdd.Clear();
            // 执行每一个动作。
            foreach (KeyValuePair<int, Action> kv in actions)
            {
                Action action = kv.Value;
                if (action.destroy)
                {
                    waitToDelete.Add(action.GetInstanceID());
                }
                else if (action.enable)
                {
                    action.Update();
                }
            }
            // 删除已完成的动作对应的数据结构。
            foreach (int k in waitToDelete)
            {
                Action action = actions[k];
                actions.Remove(k);
                Destroy(action);
            }
            waitToDelete.Clear();
        }

        // 添加动作。
        public void AddAction(Action action)
        {
            waitToAdd.Add(action);
            action.Start();
        }

        public void ActionDone(Action action) { }
    }
}
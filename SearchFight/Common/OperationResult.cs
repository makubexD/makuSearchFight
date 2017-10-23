using System.Collections.Generic;

namespace SearchFight.Common
{
    public class OperationResult
    {
        private bool _success;
        public bool Success
        {
            get { return _success = MessageList.Count == 0; }
            set { _success = value; }
        }

        public List<string> MessageList { get; }

        public OperationResult()
        {
            MessageList = new List<string>();
            Success = true;
        }

        public void AddMessage(string message)
        {
            MessageList.Add(message);
        }
    }
}

using System;

namespace Plus.Code
{
    public class UserCancelledException : Exception
    {
        private string _message = null;

        public override string Message => _message;
        public UserCancelledException(string error = null) : base()
        {
            _message = "The user cancelled out of either the login dialog or the consent dialog.";
            if (!string.IsNullOrEmpty(error))
            {
                _message += string.Format($"Error received from OAuth proivider: ${error}");
            }
        }
    }
}
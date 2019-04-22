using System;

namespace Plus.Code
{
    public class InvalidStateException : Exception
    {
        public override string Message =>
            "Are you browing this website on a computer that you don't own? " +
            "Like one in a library or an airport or a hotel room or a cafe or that of a friend? " +
            "It is recommended that you do not browse this website on this computer. " +
            "The security of this computer may have been compromised.";
    }
}
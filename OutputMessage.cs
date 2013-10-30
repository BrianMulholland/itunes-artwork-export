using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunes_Artwork_Export
{
  public enum MessageSeverity
  {
    Always,
    Debug,
    Success,
    Warning,
    Error
  }

  public class OutputMessage
  {
    private readonly string _message;
    public string Message { get { return this._message; } }

    private readonly MessageSeverity _severity;
    public MessageSeverity Severity { get { return this._severity; } }

    private readonly bool _appendNewline;
    public bool AppendNewLine { get { return this._appendNewline; } }

    public OutputMessage(string message, MessageSeverity severity) : this(message, severity, false) { }

    public OutputMessage(string message, MessageSeverity severity, bool appendNewLine)
    {
      this._message = message;
      this._severity = severity;
      this._appendNewline = appendNewLine;
    }

    public static bool CheckDisplayMessage(MessageSeverity messageSeverity, MessageSeverity userSeverityLevel)
    {
      if (messageSeverity == MessageSeverity.Always)
      {
        return true;
      }
      else if (messageSeverity == MessageSeverity.Error)
      {
        return true;
      }
      else if (messageSeverity == MessageSeverity.Warning)
      {
        return (userSeverityLevel == MessageSeverity.Warning || userSeverityLevel == MessageSeverity.Success || userSeverityLevel == MessageSeverity.Debug);
      }
      else if (messageSeverity == MessageSeverity.Success)
      {
        return (userSeverityLevel == MessageSeverity.Success || userSeverityLevel == MessageSeverity.Debug);
      }
      else if (messageSeverity == MessageSeverity.Debug)
      {
        return (userSeverityLevel == MessageSeverity.Debug);
      }
      else
      {
        return false;
      }
    }
  }
}

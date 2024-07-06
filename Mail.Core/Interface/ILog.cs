public interface ILog
{
    public string CreateUserLog(NewUserLog log);
    public string CreateMessageLog(NewMessageLog log);
    public List<SimpleUserLog> UserLogsById(int UserId);
    public List<SimpleUserLog> UserLogsByAction(string Action);
    public List<SimpleMessageLog> MessageLogsByUserId(int UserId);
    public List<SimpleMessageLog> MessageLogsByMsgId(int UserId);
    public List<SimpleMessageLog> MessageLogsByAction(string Action);
}
public interface IMail
{
    public string NewMail(SimpleMessage message);
    public IdMail ReadMailById(int MessageId);
    public List<ShortMail> Index();
    public List<ShortMail> Sent();
    public List<ShortMail> RecycleBin();
    public List<ShortMail> Search(string Text);
    public string Delete(int MessageId);
    public string Trash(int MessageId);
    public string Restore(int MessageId);
    public List<IdUser> FindReciverCcId(string Username);
}
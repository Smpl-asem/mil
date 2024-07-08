public interface IMail
{
    public string NewMail(NewMail message , string Username , List<int> ReceiversId , List<int> CarbonCopiesId);
    public IdMail ReadMailById(int MessageId);
    public List<ShortMail> Index(string Username);
    public List<ShortMail> Sent(string Username);
    public List<ShortMail> RecycleBin(string Username);
    public List<ShortMail> SearchByUsername(string Username , string Text);
    public List<ShortMail> SearchByText(string Username , string Text);
    public string Delete(int MessageId);
    public string Trash(int MessageId);
    public string Restore(int MessageId);
    public List<IdUser> FindReciverCcId(string Username);
}
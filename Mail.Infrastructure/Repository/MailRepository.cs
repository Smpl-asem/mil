
public class MailRepository : IMail
{
    private Context db = new Context();
    public string NewMail(NewMail message){
        db.Message_tbl.Add( new Message{
            SerialNumber = message.SerialNumber,
            SenderId = message.SenderId,
            SenderIp = message.SenderIp,
            FlagDelete = 0,
            Subject = message.Subject,
            BodyText = message.BodyText,
            CreateTime = DateTime.Now
        });
        db.SaveChanges();
        return "succesful";
    }
    public IdMail ReadMailById(int MessageId){
        Message check = db.Message_tbl.Find(MessageId);
        if (check == null){
            return null;
        }
        return check.FlagDelete != 2 ? new IdMail{
            Id = check.Id,
            SerialNumber = check.SerialNumber,
            SenderId = check.SenderId,
            SenderIp = check.SenderIp,
            ReceiversId = check.Receivers.Select(x=> x.Id).ToList(),
            CarbonCopysId = check.CarbonCopys.Select(x => x.Id).ToList(),
            FlagDelete = check.FlagDelete,
            MessageLogsId = check.MessageLogs.Select(x=> x.Id).ToList(),
            Subject = check.Subject,
            BodyText = check.BodyText,
            AttachedFilesId = check.AttachedFile.Select(x=> x.Id).ToList()
        } : null;
    }
    public List<ShortMail> Index(string Username){
        List<ShortMail> results = new List<ShortMail>();
        int id = db.user_tbl.FirstOrDefault(x=> x.Username == Username).Id;
        foreach (var item in db.Message_tbl.Where(x=>x.Receivers.Any(y=>y.ReceiversId == id)))
        {
            results.Add(new ShortMail{
                Id = item.Id,
                SerialNumber = item.SerialNumber,
                SenderId = item.SenderId,
                ReceiversId = item.Receivers.Select(x => x.Id).ToList(),
                CarbonCopysId = item.CarbonCopys.Select(x => x.Id).ToList(),
                Subject = item.Subject,
                BodyText = item.BodyText.Substring(0,26) + " ...",
                type = "Receiver"
            });
        }
        return results;

    }
    public List<ShortMail> Sent(string Username){
        List<ShortMail> results = new List<ShortMail>();
        int id = db.user_tbl.FirstOrDefault(x=> x.Username == Username).Id;
        foreach (var item in db.Message_tbl.Where(x=>x.Receivers.Any(y=>y.ReceiversId == id)))
        {
            results.Add(new ShortMail{
                Id = item.Id,
                SerialNumber = item.SerialNumber,
                SenderId = item.SenderId,
                ReceiversId = item.Receivers.Select(x => x.Id).ToList(),
                CarbonCopysId = item.CarbonCopys.Select(x => x.Id).ToList(),
                Subject = item.Subject,
                BodyText = item.BodyText.Substring(0,26) + " ..."
            });
        }
        return results;
    }
    public List<ShortMail> RecycleBin(){
        return new List<ShortMail>();
    }
    public List<ShortMail> Search(string Text){
        return new List<ShortMail>();
    }
    public string Delete(int MessageId){
        return "";
    }
    public string Trash(int MessageId){
        return "";
    }
    public string Restore(int MessageId){
        return "";
    }
    public List<IdUser> FindReciverCcId(string Username){
        return new List<IdUser>();
    }
}
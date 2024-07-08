
using System.Data;
using Microsoft.AspNetCore.Mvc;

public class MailRepository : IMail
{
    private Context db = new Context();
    public string NewMail(NewMail message, string Username , List<int> ReceiversId , List<int> CarbonCopiesId){
        int sentId = Convert.ToInt32(db.user_tbl.FirstOrDefault(x=> x.Username == Username).Id);
        db.Message_tbl.Add( new Message{
            SerialNumber = message.SerialNumber,
            // SenderId = message.SenderId, لزومی نداره از نیو مسیج بگیریم. خودمون پیدا میکنیم
            // SenderIp = message.SenderIp,
            SenderId = sentId,
            SenderIp = "ip",
            FlagDelete = 0,
            Subject = message.Subject,
            BodyText = message.BodyText,
            ConnectedUser = [sentId, .. ReceiversId , .. CarbonCopiesId],
            CreateTime = DateTime.Now
        });
        db.SaveChanges();
        int NewMessageId = db.Message_tbl.FirstOrDefault(x=> x.SerialNumber == message.SerialNumber).Id;
        
        foreach (int item in ReceiversId)
        {
            db.Receivers_tbl.Add(new Receivers{
                MessageId = NewMessageId,
                ReceiversId = item,
                isReaded = false
            });
        }
        foreach (var item in CarbonCopiesId)
        {
            db.CarbonCopys_tbl.Add(new CarbonCopys{
                MessageId = NewMessageId,
                CarbonCopysId = item,
                isReaded = false
            });
        }
        db.SaveChanges();
        return "succesful";
    }
    public IdMail ReadMailById(int MessageId){
        Message check = db.Message_tbl.Find(MessageId);
        if (check == null){
            return null;
        }
    //     return check.FlagDelete != 2 ? new IdMail{
    //         Id = check.Id,
    //         SerialNumber = check.SerialNumber,
    //         SenderId = check.SenderId,
    //         SenderIp = check.SenderIp,
    //         ReceiversId = check.Receivers.Select(x=> x.Id).ToList(),
    //         CarbonCopysId = check.CarbonCopys.Select(x => x.Id).ToList(),
    //         FlagDelete = check.FlagDelete,
    //         MessageLogsId = check.MessageLogs.Select(x=> x.Id).ToList(),
    //         Subject = check.Subject,
    //         BodyText = check.BodyText,
    //         AttachedFilesId = check.AttachedFile.Select(x=> x.Id).ToList()
    //     } : null;
    // }
        return check.FlagDelete != 2 ? new IdMail{
            Id = check.Id,
            SerialNumber = check.SerialNumber,
            SenderId = check.SenderId,
            SenderIp = check.SenderIp,
            ReceiversId = db.Receivers_tbl.Where(x=>x.MessageId == check.Id).Select(x=>x.ReceiversId).ToList(),
            CarbonCopysId = db.CarbonCopys_tbl.Where(x=>x.MessageId == check.Id).Select(x=>x.CarbonCopysId).ToList(),
            FlagDelete = check.FlagDelete,
            MessageLogsId = db.MessageLogs_tbl.Where(x=>x.MessageId == check.Id).Select(x=> x.MessageId).ToList(),
            Subject = check.Subject,
            BodyText = check.BodyText,
            AttachedFilesId = db.AttachedFile_tbl.Where(x=>x.MessageId == check.Id).Select(x=>x.FilesId).ToList(),
        } : null;
    }
    public List<ShortMail> Index(string Username){
        List<ShortMail> results = new List<ShortMail>();
        int id = Convert.ToInt32(db.user_tbl.FirstOrDefault(x=> x.Username == Username).Id);
        foreach (var item in db.Message_tbl.Where(x=> x.ConnectedUser.Contains(id)))
        {
            if(db.Receivers_tbl.Any(x=> x.MessageId == item.Id && x.ReceiversId ==id)){
                results.Add(MessageToShort(item,"received"));
            }
            else if (db.CarbonCopys_tbl.Any(x=> x.CarbonCopysId == item.Id && x.CarbonCopysId ==id)){
                results.Add(MessageToShort(item,"cc"));
            }
        }
        return results;

    }
    public List<ShortMail> Sent(string Username){
        List<ShortMail> results = new List<ShortMail>();
        int id = Convert.ToInt32(db.user_tbl.FirstOrDefault(x=> x.Username == Username).Id);
        foreach (var item in db.Message_tbl.Where(x=>x.SenderId==id))
        {
            results.Add(MessageToShort(item,"sent"));
        }
        return results;
    }
    public List<ShortMail> RecycleBin(string Username){
        List<ShortMail> results = new List<ShortMail>();
        int id = Convert.ToInt32(db.user_tbl.FirstOrDefault(x=> x.Username == Username).Id);
        foreach (Message item in db.Message_tbl.Where( x=> x.FlagDelete == 1))
        {
            if(item.SenderId == id){
                results.Add(MessageToShort(item,"sent"));
            }
            else if(db.Receivers_tbl.Any(x=> x.MessageId == item.Id && x.ReceiversId ==Convert.ToInt32(id))){
                results.Add(MessageToShort(item,"received"));
            }
            else if (db.CarbonCopys_tbl.Any(x=> x.CarbonCopysId == item.Id && x.CarbonCopysId ==id)){
                results.Add(MessageToShort(item,"cc"));
            }
        }
        return results ;
    }
    public List<ShortMail> SearchByUsername(string Username , string Text){
        int id = Convert.ToInt32(db.user_tbl.FirstOrDefault(x=> x.Username == Username).Id);
        List<int> searchId = db.user_tbl.Where(x=> x.Username.Contains(Text)).Select(x=> Convert.ToInt32(x.Id)).ToList(); // list users who have text in username
        List<ShortMail> results = new List<ShortMail>();
            foreach (var item in db.Message_tbl.Where(x=>x.ConnectedUser.Intersect(searchId).Any()))
            {
                if(searchId.Contains(item.SenderId)){
                    results.Add(MessageToShort(item,"sent"));
                }
                else if(db.Receivers_tbl.Any(x=> x.MessageId == item.Id && x.ReceiversId ==id)){
                    results.Add(MessageToShort(item,"received"));
                }
                else if(db.CarbonCopys_tbl.Any(x=> x.CarbonCopysId == item.Id && x.CarbonCopysId ==id)){
                    results.Add(MessageToShort(item,"cc"));
                }
            }
        return results;
    }
    public List<ShortMail> SearchByText(string Username , string Text){
        int id = Convert.ToInt32(db.user_tbl.FirstOrDefault(x=> x.Username == Username).Id);
        List<ShortMail> results = new List<ShortMail>();
        foreach (var item in db.Message_tbl.Where(x=>x.Subject.Contains(Text) || x.BodyText.Contains(Text)))
            {
                if(id == item.SenderId){
                    results.Add(MessageToShort(item,"sent"));
                }
                else if(db.Receivers_tbl.Any(x=> x.MessageId == item.Id && x.ReceiversId ==id)){
                    results.Add(MessageToShort(item,"received"));
                }
                else if(db.CarbonCopys_tbl.Any(x=> x.CarbonCopysId == item.Id && x.CarbonCopysId ==id)){
                    results.Add(MessageToShort(item,"cc"));
                }
            }
        return results;
    }
    public string Delete(int MessageId){
        Message check = db.Message_tbl.Find(MessageId);
        if(check.FlagDelete == 0){
            return "Message Not found in Trash";
        }
        else if (check.FlagDelete == 2){
            return "Message Not Found";
        }
        else{
            check.FlagDelete = 2;
            db.Message_tbl.Update(check);
            db.SaveChanges();
            return "Succesful";
        }
    }
    // public string Trash(int MessageId){
    //     Message check = db.Message_tbl.Find(MessageId);
    //     if(check.FlagDelete == 0){
    //         return "Message Not found in Trash";
    //     }
    //     else if (check.FlagDelete == 2){
    //         return "Message Not Found";
    //     }
    //     else{
    //         check.FlagDelete = 2;
    //         db.Message_tbl.Update(check);
    //         db.SaveChanges();
    //         return "Succesful";
    //     }
    //}
    public string Restore(int MessageId){
        return "";
    }
    public List<IdUser> FindReciverCcId(string Username){
        return new List<IdUser>();
    }

    private ShortMail MessageToShort(Message item , string type){
        return new ShortMail{
                Id = item.Id,
                SerialNumber = item.SerialNumber,
                SenderId = item.SenderId,
                ReceiversId = db.Receivers_tbl.Where(x=> x.MessageId == item.Id).Select(x=> x.ReceiversId).ToList(),
                CarbonCopysId = db.CarbonCopys_tbl.Where(x=> x.MessageId == item.Id).Select(x=> x.CarbonCopysId).ToList(),
                Subject = item.Subject,
                BodyText = item.BodyText.Substring(0,26) + " ...",
                type = type,
                CreatedTime = item.CreateTime
                };
    }

    public string Trash(int MessageId)
    {
        throw new NotImplementedException();
    }
}
public interface IFile
{  
    public string UploadFile(int UserId,string Path);
    public List<SimpleFile> UserFiles(int UserId);
}
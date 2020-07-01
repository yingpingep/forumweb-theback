using System.Threading.Tasks;

namespace forumweb_theback.Models
{
    public enum MessageType {
        String,
        Image
    }

    public enum PageType {
        Chat,
        Question,
        KeyVision
    }

    public class Message
    {
        public MessageType Type { get; set; }
        public object Content { get; set; }

    }

    public interface IManipulateR
    {
        Task SendMessage(Message message);
        Task SendQuestion(Question question);
        Task SendChangePage(PageType page); 
    }
}
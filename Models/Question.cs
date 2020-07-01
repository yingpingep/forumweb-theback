using System;

namespace forumweb_theback.Models
{
    public enum QuestionMode
    {
        Single,
        Multiple,
        Answer
    }

    public class AnswerOption {
        public int Index { get; set; }
        public string Text { get; set; }
    }

    public class Question
    {
        public string Id { get; set; }
        public string Number { get; set; }
        public string Title { get; set; }
        public QuestionMode Mode { get; set; }
        public AnswerOption[] AnswerOptions { get; set; }        
    }
}
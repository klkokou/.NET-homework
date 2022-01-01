namespace Homework9.Calculator
{
    public class Answer<TCorrect, TWrong>
    {
        public readonly AnswerType AnswerType;
        public readonly TCorrect Correct;
        public readonly TWrong Wrong;

        public Answer(TCorrect correct)
        {
            AnswerType = AnswerType.Correct;
            Correct = correct;
        }
        
        public Answer(TWrong wrong)
        {
            AnswerType = AnswerType.Wrong;
            Wrong = wrong;
        }
    }

    public enum AnswerType
    {
        Correct,
        Wrong
    }
}
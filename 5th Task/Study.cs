public class Study
{
        private int studyID;
        private string studyType;
        private string result;

        public int GetStudyID()
        {
            return this.studyID;
        }

        public void SetStudyID(int value)
        {
            this.studyID = value;
        }

        public string GetStudyType()
        {
            return this.studyType;
        }

        public void SetStudyType(string value)
        {
            this.studyType = value;
        }

        public string GetResult()
        {
            return this.result;
        }

        public void SetResult(string value)
        {
            this.result = value;
        }
}

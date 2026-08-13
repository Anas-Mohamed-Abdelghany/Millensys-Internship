public class Patient
{
        private int patientID;
        private string name;
        private string disease;

        public int GetPatientID()
        {
            return this.patientID;
        }

        public void SetPatientID(int value)
        {
            this.patientID = value;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string value)
        {
            this.name = value;
        }

        public string GetDisease()
        {
            return this.disease;
        }

        public void SetDisease(string value)
        {
            this.disease = value;
        }
}

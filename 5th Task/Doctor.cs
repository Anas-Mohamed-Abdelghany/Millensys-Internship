public class Doctor
{
        private int doctorID;
        private string name;
        private string specialization;

        public int GetDoctorID()
        {
            return this.doctorID;
        }

        public void SetDoctorID(int value)
        {
            this.doctorID = value;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string value)
        {
            this.name = value;
        }

        public string GetSpecialization()
        {
            return this.specialization;
        }

        public void SetSpecialization(string value)
        {
            this.specialization = value;
        }
}

public class Appointment
{
        private Patient patient;
        private Doctor doctor;
        private DateTime date;
        private string branch;
        private string study;
        private string reason;

        public Appointment(Patient patient, Doctor doctor, DateTime date, string branch, string study, string reason)
        {
            this.patient = patient;
            this.doctor = doctor;
            this.date = date;
            this.branch = branch;
            this.study = study;
            this.reason = reason;
        }

        public Patient GetPatient()
        {
            return this.patient;
        }

        public void SetPatient(Patient value)
        {
            this.patient = value;
        }

        public Doctor GetDoctor()
        {
            return this.doctor;
        }

        public void SetDoctor(Doctor value)
        {
            this.doctor = value;
        }

        public DateTime GetDate()
        {
            return this.date;
        }

        public void SetDate(DateTime value)
        {
            this.date = value;
        }

        public string GetBranch()
        {
            return this.branch;
        }

        public void SetBranch(string value)
        {
            this.branch = value;
        }

        public string GetStudy()
        {
            return this.study;
        }

        public void SetStudy(string value)
        {
            this.study = value;
        }

        public string GetReason()
        {
            return this.reason;
        }

        public void SetReason(string value)
        {
            this.reason = value;
        }

        public void PrintAppointment()
        {
            Console.WriteLine("========================================");
            Console.WriteLine("         APPOINTMENT DETAILS");
            Console.WriteLine("========================================");
            Console.WriteLine($"Patient     : {this.patient.GetName()}");
            Console.WriteLine($"Disease     : {this.patient.GetDisease()}");
            Console.WriteLine($"Doctor      : {this.doctor.GetName()}");
            Console.WriteLine($"Specialist  : {this.doctor.GetSpecialization()}");
            Console.WriteLine($"Date        : {this.date:yyyy-MM-dd}");
            Console.WriteLine($"Branch      : {this.branch}");
            Console.WriteLine($"Study       : {this.study}");
            Console.WriteLine($"Reason      : {this.reason}");
            Console.WriteLine("========================================");
        }
}

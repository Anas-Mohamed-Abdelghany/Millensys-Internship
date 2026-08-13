class Program {
    static void Main(string[] args) {
        
        Patient pt1 = new Patient();
        pt1.SetPatientID(1);
        pt1.SetName("Ahmed Ali");
        pt1.SetDisease("Diabetes");

        Patient pt2 = new Patient();
        pt2.SetPatientID(2);
        pt2.SetName("Sara Mohamed");
        pt2.SetDisease("Asthma");

        Doctor d1 = new Doctor();
        d1.SetDoctorID(1);
        d1.SetName("Omar Hassan");
        d1.SetSpecialization("Cardiology");

        Doctor d2 = new Doctor();
        d2.SetDoctorID(2);
        d2.SetName("Mona Adel");
        d2.SetSpecialization("Neurology");

        Study s1 = new Study();
        s1.SetStudyID(1);
        s1.SetStudyType("Heart Checkup");
        s1.SetResult("Stable");

        Study s2 = new Study();
        s2.SetStudyID(2);
        s2.SetStudyType("Brain Scan");
        s2.SetResult("Needs Follow-up");

        Appointment a1 = new Appointment(pt1, d1, new DateTime(2026, 7, 20), "Main Branch", s1.GetStudyType(), "Patient has chest pain");
        Appointment a2 = new Appointment(pt2, d2, new DateTime(2026, 7, 21), "North Branch", s2.GetStudyType(), "Patient has recurring headaches");

        a1.PrintAppointment();
        Console.WriteLine();
        a2.PrintAppointment();
    }
}
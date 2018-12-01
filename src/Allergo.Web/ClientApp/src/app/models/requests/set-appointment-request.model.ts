export class SetAppointmentRequest {
    constructor(
        public Date: Date,
        public UserId: String,
        public DoctorId: String) { }
}